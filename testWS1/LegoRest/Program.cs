using System;
using System.Net;
//using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

using System.IO;

//using Newtonsoft.Json.Linq;
namespace LegoRest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://rebrickable.com/api/v3/lego/sets/9398-1/parts/?page=12&page_size=12"); //url);

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
