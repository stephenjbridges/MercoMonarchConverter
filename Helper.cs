using CustomConsole;


internal static class Helper
{
    private readonly static string introMsg =
        "#########################################################" +
        "\nWelcome to Stephen's .csv converter for Merco to Monarch!" +
        "\nTo use, please download your recent transactions from" +
        "\nMerco's credit card website, then edit the .csv file to" +
        "\nonly include the transactions you wish to import. Then," +
        "\nplace the edited file into the directory of this .exe." +
        "\n#########################################################\n";
    public static void IntroMessage()
    {
        ColoredConsole.WriteLine(introMsg, ConsoleColor.DarkGreen);
    }
}