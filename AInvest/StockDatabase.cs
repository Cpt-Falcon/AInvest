using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AInvest
{
    public class StockDatabase : IDisposable
    {
        private HashSet<string> checkTablesSet;

        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aubrey\Source\Repos\serp777\AInvest\AInvest\StockData.mdf;Integrated Security=True";

        private SqlConnection stockDataSql; 

        public StockDatabase()
        {
            // Initialize the database.
            this.stockDataSql = new SqlConnection(ConnectionString);
            this.checkTablesSet = new HashSet<string>();
            this.stockDataSql.Open();
            this.checkTablesSet = new HashSet<string>(this.GetAllTableNames());

        }

        public bool CheckTableExists(string tableName)
        {
            return this.checkTablesSet.Contains(tableName);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>Whether a table was created.</returns>
        public bool CreateTable(string tableName)
        {
            string commandStr = @"CREATE TABLE [dbo].[" + tableName + @"] (
	                    [Id] INT PRIMARY KEY identity(1, 1), 
                        [DailyPrice] FLOAT NULL DEFAULT 0, 
                        [DailyVolume] INT NULL DEFAULT 0, 
                        [Date] DATETIME NULL, 
                        [SMA] FLOAT NULL DEFAULT 0, 
                        [EMA] FLOAT NULL DEFAULT 0, 
                        [WMA] FLOAT NULL DEFAULT 0, 
                        [MACD] FLOAT NULL DEFAULT 0, 
                        [STOCH] FLOAT NULL DEFAULT 0, 
                        [RSI] FLOAT NULL DEFAULT 0, 
                        [ADX] FLOAT NULL DEFAULT 0, 
                        [CCI] FLOAT NULL DEFAULT 0, 
                        [AROON] FLOAT NULL DEFAULT 0, 
                        [BBANDS] FLOAT NULL DEFAULT 0, 
                        [AD] FLOAT NULL, 
                        [OBV] FLOAT NULL DEFAULT 0
                    )";

            return this.ExecuteSqlCommand(tableName, commandStr, true);
        }

        public bool AddStockData(string tableName, DateTime time, float price, int volume, float SMA, float EMA, 
            float WMA, float MACD, float STOCH, float RSI, float ADX, float CCI, float AROON, 
            float BBANDS, float AD, float OBV)
        {
            string commandStr = @"INSERT INTO " + tableName + @" 
                (Date, DailyPrice, DailyVolume, SMA, EMA, WMA, MACD, STOCH, RSI, ADX, CCI, AROON, BBANDS, AD, OBV) VALUES 
                (@time, @price, @volume, @SMA, @EMA, @WMA, @MACD, @STOCH, @RSI, @ADX, @CCI, @AROON, @BBANDS, @AD, @OBV)";
            Collection<SqlParameter> parameters = new Collection<SqlParameter>();
            parameters.Add(new SqlParameter("@time", time));
            parameters.Add(new SqlParameter("@price", price));
            parameters.Add(new SqlParameter("@volume", volume));
            parameters.Add(new SqlParameter("@SMA", SMA));
            parameters.Add(new SqlParameter("@EMA", EMA));
            parameters.Add(new SqlParameter("@WMA", WMA));
            parameters.Add(new SqlParameter("@MACD", MACD));
            parameters.Add(new SqlParameter("@STOCH", STOCH));
            parameters.Add(new SqlParameter("@RSI", RSI));
            parameters.Add(new SqlParameter("@ADX", ADX));
            parameters.Add(new SqlParameter("@CCI", CCI));
            parameters.Add(new SqlParameter("@AROON", AROON));
            parameters.Add(new SqlParameter("@BBANDS", BBANDS));
            parameters.Add(new SqlParameter("@AD", AD));
            parameters.Add(new SqlParameter("@OBV", OBV));
            return this.ExecuteSqlCommand(tableName, commandStr, false, parameters);
        }

        public void Dispose()
        {
            this.stockDataSql.Close();
            this.stockDataSql.Dispose();
        }

        private bool ExecuteSqlCommand(string tableName, string command, bool createTable, Collection<SqlParameter> parameters = null)
        {
            try
            {
                if (this.stockDataSql.State != System.Data.ConnectionState.Open || (createTable && this.checkTablesSet.Contains(tableName)) || !this.checkTablesSet.Contains(tableName))
                {
                    return false;
                }

                SqlCommand getTablesCommand = new SqlCommand(command, this.stockDataSql);

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        getTablesCommand.Parameters.Add(parameter);
                    } 
                }

                if (getTablesCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
