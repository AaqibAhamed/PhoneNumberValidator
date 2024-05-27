using PhoneNumberValidator.Models;
using PhoneNumberValidator.Services;

IInputHandler inputHandler = new PhoneNumberInput();
IPhoneNumbersDetector detector = new PhoneNumberDetector();
IPhoneNumberFormatter outputFormatter = new PhoneNumberFormatter();
//IOutputHandler outputHandler = new PhoneNumberOutput();

try
{
    string input = inputHandler.GetInput();

    Console.WriteLine("input---  "+ input);

    List<PhoneNumber> detectedNumbers = detector.DetectPhoneNumbers(input);

    Console.WriteLine("detectedNumbers Count  ----  " + detectedNumbers.Count());

    var output = outputFormatter.FormatPhoneNumbers(detectedNumbers);

    // outputHandler.DisplayOutput(output);

    Console.WriteLine("output ---  "+ output);
    Console.ReadLine();


}
catch (Exception ex)
{
    ErrorHandler.Handle(ex);
}
