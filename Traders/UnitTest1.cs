using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Traders
{
    public class GoldMaster
    {
        private static string CharacterizationTestOutput = Path.Combine("../../../", "CharacterizationTests/bim/Debug/");


        public void OutputStillMatchesCharacterization() {
            var inputsAndExpectations = new Dictionary<string, string>()
            {
                {"empty-fie.txt","expectation-empty-file.text" },
                {"one-field.txt" ,"expectation-one-field.txt" },
                {"malformed-currency-pair.txt" ,"expectation-malformed-currency-pair.txt" },
                {"trade-volume-invalid.txt" ,"expectation-trade-volume-invalid.txt" },
                {"trade-amount-invalid.txt" ,"expectation-trade-amount-invalid.txt" },
                {"correct-format.txt" ,"expectation-correct-format.txt" }
            };

            var originalConsoleOut = Console.

        }




    }
} 
