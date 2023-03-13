// These are the necessary using statements for the program to work with the System namespace and IO classes.
using System;
using System.IO;
using System.Text.RegularExpressions;

// Declaring a new class name 'Program'
class Program
{
    // Entry point of the program
    // Declares the 'Main' method that will be executed when the program starts running
    // It accepts an array of command-line argements as 'args'
    static void Main(string[] args)
    {
        // Check whether the 'args' array has exactly one element
        // If true, it calls the 'CheckACHFile' method with the first element of the 'args' array as its argument
        if (args.Length == 1)
        {
            CheckACHFile(args[0]);
        }
        // Else, it prints a message to the console telling the user how to use the program correctly
        else
        {
            Console.WriteLine("Usage: ACHValidator.exe <file_path>");
        }
    }
    
    static void CheckACHFile(string filePath)
    {
    string contents = File.ReadAllText(filePath);

    // Define a regular expression pattern to match any character that is not ASCII, digit, or a few allowed special characters
    // string pattern = @"[^\p{IsBasicLatin}\d\s_:\.@$\=/\-\p{P}]";
    // string pattern = @"[^\w\s:\.@$\=/\-]|(?![\x00-\x7F])";
    string pattern = @"[^\p{IsBasicLatin}\d\s_:\.@$\=/\-\p{P}]|[^\w\s:\.@$\=/\-]|(?![\x00-\x7F])";

    // Use Regex.Matches to find all matches of the pattern in the contents string
    MatchCollection matches = Regex.Matches(contents, pattern);

    // Iterate over the matches and print the invalid character and its position in the file
    foreach (Match match in matches)
    {
        Console.WriteLine($"Invalid character '{match.Value}' found at position {match.Index + 1}.");
    }
}
    
}