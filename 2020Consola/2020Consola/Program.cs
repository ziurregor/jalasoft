using System;
using System.IO;
using System.Net;

namespace _2020Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("Console.WriteLine("Hello World!");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/todo"); //url);


            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string text = reader.ReadToEnd();

            Console.WriteLine((text));
            Console.Read();

        }
    }
}
