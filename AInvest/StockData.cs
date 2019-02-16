using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AInvest
{
    public class StockData
    {
        //DateTime time, float price, int volume, float SMA, float EMA, 
        //float WMA, float MACD, float STOCH, float RSI, float ADX, float CCI, float AROON,
        //  float BBANDS, float AD, float OBV
        [Column("0")]
        public string Time;

        [Column("1")]
        public float Price;

        [Column("2")]
        public int Volume;

        [Column("3")]
        public float SMA;

        [Column("4")]
        public float EMA;

        [Column("5")]
        public float WMA;

        [Column("6")]
        public float MACD;

        [Column("7")]
        public float STOCH;

        [Column("8")]
        public float RSI;

        [Column("9")]
        public float ADX;

        [Column("10")]
        public float CCI;

        [Column("11")]
        public float AROON;

        [Column("12")]
        public float BBANDS;

        [Column("13")]
        public float AD;

        [Column("14")]
        public float OBV;
    }

    public class StockDataPrediction
    {
        [Column("ScorePrice")]
        public float Price;

        [Column("ScoreVolume")]
        public int Volume;

        [Column("3")]
        public float SMA;

        [Column("4")]
        public float EMA;

        [Column("5")]
        public float WMA;

        [Column("6")]
        public float MACD;

        [Column("7")]
        public float STOCH;

        [Column("8")]
        public float RSI;

        [Column("9")]
        public float ADX;

        [Column("10")]
        public float CCI;

        [Column("11")]
        public float AROON;

        [Column("12")]
        public float BBANDS;

        [Column("13")]
        public float AD;

        [Column("14")]
        public float OBV;
    }
}
