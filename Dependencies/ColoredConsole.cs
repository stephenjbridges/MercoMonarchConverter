namespace CustomConsole
{
    public static class ColoredConsole
    {
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
        public static string? Prompt(string question, ConsoleColor promptColor = ConsoleColor.Gray, ConsoleColor responseColor = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = promptColor;
            Console.Write(question + " ");
            Console.ForegroundColor = responseColor;
            string? input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static int OptionsMenu(string? category, string[] options, string promptQuestion,
            ConsoleColor optionsColor = ConsoleColor.Cyan, ConsoleColor indexColor  = ConsoleColor.Yellow, ConsoleColor promptColor = ConsoleColor.Gray)
        {
            bool validChoice = false;
            int choiceIndex = 1;
            while (!validChoice)
            {
                if (category is not null) Write($"{category}: ", indexColor);

                for (int i = 0; i < options.Length; i++)
                {
                    Write($"[{i + 1}]", indexColor);
                    Write($" {options[i]} ", optionsColor);
                }
                Console.WriteLine();
                string? input = Prompt(promptQuestion, promptColor, indexColor);

                bool isInteger = int.TryParse(input, out choiceIndex);
                bool withinBounds = choiceIndex > 0 && choiceIndex <= options.Length;

                validChoice = isInteger && withinBounds;

                if (!validChoice)
                {
                    if (!withinBounds) Console.WriteLine("That choice wasn't a listed option, try again.\n");
                    else Console.WriteLine("That input didn't seem right... try again.\n");
                }
            }

            return choiceIndex - 1;
        }
    }
}
