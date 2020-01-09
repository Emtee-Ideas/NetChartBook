using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03.ViewModels
{
    public class ModelHelper
    {
        public static BindableCollection<Symbol> CsvToSymbolCollection(string csvFile)
        {
            FileStream fs = new FileStream(csvFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            List<String> lst = new List<string>();
            while (!sr.EndOfStream)
            {
                lst.Add(sr.ReadLine());
            }

            string[] fields = lst[0].Split(new char[] { ',' });
            var res = new BindableCollection<Symbol>();

            for (int i = 1; i < lst.Count; i++)
            {
                fields = lst[i].Split(',');
                res.Add(new Symbol
                {
                    Ticker = fields[0],
                    Region = fields[1],
                    Sector = fields[2]
                });
            }
            return res;
        }

        public static BindableCollection<Price> GetYahooStockData(int symbolId, string ticker, DateTime? startDate, DateTime? endDate)
        {
            // string ticker = IdToTicker(symbolId);
            string urlTemplate = @"http://ichart.finanace.yahoo.com/table.csv?s=[symbol]&a=[startMonth]&b=[startDay]&c=[startYear]&d=[endMonth]&e=[endDay]&f=[endYear]&g=d&ignore=.csv";
            if (!endDate.HasValue)
                endDate = DateTime.Now;
            if (!startDate.HasValue)
                startDate = DateTime.Now.AddYears(-5);
            if (ticker == null || ticker.Length < 1)
                throw new ArgumentException("Symbol invalid: " + ticker);

            // Note: Yahoo's scheme uses a month number 1 less than actual
            // e.g. January = "0"
            int strtMo = startDate.Value.Month - 1;
            string startMonth = strtMo.ToString();
            string startDay = startDate.Value.Day.ToString();
            string startYear = startDate.Value.Year.ToString();

            int endMo = endDate.Value.Month - 1;
            string endMonth = endMo.ToString();
            string endDay = endDate.Value.Day.ToString();
            string endYear = endDate.Value.Year.ToString();

            urlTemplate = urlTemplate.Replace("[symbol]", ticker);

            urlTemplate = urlTemplate.Replace("[startMonth]", startMonth);
            urlTemplate = urlTemplate.Replace("[startDay]", startDay);
            urlTemplate = urlTemplate.Replace("[startYear]", startYear);
            urlTemplate = urlTemplate.Replace("[endMonth]", endMonth);
            urlTemplate = urlTemplate.Replace("[endDay]", endDay);
            urlTemplate = urlTemplate.Replace("[endYear]", endYear);
            string history = String.Empty;
            WebClient wc = new WebClient();
            try
            {
                history = wc.DownloadString(urlTemplate);
            }
            catch
            {
                // throw wex;
            }
            finally
            {
                wc.Dispose();
            }

            DataTable dt = new DataTable();
            // trim off unused characters from end of line
            history = history.Replace("\r", "");
            // split to array on end of line
            string[] rows = history.Split('\n');
            // split to columns
            string[] colNames = rows[].Split(',');
            // add the columns to the DataTable
            foreach (string colName in colNames)
            {
                dt.Columns.Add(colName);
            }

            DataRow row = null;
            string[] rowValues;
            object[] rowItems;
            for (int i = rows.Length - 1; i > 0; i--)
            {
                rowValues = rows[i].Split(',');
                row = dt.NewRow();
                rowItems = StringArrayToObjectArray(rowValues);
                if (rowItems[0] != null && (string)rowItems[0] != "")
                {
                    row.ItemArray = rowItems;
                    dt.Rows.Add(row);
                }
            }

            var res = new BindableCollection<Price>();
            foreach (DataRow r in dt.Rows)
            {
                DateTime date = (DateTime.ParseExact(r["Date"].ToString(),
                    "yyyy-MM-dd", CultureInfo.InvariantCulture).ToLocalTime()).AddDays(1);
                date = Convert.ToDateTime(date.ToShortDateString());
                res.Add(new Price
                {
                    SymbolID = symbolId,
                    Date = date,
                    PriceOpen = Convert.ToDouble(r["Open"]),
                    PriceHigh = Convert.ToDouble(r["High"]),
                    PriceLow = Convert.ToDouble(r["Low"]),
                    PriceClose = Convert.ToDouble(r["Close"]),
                    PriceAdj = Convert.ToDouble(r["Adj Close"]),
                    Volume = Convert.ToDouble(r["Volume"]),
                });
            }
            return res;
        }

        private static object[] StringArrayToObjectArray(string[] input)
        {
            int elements = input.Length;
            object[] objArray = new object[elements];
            input.CopyTo(objArray, 0);
            return objArray;
        }

        public static string IdToTicker(int symbolId)
        {
            string ticker = string.Empty;

            using (var db = new MyDbEntities())
            {
                var query = from s in db.Symbols
                            where (s.SymbolID == symbolId)
                            select s.Ticker;

                foreach (var q in query)
                {
                    ticker = q.ToString();
                }
            }
            return ticker;
        }

        public static void SymbolInsert(Symbol symbol)
        {
            using (var db = new MyDbEntities())
            {
                try
                {
                    db.Symbols.Add(symbol);
                    db.SaveChanges();
                }
                catch
                {
                    
                }
            }
        }
        public static void SymbolInsert(BindableCollection<Symbol> symbols)
        {
            using (var db = new MyDbEntities())
            {
                try
                {
                    foreach (var s in symbols)
                    {
                        var symbol = new Symbol();
                        symbol = s;
                        db.Symbols.Add(symbol);
                    }
                    db.SaveChanges();
                }
                catch { }
            }
        }
    }
}
