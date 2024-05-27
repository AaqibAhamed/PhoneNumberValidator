namespace PhoneNumberValidator.Models
{
    public class PhoneNumber
    {
        public string PhoneNumbers { get; set; }
        public string Language { get; set; }
        //public string HindiPhoneNumber { get; set; }
        public string Format { get; set; }

        public PhoneNumber(string input,  string language, string phoneNumberinDigit)
        {
            PhoneNumbers = phoneNumberinDigit;
            Language = language;

           // EnglishPhoneNumber = englishPhoneNumber;
          //  HindiPhoneNumber = hindiPhoneNumber;

            // Determine the format of the phone number
            if (input.StartsWith('+') )
            {
                Format = "Numbers with country codes";
            }
            else if (input.StartsWith('('))
            {
                Format = "Numbers with parentheses for area codes";
            }
            else if(input.Any(c => Char.IsLetter(c)))
            {
                Format = "Numbers in Engliah alphabet ";
            }
            else if (input.Contains('-') )
            {
                Format = "10-digit numbers with dashes as separators";
               
            }
            else if (input.Contains(' '))
            {
                Format = "10-digit numbers with spaces as separators";

            }
            else
            {
                Format = "10-digit numbers";
            }
        }
    }
}