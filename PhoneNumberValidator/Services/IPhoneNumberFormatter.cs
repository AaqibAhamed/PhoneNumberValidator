using PhoneNumberValidator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Services
{
    public interface IPhoneNumberFormatter
    {
        string FormatPhoneNumbers(List<PhoneNumber> detectedPhoneNumbers);
    }
}
