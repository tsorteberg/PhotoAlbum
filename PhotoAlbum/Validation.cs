/***************************************************************
* Name        : Validation.cs
* Author      : Tom Sorteberg
* Created     : 11/01/2021
* Version     : 1.0
* OS          : Windows 10 Pro, Visual Studio Community 2019
* Copyright   : This is my own original work.
* Description : A basic console application that accesses a web API.    
***************************************************************/

using System;

namespace PhotoAlbum
{
    public class Validation
    {
        // Class constants declaration and initialization.
        private const int lowAlbumID = 1;
        private const int highAlbumID = 100;

        /// <summary>
        /// This method validates input and verifies that it is a integer and within acceptable range.
        /// </summary>
        /// <param name="input">The input string that needs validation.</param>
        /// <returns>Returns a boolean value.  True if successful; otherwise, false.</returns>
        public static bool Validate(string input)
        {
            // Local variable declaration and initialization.
            bool valid = false;

            // Execute only if not a sentinel value.
            if (Sentinel(input) == false)
            {
                // Try catch block to determine if entry is an integer.
                try
                {
                    int result = Int32.Parse(input);

                    // Verify that integer is within bounds.
                    if (result >= lowAlbumID && result <= highAlbumID)
                    {
                        valid = true;
                    }
                    else if (result < 1 || result > 100)
                    {
                        // Display an error message.
                        Console.WriteLine("Invalid photo album number.\n");
                    }
                }
                // If FormatException is encountered, display an error message.
                catch (FormatException)
                {
                    // Display an error message.
                    Console.WriteLine("Invalid photo album number.\n");
                }
            }

            // Return statement.
            return valid;
        }

        /// <summary>
        /// This method determines if a sentinel value has been entered.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>Returns a boolean value.  True if sentinel; otherwise, false.</returns>
        public static bool Sentinel(string input)
        {
            // Local variable declaration and initialization.
            bool sentinel = false;

            // If 'x' or 'X' sentinel value has been entered.
            if (input == "x" || input == "X")
            {
                sentinel = true;
            }

            // Return statement.
            return sentinel;
        }
    }
}
