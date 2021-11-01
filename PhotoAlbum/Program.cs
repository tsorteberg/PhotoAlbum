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
        static void Main(string[] args)
        {
            bool valid = false;

            Console.WriteLine("** Wecome to the Photo Album Viewer **");
            var albumInput = PromptUserForInput();

            while (!Validation.Sentinel(albumInput))
            {
                // Method call for input validation.
                // I could probalby work out that 'valid = Validation.Validate(albumInput)' does validataion :)
                valid = Validation.Validate(albumInput);

                if (valid)
                {
                    var apiUrl = GetUrlFromInput(albumInput);
                    var photos = JSONAPI.ReadAlbum(apiUrl);

                    if (photos != null)
                    {
                        Console.WriteLine("** Displaying Photo Album: " + albumInput + " **\n");
                        Photo.Display(photos);
                    }
                    else if (photos is null)
                    {
                        Console.WriteLine("Invalid photo album number.\n");
                    }
                }
                
                albumInput = PromptUserForInput();
            }

            NotifyUserOnProgramExit();
        }

        private static string GetUrlFromInput(string input)
        {
            return "https://jsonplaceholder.typicode.com/photos?albumId=" + input;
        }

        private static string PromptUserForInput()
        {
            Console.Write("\nPlease enter a photo album number to view (1-100) or 'x' to exit: ");
            var albumInput = Console.ReadLine();
            Console.WriteLine("");
            return albumInput;
        }

        private static void NotifyUserOnProgramExit()
        {
            Console.WriteLine("The Program has exited.\n");
            Console.WriteLine("Thank you for using the Photo Album Viewer!");
        }
    }
}
