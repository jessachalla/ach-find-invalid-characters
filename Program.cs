// These are the necessary using statements for the program to work with the System namespace and IO classes.
// Imports the System namespace
using System;
// Imports the System.IO namespace
using System.IO;
// Imports the System.Text.RegularExpressions namespace, which provides regular expression support for .NET Framework applications
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
    
    // This declares the 'CheckACHFile' method, which accepts a string parameter named 'filePath'
    static void CheckACHFile(string filePath)
    {
        
        // This reads the entire contents of the file specified by the 'filePath' parameter
        // and stores it as a string in the 'contents' variable
        string contents = File.ReadAllText(filePath);

        // Define a regular expression pattern to match any character that is not ASCII, digit, or a few allowed special characters
        // string pattern = @"[^\p{IsBasicLatin}\d\s_:\.@$\=/\-\p{P}]";
        // string pattern = @"[^\w\s:\.@$\=/\-]|(?![\x00-\x7F])";
        string pattern = @"[^\p{IsBasicLatin}\d\s_:\.@$\=/\-\p{P}]|[^\w\s:\.@$\=/\-]|(?![\x00-\x7F])";

        // Use Regex.Matches to find all matches of the pattern in the contents string
        // MatchCollection is a .NET Framework class that represents the results of a regular expression pattern match
        // MatchCollection provides a collection of 'Match' objects that represent each of these matches
        MatchCollection matches = Regex.Matches(contents, pattern);

        // Iterate over the matches and print the invalid character and its position in the file
        // Match is a .NET Framework class that represents a single match of a regular expression pattern in a string
        // Match provides properties and methods for accessing and manipulating the matched substing
        foreach (Match match in matches)
        {
            Console.WriteLine($"Invalid character '{match.Value}' found at position {match.Index + 1}.");
        }
    }
    
}
// In the console, type this:
// dotnet run invalid-chars.ach
