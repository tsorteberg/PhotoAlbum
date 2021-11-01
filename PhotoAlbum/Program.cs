/***************************************************************
* Name        : Program.cs
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
    class Program
    {
        // Main method.
        static void Main(string[] args)
        {
            // Variable declaration and initialization.
            bool loop = true;
            bool valid = false;

            // Output program header.
            Console.WriteLine("** Wecome to the Photo Album Viewer **");

            // Main program loop.
            while (loop) {

                // Prompt to enter album number.
                Console.Write("\nPlease enter a photo album number to view (1-100) or 'x' to exit: ");
                string albumInput = Console.ReadLine();
                Console.WriteLine("");

                // Method call to verify if sentinel value was entered.  If true, then exit main loop.
                if (Validation.Sentinel(albumInput)) {
                    loop = false;
                }

                // Method call for input validation.
                valid = Validation.Validate(albumInput);

                // Execute only if input is valid.
                if (valid)
                {
                    // Update url based on input.
                    string apiUrl = "https://jsonplaceholder.typicode.com/photos?albumId=" + albumInput;

                    // Method call to retrieve JSON data from URL.
                    var photos = JSONAPI.ReadAlbum(apiUrl);

                    // Only call method if photos array is not null.
                    if (photos != null)
                    {
                        // Diplay photo album header.
                        Console.WriteLine("** Displaying Photo Album: " + albumInput + " **\n");
                        // Method call to display Photo objects.
                        Photo.Display(photos);
                    }
                    // If object is null, display error message.
                    else if (photos is null)
                    {
                        // Display error message.
                        Console.WriteLine("Invalid photo album number.\n");
                    }
                }
            }

            // Notify user on program exit.
            Console.WriteLine("The Program has exited.\n");
            Console.WriteLine("Thank you for using the Photo Album Viewer!");
        }
    }
}
