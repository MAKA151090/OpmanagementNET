using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Models;
using OfficeOpenXml;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Net;


namespace HealthCare.Controllers
{
    public class ImportDataController : Controller
    {

        private HealthcareContext _healthcareContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;



        public ImportDataController(HealthcareContext healthcareContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _healthcareContext = healthcareContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            ClinicAdminBusinessClass cln = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["allscreen"] = cln.AllScreenname();

            return View();
        }


        public async Task<IActionResult> GetImportdata(string ScreenName,string buttonType,IFormFile ExcelFile)
        {

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            ClinicAdminBusinessClass cln = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["allscreen"] = cln.AllScreenname();


            if (buttonType == "Get")
            {

                // Get TableName for the selected ScreenName
                var tableDetails = _healthcareContext.shdbscreenname
                    .Where(s => s.ScreenName == ScreenName && s.IsMaster)
                    .Select(s => s.TableName)
                    .FirstOrDefault();

                if (tableDetails == null)
                {
                    TempData["Message"] = "Table not found for the selected screen.";
                    return RedirectToAction("LeaveMasterModel");
                }

                // Generate Excel file
                var excelFile = await GenerateExcelFile(tableDetails);

                return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{ScreenName}.xlsx");
            }

            if (buttonType == "Save" && ExcelFile != null)
            {
                try
                {
                    await ProcessUploadedExcel(ScreenName, ExcelFile);
                    TempData["Message"] = "Data updated successfully!";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error processing file: " + ex.Message;
                }

                return RedirectToAction("GetImportdata");
            }

            return View("GetData");
        }


        private async Task<byte[]> GenerateExcelFile(string tableName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(tableName);

                // Retrieve the entity type by matching the table name
                var entityType = _healthcareContext.Model.GetEntityTypes()
                    .FirstOrDefault(e => e.GetTableName().Equals(tableName, StringComparison.OrdinalIgnoreCase));

                if (entityType == null)
                {
                    throw new Exception($"Entity '{tableName}' not found in the model.");
                }

                // Get Column Names from the Entity
                var columns = entityType.GetProperties()
                    .Select(p => p.Name)
                    .ToList();

                // Add Column Headers
                for (int i = 0; i < columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columns[i];
                }

                // Retrieve the DbSet dynamically using reflection
                var dbSetMethod = typeof(DbContext).GetMethods()
                    .Where(m => m.Name == "Set" && m.GetParameters().Length == 0)  // Ensure we use the correct method
                    .FirstOrDefault(m => m.IsGenericMethod);

                if (dbSetMethod == null)
                {
                    throw new Exception("Unable to find the correct 'Set' method.");
                }

                var genericDbSetMethod = dbSetMethod.MakeGenericMethod(entityType.ClrType);
                var dbSet = genericDbSetMethod.Invoke(_healthcareContext, null);

                // Ensure the DbSet is cast to the correct type
                var dbSetAsQueryable = dbSet as IQueryable;
                if (dbSetAsQueryable == null)
                {
                    throw new Exception($"Unable to cast DbSet to IQueryable for type '{entityType.ClrType.FullName}'.");
                }

                // Use reflection to fetch data asynchronously
                var toListMethod = typeof(EntityFrameworkQueryableExtensions)
     .GetMethod("ToListAsync")
     .MakeGenericMethod(entityType.ClrType);

                // Invoke the method dynamically
                var task = toListMethod.Invoke(null, new object[] { dbSetAsQueryable, CancellationToken.None });

                // Ensure the task is awaited correctly
                var result = await (dynamic)task;  // Use dynamic to properly await the task

                // Convert the result to a List<object>
                var data = ((IEnumerable<object>)result).ToList();

                // If data exists, populate the rows; otherwise, leave empty
                if (data != null && data.Any())
                {
                    // Loop through data and fill the rows
                    for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
                    {
                        var rowData = data[rowIndex];

                        // Loop through columns
                        for (int colIndex = 0; colIndex < columns.Count; colIndex++)
                        {
                            // Get the IProperty metadata object
                            var property = entityType.GetProperties().FirstOrDefault(p => p.Name == columns[colIndex]);

                            if (property != null)
                            {
                                // Access the underlying PropertyInfo from IProperty
                                PropertyInfo propertyInfo = property.PropertyInfo;

                                if (propertyInfo != null)
                                {
                                    // Get the value using reflection
                                    var propertyValue = propertyInfo.GetValue(rowData);

                                    // Set value in cell and handle nulls
                                    worksheet.Cells[rowIndex + 2, colIndex + 1].Value = propertyValue ?? ""; // Default to empty string for null
                                }
                            }
                            else
                            {
                                worksheet.Cells[rowIndex + 2, colIndex + 1].Value = ""; // Default to empty if no property
                            }
                        }
                    }
                }
                else
                {
                    // If no data, leave the rows empty (Excel file will just have headers)
                    worksheet.Cells[2, 1].Value = ""; // Start from row 2, column 1
                }

                // Return the Excel file as a byte array
                return await package.GetAsByteArrayAsync();
            }
        }


