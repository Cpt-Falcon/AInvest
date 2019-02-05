using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AInvest
{
    public class StockDatabase : IDisposable
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aubrey\Source\Repos\serp777\AInvest\AInvest\StockData.mdf;Integrated Security=True";

        private SqlConnection stockDataSql; 

        public StockDatabase()
        {
            // Initialize the database.
            this.stockDataSql = new SqlConnection(ConnectionString);
            this.stockDataSql.Open();

        }

        public List<string> GetAllTableNames()
        {
            if (this.stockDataSql.State != System.Data.ConnectionState.Open)
            {
                return null;
            }

            List<string> tableNames = new List<string>();
            SqlCommand getTablesCommand = new SqlCommand(@"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", this.stockDataSql);
            using (SqlDataReader tableReader = getTablesCommand.ExecuteReader())
            {
                while (tableReader.Read())
                {
                    tableNames.Add(tableReader[0].ToString());
                }
            }

            return tableNames;
        }

        public void Dispose()
        {
            this.stockDataSql.Close();
            this.stockDataSql.Dispose();
        }
    }
}
