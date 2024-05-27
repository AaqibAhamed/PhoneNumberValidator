using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumberValidator.Models;

namespace PhoneNumberValidator.Services
{
    public class PhoneNumberFormatter : IPhoneNumberFormatter
    {
        public string FormatPhoneNumbers(List<PhoneNumber> detectedPhoneNumbers)
        {
            StringBuilder output = new StringBuilder();


            foreach (PhoneNumber phoneNumber in detectedPhoneNumbers)
            {
                if(phoneNumber.Language == "")
                {
                    output.AppendLine($"Input Format: {phoneNumber.Format}");
                    output.AppendLine($"Output Phone Number: {phoneNumber.PhoneNumbers}");
                }

                else
                {
                    output.AppendLine($"Input Format: {phoneNumber.Format}");
                    output.AppendLine($"Input Language: {phoneNumber.Language}");
                    output.AppendLine($"Output Phone Number: {phoneNumber.PhoneNumbers}");
                }         
                //if (phoneNumber.PhoneNumbers == "" )
                //{
                //    output.AppendLine($"Input Format: {phoneNumber.Format}");
                //    output.AppendLine($"Output Phone Number: {phoneNumber.PhoneNumbers}");                    
                //    output.AppendLine($"English: Phone Number given in digits");
                //    output.AppendLine($"Hindi: फ़ोन नंबर अंकों में दिया गया है");
                //    output.AppendLine();
                //}

                //if (phoneNumber.Language == "English")
                //{
                //    output.AppendLine($"Input Format: {phoneNumber.Format}");
                //    output.AppendLine($"Input Language: {phoneNumber.Language}");
                //    output.AppendLine($"Output Phone Number: {phoneNumber.PhoneNumbers}");
   
        
                //}
                //else
                //{
                //    output.AppendLine($"Output Phone Number: {phoneNumber.PhoneNumbers}");
                //    output.AppendLine($"Input Format: {phoneNumber.Format}");
                //  //  output.AppendLine($"English: {phoneNumber.EnglishPhoneNumber}");
                //  //  output.AppendLine($"Hindi: {phoneNumber.HindiPhoneNumber}");
                //    output.AppendLine();
                //}
              
            }

            return output.ToString();
        }
    }
}
