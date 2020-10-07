using System;
using System.Collections.Generic;
using System.Text;

namespace TradeProcessor
{
  public  class TradeProcessor
    {
        private static float LotSize = 100000f;
        public void ProcessTrades(System.IO.Stream stream) {
            var lines = new List<string>();

            using (var reader = new System.IO.StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);


                }
            }
                var trades = new List<TradeRecord>();

                var lineCount = 1;
                foreach (var line in lines) {
                    var fields = line.Split(new char[] { ',' });
                    if (fields.Length != 3) {
                    Console.WriteLine("WARN: LINE {0} malformed. Only {1} field(s) found.", lineCount,fields.Length);
                    continue;

                    } 
               
                if (fields[0].Length != 6) {
                          Console.WriteLine("Warn: trade currencies on line {0} malformed: '{1}'", lineCount,fields[0]);
                    continue;
                }
                int tradeAmount;
                if (!int.TryParse(fields[1], out tradeAmount))
                {
                    Console.WriteLine("WARN: Trade amount on line {0} not a vaid integer: '{1}'",lineCount,fields[1]);
                     
                }
                decimal tradePrice;
                if (!decimal.TryParse(fields[2], out tradePrice))
                {
                    Console.WriteLine("WARN: Trade price on lie {0} not a valid decimal");
                }

                var sourceCurrencyCode = fields[0].Substring(0, 3);
                var destinationCurrencyCode = fields[0].Substring(3, 3);
                var trade = new TradeRecord
                {
                    SourceCurrency = sourceCurrencyCode,
                    DestinationCurrency = destinationCurrencyCode,
                    Lots = tradeAmount / LotSize,
                    Price = tradePrice,


                };
                trades.Add(trade);
                lineCount++;
            }

            using (var connection = new System
                .Data.SqlClient.SqlConnection(@"Data Source=SILVIU\MSSQLSERVER2017;Initial Catalog=70-461;Integrated Security=True"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction()) {

                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.inserttrade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@DestinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    
                }
                connection.Close();


            }
            Console.WriteLine("INFO:{0} trades procesed",trades.Count);
            

        }



        }
    } 
