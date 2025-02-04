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
using Humanizer;
using System.Linq.Expressions;


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
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            ClinicAdminBusinessClass cln = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["allscreen"] = cln.AllScreenname(facilityId);

            return View();
        }


        public async Task<IActionResult> GetImportdata(string ScreenName, string buttonType, IFormFile ExcelFile)
        {

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            ClinicAdminBusinessClass cln = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["allscreen"] = cln.AllScreenname(facilityId);


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
                var excelFile = await GenerateExcelFile(tableDetails,facilityId);

                return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{ScreenName}.xlsx");
            }

            if (buttonType == "Save" && ExcelFile != null)
            {
                try
                {
                    await ProcessUploadedExcel(ScreenName, ExcelFile);
                    ViewBag.Message = "Data updated successfully!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error processing file: " + ex.Message;
                }


            }

            return View("GetData");
        }


        private async Task<byte[]> GenerateExcelFile(string tableName,string facilityId)
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
                    .Where(p => !p.Name.Contains("date"))
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





                // Fetch data asynchronously
                var toListMethod = typeof(EntityFrameworkQueryableExtensions)
                    .GetMethod("ToListAsync")
                    .MakeGenericMethod(entityType.ClrType);

                var task = toListMethod.Invoke(null, new object[] { dbSetAsQueryable, CancellationToken.None });
                var result = await (dynamic)task; // Await properly

                // If FacilityId filtering is needed
                if (!string.IsNullOrEmpty(facilityId))
                {
                    var facilityProperty = entityType.GetProperties()
                        .FirstOrDefault(p => p.Name.Equals("FacilityID", StringComparison.OrdinalIgnoreCase));

                    if (facilityProperty != null)
                    {
                        var facilityPropertyInfo = facilityProperty.PropertyInfo;

                        // Cast result to IEnumerable<object> before applying LINQ
                        var resultList = (IEnumerable<object>)result;

                        // Apply filtering explicitly using Func<object, bool>
                        result = resultList
                            .Where((Func<object, bool>)(entity =>
                                facilityPropertyInfo.GetValue(entity)?.ToString() == facilityId))
                            .ToList();
                    }
                }

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
            var tableDetails = _healthcareContext.shdbscreenname
                .Where(s => s.ScreenName == screenName && s.IsMaster)
                .Select(s => s.TableName)
                .FirstOrDefault();

            if (tableDetails == null)
                throw new Exception($"Table not found for the selected screen '{screenName}'.");

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
                        throw new Exception($"Entity '{tableDetails}' not found in the model.");

                    var columns = entityType.GetProperties()
                    .Select(p => p.Name)
                    .ToList();

                    var dataList = new List<object>();

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var obj = Activator.CreateInstance(entityType.ClrType);

                        foreach (var property in entityType.GetProperties())
                        {
                            PropertyInfo propertyInfo = property.PropertyInfo;
                            if (propertyInfo == null) continue;

                            string columnName = property.Name;
                            var cellValue = worksheet.Cells[row, columns.IndexOf(columnName) + 1].Value;
                            object convertedValue = null;

                            try
                            {

                                if (propertyInfo.PropertyType == typeof(string))
                                {
                                    if (cellValue is double serialDate)
                                    {
                                        bool isYearOnlyColumn = propertyInfo.Name.Contains("Year"); // Adjust based on your column naming convention

                                        if (isYearOnlyColumn)
                                        {
                                            // If it's a year-only column, store it as a string (e.g., "2023")
                                            convertedValue = serialDate.ToString();
                                        }
                                        else if (serialDate > 1000 && serialDate < 50000) // Only valid Excel serial dates
                                        {
                                            // Convert Excel serial date to proper DateTime format
                                            DateTime parsedDate = new DateTime(1900, 1, 1).AddDays(serialDate - 2);
                                            convertedValue = parsedDate.ToString("dd-MM-yyyy");
                                        }
                                        else
                                        {
                                            // If it's just a number like 2023, store it as a string
                                            convertedValue = serialDate.ToString();
                                        }
                                    }
                                    else
                                    {
                                        // If the serial date is a plain number (e.g., 1 or 1.0), treat it as a regular string
                                        convertedValue = cellValue?.ToString();
                                    }

                                }

                                else if (propertyInfo.PropertyType == typeof(bool))
                                {
                                    convertedValue = (cellValue?.ToString().Equals("1") == true || cellValue?.ToString().Equals("true", StringComparison.OrdinalIgnoreCase) == true) ? (bool?)true : (bool?)false;


                                }
                                else if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long))
                                {
                                    convertedValue = Convert.ToInt32(cellValue);
                                }
                                else if (propertyInfo.PropertyType == typeof(DateTime))
                                {
                                    if (cellValue is double serialDate)
                                        convertedValue = DateTime.FromOADate(serialDate);
                                    else if (DateTime.TryParse(cellValue?.ToString(), out DateTime parsedDate))
                                        convertedValue = parsedDate;
                                }
                                else
                                {
                                    convertedValue = Convert.ChangeType(cellValue, propertyInfo.PropertyType);
                                }

                                propertyInfo.SetValue(obj, convertedValue ?? GetDefaultValue(propertyInfo.PropertyType));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error processing row {row}, column {columnName}: {ex.Message}");
                            }
                        }

                        dataList.Add(obj);

                    }

                    foreach (var obj in dataList)
                    {
                        if (obj != null)
                        {
                            var currentTime = DateTime.Now.ToString();
                            var clientIp = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                            var currentUser = User.Claims.FirstOrDefault()?.Value.ToString();

                            var lastUpdatedDateProp = entityType.GetProperties()
                                .FirstOrDefault(p => p.Name.Equals("LastUpdatedDate", StringComparison.OrdinalIgnoreCase));
                            var lastUpdatedMachineProp = entityType.GetProperties()
                                .FirstOrDefault(p => p.Name.Equals("LastUpdatedMachine", StringComparison.OrdinalIgnoreCase));
                            var lastUpdatedUserProp = entityType.GetProperties()
                                .FirstOrDefault(p => p.Name.Equals("LastUpdatedUser", StringComparison.OrdinalIgnoreCase));

                            if (lastUpdatedDateProp?.PropertyInfo != null)
                                lastUpdatedDateProp.PropertyInfo.SetValue(obj, currentTime);

                            if (lastUpdatedMachineProp?.PropertyInfo != null)
                                lastUpdatedMachineProp.PropertyInfo.SetValue(obj, clientIp);

                            if (lastUpdatedUserProp?.PropertyInfo != null)
                                lastUpdatedUserProp.PropertyInfo.SetValue(obj, currentUser);
                        }
                    }

                    var dbSetMethod = typeof(DbContext).GetMethods()
                        .FirstOrDefault(m => m.Name == "Set" && m.IsGenericMethod && m.GetParameters().Length == 0);

                    if (dbSetMethod == null) throw new Exception("Unable to find the correct 'Set' method.");

                    var genericDbSetMethod = dbSetMethod.MakeGenericMethod(entityType.ClrType);
                    var dbSet = genericDbSetMethod.Invoke(_healthcareContext, null);

                    if (dbSet == null) throw new Exception($"Unable to retrieve DbSet for '{entityType.ClrType.FullName}'");

                    foreach (var item in dataList)
                    {
                        var keyProperties = entityType.GetProperties().Where(p => p.IsPrimaryKey()).ToList();
                        object[] keyValues = keyProperties.Select(kp => kp.PropertyInfo.GetValue(item)).ToArray();

                        var existingEntity = await _healthcareContext.FindAsync(entityType.ClrType, keyValues);

                        if (existingEntity != null)
                            _healthcareContext.Entry(existingEntity).CurrentValues.SetValues(item);
                        else
                            _healthcareContext.Add(item);
                    }

                    var changes = await _healthcareContext.SaveChangesAsync();
                    if (changes == 0) throw new Exception("No records were updated! Check entity tracking.");
                }
            }
        }


        // Helper method to get default values for missing properties
        private static object GetDefaultValue(Type type)
        {
            if (type == typeof(string)) return "";
            if (type == typeof(int)) return 0;
            if (type == typeof(double)) return 0.0;
            if (type == typeof(decimal)) return 0m;
            return null;
        }
    }


    }

