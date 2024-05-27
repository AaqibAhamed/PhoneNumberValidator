using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumberValidator.Models;

namespace PhoneNumberValidator.Services
{
    public interface IPhoneNumbersDetector
    {
        List<PhoneNumber> DetectPhoneNumbers(string input);
    }
}
