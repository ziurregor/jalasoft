using System;
using System.Net;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Newtonsoft.Json.Linq;
//using slnGateway.Integracion.Entidades;
//using slnGateway.Integracion.Entidades.Segiridad;



namespace wsRest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //string url = "https://jsonplaceholder.typicode.com/todos/1";

            //var json = new WebClient().DownloadString(url);
            //dynamic m = JsonConvert.DeserializeObject(json);


            //Console.WriteLine("Hello World!"+json.ToString());

            //foreach (var i in m)
            //Console.WriteLine(i);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/todos/1"); //url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            ////var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            ///using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            ///{
            /// var result = streamReader.ReadToEnd();
            //return result;
            ///var vResponse = JsonConvert.DeserializeObject(result);
            ///}
            string text = reader.ReadToEnd();

            Console.WriteLine((text));
            Console.Read();

            // var vResult = InstatiateProxy(TPropertiesCRE.Operacion("Conectar", pUsuario, pPassword));
            // vResponse = JsonConvert.DeserializeObject<ConexionBean>(vResult);

            //string vURL = TPropertiesCRE.Operacion("Cuentas", pUsuario, pPassword);
            //vURL = string.Format("{0}/{1}/{2}/0", vURL, (int)pServicio, pCriterio);
            //var vResult = InstatiateProxy(vURL);
            //vResponse = JsonConvert.DeserializeObject<SalidaCuentasBean>(vResult);
            //return vResponse;



        }
    }
}
