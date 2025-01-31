# MercoMonarchConverter
A simple console tool to convert .csv files downloaded from Merco Credit Union to the expected format for Monarch budgeting software.

How to use:
1. Download your transactions from Merco's credit card website, and optionally rename the file.
2. Place the executable and Transactions.csv file into the same directory.
3. Run the executable, and input the file name when prompted.
4. You should now have a new .csv file called "Monarch [mm-dd] to [mm-dd].csv"

Notes:
- If you press Enter without inputting a name, it will default to "Transactions.csv" (which is the default name from Merco)
- If you type in the file name, but forget to add the ".csv" extension, it will auto-include it for you.
- Currently, the program only executes once before terminating, which is fine for my use-case.
    -- If you need to batch convert, I recommend combining multiple .csv files into one larger file
    -- It is also lightweight enough that you should be able to reopen it quickly.
