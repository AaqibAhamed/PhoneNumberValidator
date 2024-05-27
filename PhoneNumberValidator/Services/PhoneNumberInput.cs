using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Services
{
    public class PhoneNumberInput : IInputHandler
    {
        public string GetInput()
        {
            Console.WriteLine("Enter your input:");
            return Console.ReadLine();
        }
    }
}
