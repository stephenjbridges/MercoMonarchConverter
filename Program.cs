
using System.Text.RegularExpressions;
using CustomConsole;

Regex regex = new Regex(@"\.(?i)csv(?-i)$");

Helper.IntroMessage();

bool loop = false;
do
{
    loop = false;
    string? input = ColoredConsole.Prompt("Please input the Merco file name (defaults to \"Transactions.csv\" if blank): ");
    if (input is null)
    {
        loop = true;
        ColoredConsole.ErrorMessage("Your input was null... try again.");
        continue;
    }
    else if (input == string.Empty) input = "Transactions.csv";
    else if (input is not null && !regex.IsMatch(input)) input += ".csv";

    try
    {
        Converter converter = new(input);
    }
    catch (FileNotFoundException)
    {
        ColoredConsole.ErrorMessage("Oops, didn't find that file. Try again.\n");
        loop = true;
    }
} while (loop);

Console.WriteLine("\nProgram is finished. Press any key to close this window.");

Console.ReadKey();