        private async Task ProcessUploadedExcel(string screenName, IFormFile excelFile)
        {
            // Get Table Name for the Screen
            var tableDetails = _healthcareContext.shdbscreenname
                .Where(s => s.ScreenName == screenName && s.IsMaster)
                .Select(s => s.TableName)
                .FirstOrDefault();

            if (tableDetails == null)
            {
                throw new Exception($"Table not found for the selected screen '{screenName}'.");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await excelFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null) throw new Exception("Invalid Excel File");

                    var entityType = _healthcareContext.Model.GetEntityTypes()
                        .FirstOrDefault(e => e.GetTableName().Equals(tableDetails, StringComparison.OrdinalIgnoreCase));

                    if (entityType == null)
                    {
                        throw new Exception($"Entity '{tableDetails}' not found in the model.");
                    }

                    // Get Column Names from the Entity
                    var columns = entityType.GetProperties()
                        .Select(p => p.Name)
                        .ToList();

                    // Create a list to store data
                    var dataList = new List<object>();

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)  // Start from 2nd row (Skip headers)
                    {
                        var obj = Activator.CreateInstance(entityType.ClrType);

                        for (int col = 1; col <= colCount; col++)
                        {
                            string columnName = columns[col - 1];
                            var property = entityType.GetProperties().FirstOrDefault(p => p.Name == columnName);
                            if (property == null) continue;

                            PropertyInfo propertyInfo = property.PropertyInfo;
                            if (propertyInfo == null) continue;

                            var cellValue = worksheet.Cells[row, col].Value;
                            object convertedValue = null;

                            try
                            {
                                // Check if property is of type string
                                if (propertyInfo.PropertyType == typeof(string))
                                {
                                    if (cellValue is double serialDate)
                                    {
                                        // Check if it's a valid serial date (not just a number like 1, 1.0, etc.)
                                        // We define "valid" serial dates as values larger than a certain threshold (e.g., 1)
                                        if (serialDate > 100)
                                        {
                                            // Convert the Excel serial date to DateTime, and remove time
                                            convertedValue = DateTime.Parse("01/01/1900").AddDays(serialDate - 2).ToString("dd-MM-yyyy");
                                        }
                                        else
                                        {
                                            // If the serial date is a plain number (e.g., 1 or 1.0), treat it as a regular string
                                            convertedValue = cellValue.ToString();
                                        }
                                    }
                                    else if (cellValue is DateTime date)
                                    {
                                        // Check if the DateTime has no time portion
                                        if (date.TimeOfDay == TimeSpan.Zero)
                                        {
                                            // Just a date (no time), format it to the desired string format
                                            convertedValue = date.ToString("dd-MM-yyyy");
                                        }
                                        else
                                        {
                                            // Full DateTime (with time), format it to include time as well
                                            convertedValue = date.ToString("dd-MM-yyyy HH:mm:ss");
                                        }
                                    }
                                    else
                                    {
                                        // If it's not a date or serial date, just convert to string as usual
                                        convertedValue = cellValue?.ToString();
                                    }
                                }

                                // Handle boolean columns (like '0' or '1' for boolean values)
                                else if (propertyInfo.PropertyType == typeof(bool))
                                {
                                    if (cellValue is string boolStr)
                                    {
                                        convertedValue = boolStr == "1" || boolStr.ToLower() == "true";  // Convert string '1'/'true' to bool
                                    }
                                    else if (cellValue is double boolDouble)
                                    {
                                        convertedValue = boolDouble == 1;  // Convert numeric 1 to true
                                    }
                                }
                                // Handle integer columns (e.g., '1' for integer type)
                                else if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long))
                                {
                                    if (cellValue is string strValue)
                                    {
                                        convertedValue = Convert.ToInt32(strValue);  // Convert string to integer
                                    }
                                    else if (cellValue is double doubleValue)
                                    {
                                        convertedValue = Convert.ToInt32(doubleValue);  // Convert numeric values to integer
                                    }
                                }
                                // Handle DateTime columns (e.g., '30-01-2025 15:28:51' as DateTime string)
                                else if (propertyInfo.PropertyType == typeof(DateTime))
                                {
                                    if (cellValue is string dateStr)
                                    {
                                        if (DateTime.TryParseExact(dateStr, "dd-MM-yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                        {
                                            convertedValue = parsedDateTime;  // Keep DateTime object as is
                                        }
                                        else
                                        {
                                            // Handle cases where date format doesn't match or is invalid
                                            throw new Exception($"Invalid date format in row {row}, column {col}: {dateStr}");
                                        }
                                    }
                                    else if (cellValue is double serialDate)
                                    {
                                        // Convert Excel serial date to DateTime
                                        var dateTime = DateTime.Parse("01/01/1900").AddDays(serialDate - 2);  // Adjust for Excel's serial date format
                                        convertedValue = dateTime;  // Keep DateTime object as is
                                    }
                                }
                                // Handle other types (like IP address or any custom types)
                                else if (propertyInfo.PropertyType == typeof(IPAddress))
                                {
                                    if (cellValue is string ipStr)
                                    {
                                        convertedValue = IPAddress.Parse(ipStr);  // Convert IP string to IPAddress type
                                    }
                                }
                                else
                                {
                                    // Handle any other types that are not string, bool, int, or DateTime
                                    convertedValue = Convert.ChangeType(cellValue, propertyInfo.PropertyType);
                                }

                                // Set the converted value to the property of the entity object
                                propertyInfo.SetValue(obj, convertedValue);
                            }
                            catch (Exception ex)
                            {
                                // Log any conversion issues or skip invalid rows/columns
                                Console.WriteLine($"Error processing row {row}, column {col}: {ex.Message}");
                            }
                        }

