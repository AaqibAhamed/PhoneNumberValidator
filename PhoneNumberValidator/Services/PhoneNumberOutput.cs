using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Services
{
    public class PhoneNumberOutput : IOutputHandler
    {
        public void DisplayOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
