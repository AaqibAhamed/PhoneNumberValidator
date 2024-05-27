using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Services
{
    public class ErrorHandler
    {
        public static void Handle(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
