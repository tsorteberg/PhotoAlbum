/***************************************************************
* Name        : JSONAPI.cs
* Author      : Tom Sorteberg
* Created     : 11/01/2021
* Version     : 1.0
* OS          : Windows 10 Pro, Visual Studio Community 2019
* Copyright   : This is my own original work.
* Description : A basic console application that accesses a web API.       
***************************************************************/

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace PhotoAlbum
{
    public class JSONAPI
    {
        /// <summary>
        /// This method retrives JSON data from an API and populates that data into an array of Photo objects.
        /// </summary>
        /// <param name="apiUrl">The string of the URL of the API to retrieve JSON data.</param>
        /// <returns>Returns an array of Photo objects if successful or a null object if unsuccessful.</returns>
        public static Photo[] ReadAlbum(string apiUrl)
        {
            // Send the web request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            // Declare HttpWebResponse object.
            HttpWebResponse response;

            // Try / Catch block to handle WebException.
            try
            {
                // Create the response stream.
                response = (HttpWebResponse)request.GetResponse();
                // Create the read stream.
                Stream responseStream = response.GetResponseStream();
                // Setup the stream reader.
                StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                // Convert to stream.
                string json = readerStream.ReadToEnd();
                // Close the stream.
                readerStream.Close();
                // Convert to an array of Root objects.
                Photo[] deserializedObjects = JsonConvert.DeserializeObject<Photo[]>(json);
                // Return statement.
                return deserializedObjects;
            }
            // Display an error and return a null object if a WebException is encountered.
            catch (WebException)
            {
                Console.WriteLine("Invalid URL or no response received from the API server. \n");
                return null;
            }
        }
    }
}
