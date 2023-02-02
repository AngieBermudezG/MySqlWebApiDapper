namespace WebApiMySQLNetCore.Data
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString) => ConectionString = connectionString;
       
        public string ConectionString { get; set; }
    }
}