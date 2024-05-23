using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Web;
using Microsoft.Data.SqlClient;

namespace HealthCare.Business
{
    public static class BusinessClassCommon
    {
        public static DataTable DataTable(DbContext context, string sqlQuery,
                                        params DbParameter[] parameters)
        {


            // Your DbContext
            var dbContext = context;

            // Your SQL query
            string query = sqlQuery;

            // Execute raw SQL query and retrieve data into a DataTable
            DataTable dataTable = new DataTable();
            using (var connection = dbContext.Database.GetDbConnection() as SqlConnection)
            {
                if (connection != null)
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                }
            }

            return dataTable;
        }
    }
}
