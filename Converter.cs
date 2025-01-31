
using System.Text;
using CustomConsole;

public class Converter
{

    private string Header { get; } = "Date,Merchant,Category,Account,Original Statement,Notes,Amount,Tags";
    private string[] MercoStrings { get; }
    private List<string> MonarchStrings { get; }

    private string _outputLocation;

    public Converter(string mercoFileLocation)
    {
        MercoStrings = File.ReadAllLines(mercoFileLocation);
        MonarchStrings = ConvertStrings(MercoStrings, Header);

        _outputLocation = CreateOutputLocation( GetDate(MonarchStrings[^1]), GetDate(MonarchStrings[1]) );


        ColoredConsole.WriteLine($"Converting \"{mercoFileLocation}\"...", ConsoleColor.Yellow);
        File.WriteAllText(_outputLocation, FinalStringBuild(MonarchStrings));

        ColoredConsole.Write("File written to ", ConsoleColor.Yellow);
        ColoredConsole.WriteLine(_outputLocation, ConsoleColor.Green);
    }
    static List<string> ConvertStrings(string[] inputStrings, string header)
    {
        List<string> output = new();
        foreach (string line in inputStrings)
        {
            output.Add(ConvertLine(line));
        }
        output[0] = header;

        return output;
    }
    static string ConvertLine(string inputLine)
    {
        string[] lineString = inputLine.Split(",");

        string date = lineString[0].Trim('\"');
        string merchant = RemoveDuplicateSpaces(lineString[4].Trim('\"'));
        const string category = "Uncategorized";
        const string account = "Merco";
        const string origStatment = "";
        const string notes = "";
        string amount = FlipSign(lineString[3].Trim('\"'));
        const string tags = "";

        return $"{date},{merchant},{category},{account},{origStatment},{notes},{amount},{tags}";
    }

    static string FlipSign(string input)
    {
        string output;
        if (input[0] == '-') output = input.TrimStart('-');
        else output = "-" + input;

        return output;
    }
    static string RemoveDuplicateSpaces(string input)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ' ' && input[i + 1] == ' ') continue;
            output.Append(input[i]);
        }

        return output.ToString();
    }
    static string FinalStringBuild(List<string> strings)
    {
        StringBuilder output = new ();
        foreach (string s in strings)
        {
            output.Append(s);
            output.Append('\n');
        }
        return output.ToString();
    }
    public string GetDate(string lineString)
    {
        return lineString.Substring(5, 5);
    }

    static private string CreateOutputLocation(string date1, string date2)
    {
        string startDate = date1;
        string endDate = date2;
        int[] split1 = Array.ConvertAll(date1.Split('-'), Convert.ToInt32);
        int[] split2 = Array.ConvertAll(date2.Split('-'), Convert.ToInt32);

        if ((split1[0] > split2[0]) || // First month is greater than second month
            ((split1[0] == split2[0]) && (split1[1] > split2[1]))) // Months match, but day 1 is greater than day 2
        {
            startDate = date2;
            endDate = date1;
        }

        return $"Monarch {startDate} to {endDate}.csv";
    }
}