                        // Add the processed object to the list for further processing
                        dataList.Add(obj);
                    }


                    // Retrieve DbSet dynamically
                    var dbSetMethod = typeof(DbContext)
                        .GetMethods()
                        .FirstOrDefault(m => m.Name == "Set" && m.IsGenericMethod && m.GetParameters().Length == 0);

                    if (dbSetMethod == null)
                    {
                        throw new Exception("Unable to find the correct 'Set' method.");
                    }

                    // Make it generic for the entity type
                    var genericDbSetMethod = dbSetMethod.MakeGenericMethod(entityType.ClrType);
                    var dbSet = genericDbSetMethod.Invoke(_healthcareContext, null);

                    if (dbSet == null)
                    {
                        throw new Exception($"Unable to retrieve DbSet for '{entityType.ClrType.FullName}'.");
                    }

                    // Use reflection to find Add or Update method
                    var addOrUpdateMethod = dbSet.GetType().GetMethod("Add");
                    foreach (var item in dataList)
                    {
                        var keyProperties = entityType.GetProperties()
       .Where(p => p.IsPrimaryKey()) // Get only primary keys
       .ToList();

                        // 🔹 2. Get primary key values from the object
                        object[] keyValues = keyProperties
                            .Select(kp => kp.PropertyInfo.GetValue(item))
                            .ToArray();

                        // 🔹 3. Check if an entity with the same PK exists
                        var existingEntity = await _healthcareContext.FindAsync(entityType.ClrType, keyValues);

                        if (existingEntity != null)
                        {
                            // 🔹 4. Update existing record
                            _healthcareContext.Entry(existingEntity).CurrentValues.SetValues(item);
                        }
                        else
                        {
                            // 🔹 5. Add new record
                            _healthcareContext.Add(item);
                        }
                    }

                    // 🔹 6. Save changes
                    var changes = await _healthcareContext.SaveChangesAsync();
                    Console.WriteLine($"🔹 Database Changes Saved: {changes} records.");
                    if (changes == 0)
                    {
                        throw new Exception("🚨 No records were updated! Check entity tracking.");
                    }
                }

                    await _healthcareContext.SaveChangesAsync();
                }
            }
        }


    }

