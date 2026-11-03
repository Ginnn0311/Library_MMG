using Microsoft.Data.SqlClient;

namespace Library.DTO
{
    public static class Database
    {
        private static string connectionString =
            @"Server=localhost\SQLEXPRESS01;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}