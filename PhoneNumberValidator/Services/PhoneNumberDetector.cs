using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PhoneNumberValidator.Models;

namespace PhoneNumberValidator.Services
{
    public class PhoneNumberDetector : IPhoneNumbersDetector
    {
        private readonly string[] _phoneFormats = new string[]
        {
            @"(\d{3}-\d{3}-\d{4})", // 10-digit numbers with dashes
            @"(\+\d{1,2}-\d{3}-\d{3}-\d{4})", // Numbers with country codes
            @"(\(\d{3}\) \d{3}-\d{4})", // Numbers with parentheses for area codes
            @"(\d{3} \d{3} \d{4})", // Numbers with spaces as separators
            @"(\d{10})", // 10-digit numbers
            @"(\+\d{1,2}\d{10})", // Numbers with country codes
            @"(\(\d{3}\) \d{3} \d{4})", // Numbers with parentheses for area codes
            @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|शू|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|zero|one|two|three|four|five|six|seven|eight|nine){10,}\b",
           // @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|zero|one|two|three|four|five|six|seven|eight|nine){10,}\b",
           // @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|शू|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ){10,}\b",
           // @"\b(?:\D{46}|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE)\b"

        };

        public List<PhoneNumber> DetectPhoneNumbers(string inputText)
        {
            List<PhoneNumber> detectedPhoneNumbers = new List<PhoneNumber>();

            foreach (string format in _phoneFormats)
            {
                Match match = Regex.Match(inputText, format, RegexOptions.IgnoreCase);

                while (match.Success)
                {
                    string phoneNumber = match.Value.Trim();

                    // Convert words to numbers for comparison
                    var (phoneNumberinDigit, language) = ConvertWordsToNumbers(phoneNumber);
                   // string hindiPhoneNumber = ConvertWordsToNumbers(phoneNumber);

                    if (phoneNumberinDigit != null )
                    {
                        detectedPhoneNumbers.Add(new PhoneNumber(inputText, language, phoneNumberinDigit));
                    }

                    else
                    {
                        detectedPhoneNumbers.Add(new PhoneNumber(inputText, language, ""));
                    }

                    match = match.NextMatch();
                }
            }

            return detectedPhoneNumbers;
        }

        private Dictionary<string, string> _englishNumberMap = new Dictionary<string, string>
        {
            {"zero", "0"},
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
            { "ZERO", "0" }, { "ONE", "1" }, { "TWO", "2" }, { "THREE", "3" },
            { "FOUR", "4" }, { "FIVE", "5" }, { "SIX", "6" }, { "SEVEN", "7" },
            { "EIGHT", "8" }, { "NINE", "9" }
        };

        private Dictionary<string, string> _hindiNumberMap = new Dictionary<string, string>
        {
            {"एक", "1"},
            {"दो", "2"},
            {"तीन", "3"},
            {"चार", "4"},
            {"पांच", "5"},
            {"छह", "6"},
            {"सात", "7"},
            {"आठ", "8"},
            {"नौ", "9"},
            {"शून्य", "0"}
        };

        private (string,string) ConvertWordsToNumbers(string phoneNumber)
        {
            string? englishPhoneNumber = null;
            string? hindiPhoneNumber = null;
            string language = "";

            foreach (string word in phoneNumber.Split(' '))
            {
                if (_englishNumberMap.ContainsKey(word))
                {
                    englishPhoneNumber += _englishNumberMap[word];
                    language = "English";
                }
                else if (_hindiNumberMap.ContainsKey(word))
                {
                    hindiPhoneNumber += _hindiNumberMap[word];
                    language = "Hindi";
                }
            }

            if (englishPhoneNumber != null)
            {
                return (englishPhoneNumber,language) ;
            }
            else if (hindiPhoneNumber != null)
            {
                return (hindiPhoneNumber, language);
            }
            else
            {
                return (phoneNumber, "");
            }
        }
    }
}
