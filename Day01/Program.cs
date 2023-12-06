/////////////////////////
// First puzzle for Advent of Code.
// Objective:
// - Take an input file containing strings of letters and numbers.
// - You need to find the first and last number in each string.
// - Combine the two numbers to create a single 2 digit number
//   e.g 1abc2abc gives 1 and 2, concatenate them to make 12.
//       1abc2abc3 gives 1 and 3, which creates 13
// - You then need to sum all these numbers to give the final code
//////////////////////////

using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Security.Claims;


class Decoder
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        
        var calibrationStrings = Decoder.ReadFileContents("..\\..\\..\\CalibrationDocument.txt");
        var calibrationDigitsList = Decoder.GetCalibrationDigits(calibrationStrings);
        var calibrationDigitsSum = Decoder.GetCalibrationValuesSum(calibrationDigitsList);
        
        Console.WriteLine("Sum of all digits found in calibration strings: " + calibrationDigitsSum);
    }

    /// <summary>
    /// Reads all strings in specified filepath
    /// </summary>
    /// <param name="filepath">Path of txt file containing strings</param>
    /// <returns>List of strings containing each line in the text file</returns>
    private static List<string> ReadFileContents(string filepath)
    {

        Console.WriteLine("File to read is at path: " + filepath);
        var fileStrings = File.ReadAllLines(filepath);
        var calibrationStrings = new List<string>(fileStrings);

        return calibrationStrings;
    }

    /// <summary>
    /// Takes the list of strings, passes them to be decoded to return digits
    /// </summary>
    /// <param name="calibrationStrings">List of strings containing strings to decode</param>
    /// <returns>List of all 2 digit numbers found in decoded strings</returns>
    private static List<int> GetCalibrationDigits(List<string> calibrationStrings)
    {
        var calibrationValues = new List<int>();
        
        for(var i = 0; i < calibrationStrings.Count; i++)
        {
            calibrationValues.Add(DecodeCalibrationString(calibrationStrings[i]));
        }
        
        return calibrationValues;
    }

    /// <summary>
    /// Takes an individual string, puts all the digits found into a list
    /// then takes the first and last entry in the list and adds them together.
    /// </summary>
    /// <param name="calibrationString">The string to decode</param>
    /// <returns>The decoded 2 digit number</returns>
    private static int DecodeCalibrationString(string calibrationString)
    {
        // Create list for found digits to be store
        var listOfDigits = new List<char>();
        string calibrationDig;
        
        // Iterate through each char in string
        for(var i = 0; i < calibrationString.Length; i++)
        {
            // Store digit in list
            if (char.IsDigit(calibrationString[i]))
            {
                listOfDigits.Add(calibrationString[i]);
            }
        }

        // Concatenate the first and last digit to get the 2 digit number
        if (listOfDigits.Count > 1)
        {
           calibrationDig = listOfDigits[0].ToString() + listOfDigits.Last().ToString();
        }
        else
        {
            calibrationDig = listOfDigits[0].ToString() + listOfDigits[0].ToString();
        }
        
        // Convert to int and return
        return Int32.Parse(calibrationDig);
    }

    /// <summary>
    /// Sums all the digits in the calibrationValuesList
    /// </summary>
    /// <param name="calibrationValuesList">A list of all decoded numbers</param>
    /// <returns>Int containing the final sum of all decoded numbers</returns>
    private static int GetCalibrationValuesSum(List<int> calibrationValuesList)
    {
        var sum = calibrationValuesList.Sum();
        return sum;
    }
}