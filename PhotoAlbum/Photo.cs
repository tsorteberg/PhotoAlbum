/***************************************************************
* Name        : Photo.cs
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
    public class Photo
    {
        // Properties.
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="albumId">int</param>
        /// <param name="id">int</param>
        /// <param name="title">string</param>
        /// <param name="url">string</param>
        /// <param name="thumbnailUrl">string</param>
        public Photo(int albumId, int id, string title, string url, string thumbnailUrl)
        {
            this.albumId = albumId;
            this.id = id;
            this.title = title;
            this.url = url;
            this.thumbnailUrl = thumbnailUrl;
        }

        /// <summary>
        /// This method displays an array of Photo objects, including the Photo ID and Title attributes of the Photo class.
        /// </summary>
        /// <param name="photos">Photo array object type.</param>
        public static void Display(Photo[] photos)
        {
            // Display error if array is empty.
            if (photos.Length == 0)
            {
                Console.WriteLine("Invalid photo album number.\n");
            }
            // Display photo objects if array is populated.
            else if (photos.Length != 0)
            {
                foreach (Photo photo in photos)
                {
                    Console.WriteLine("* Photo ID: " + photo.id + " * Title: " + photo.title);
                }
            }
        }
    }
}
