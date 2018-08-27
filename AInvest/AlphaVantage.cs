using Avapi;
using Avapi.AvapiTIME_SERIES_DAILY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AInvest
{
    public class AlphaVantage
    {
        private const string apiKey = "D6ILYAYUQN0NZU92";
        private IAvapiConnection connection;

        public AlphaVantage()
        {
            this.ConnectAlphaVantageApi();

            this.TestQueryAlphaVantageApi();
        }

        public void ConnectAlphaVantageApi()
        {
            // Creating the connection object
            this.connection = AvapiConnection.Instance;

            // Set up the connection and pass the API_KEY provided by alphavantage.co
            this.connection.Connect(apiKey);
        }

        public void TestQueryAlphaVantageApi()
        {
            // Get the TIME_SERIES_DAILY query object
            Int_TIME_SERIES_DAILY time_series_daily =
                connection.GetQueryObject_TIME_SERIES_DAILY();

            // Perform the TIME_SERIES_DAILY request and get the result
            IAvapiResponse_TIME_SERIES_DAILY time_series_dailyResponse =
            time_series_daily.Query(
                 "MSFT",
                 Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize.compact);

            // Printout the results
            Console.WriteLine("******** RAW DATA TIME_SERIES_DAILY ********");
            Console.WriteLine(time_series_dailyResponse.RawData);

        }
    }
}
