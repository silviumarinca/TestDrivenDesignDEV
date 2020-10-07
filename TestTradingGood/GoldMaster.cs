using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TradeProcessor;
namespace TestTradingGood
{
    public class GoldMaster
    {
        private static string CharacterizationTestOutput = Path.Combine("../../../", "CharacterizationTests/bim/Debug/");


        public void OutputStillMatchesCharacterization()
        {
            var inputsAndExpectations = new Dictionary<string, string>()
            {
                {"empty-fie.txt","expectation-empty-file.text" },
                {"one-field.txt" ,"expectation-one-field.txt" },
                {"malformed-currency-pair.txt" ,"expectation-malformed-currency-pair.txt" },
                {"trade-volume-invalid.txt" ,"expectation-trade-volume-invalid.txt" },
                {"trade-amount-invalid.txt" ,"expectation-trade-amount-invalid.txt" },
                {"correct-format.txt" ,"expectation-correct-format.txt" }
            };

            var originalConsoleOut = Console.Out;
            foreach (var pair in inputsAndExpectations)
            {
                var input = typeof(GoldMaster).Assembly.GetManifestResourceStream(typeof(GoldMaster), pair.Key);

                var expectation = File.ReadAllText(Path.Combine(CharacterizationTestOutput, pair.Value));
                string actual = null;
                using (var memoryStream = new MemoryStream())
                {

                    using (var streamwriter = new StreamWriter(memoryStream))
                    {
                        Console.SetOut(streamwriter);
                        var tradeProcessor = new TradeProcessor.TradeProcessor();
                        tradeProcessor.ProcessTrades(input);
                        streamwriter.Flush();
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        actual = new StreamReader(memoryStream).ReadToEnd();


                    }
                    Assert.AreEqual(expectation, actual);


                }



            }

        }
    }
}
