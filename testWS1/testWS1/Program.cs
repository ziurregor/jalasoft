using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace testWS1
{
    class MainClass
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Inicio");

            //www.dneonline.com.Calculator c = new www.dneonline.com.Calculator();

            //string c1 = c.Multiply(2, 8).ToString();

            //Console.WriteLine("resiltaod"+c1);






            //brickset.com.
            //var xml = @"<ArrayOfThemes xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""https://brickset.com/api/"">
            //<themes>
            //<theme>4 Juniors</theme>
            //<setCount>24</setCount>
            //<subthemeCount>5</subthemeCount>
            //<yearFrom>2003</yearFrom>
            //<yearTo>2004</yearTo>
            //</themes>
            //</ArrayOfThemes>";
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            //var reader = new XmlTextReader(ms) { Namespaces = false };
            //var serializer = new XmlSerializer(typeof(ArrayOfThemes));

            //var result = (ArrayOfThemes)serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        sb.AppendFormat("{0}-{1},", i.ToString(), j.ToString());
            //    }
            //    
            //}


            //----------------

            Console.WriteLine("Para bricvk");
            brickset.com.BricksetAPIv2 l1 = new brickset.com.BricksetAPIv2("https://brickset.com/API/V2.ASMX");
            brickset.com.sets[] Resp = null;



            for (int i =28103; i <= 999999; i++)
                {

                try
                {
                    Resp = l1.getSet("aznc-t5lk-VFl", "", i.ToString());
                }
                catch (Exception es)
                {
                    Console.WriteLine(es);
                }
                //string Resp = l1.checkKey("aznc-t5lk-VFlC");

                //Console.WriteLine(l1.checkKey("aznc-t5lk-VFlC"));
                //manejarException(Resp);


                 if ((Resp is null) || (Resp[0].Equals("0")))
                    {// No tiene deudas
                     //BussinessException Ex = new BussinessException("01", "La cuenta " + pCuenta + " de " + Respuesta[1] + " no tiene deudas.");
                    Console.WriteLine("error");// + Resp[1]);
                    }
                    else
                    {
                        sb.AppendFormat("{0},{1}", Resp[0].number,i);
                        //sb.Remove(sb.Length - 1, 1);
                        sb.AppendLine();
                        Console.WriteLine("{0},{1}", Resp[0].number, i.ToString());
                    }
                
                System.IO.File.WriteAllText("asd.csv", sb.ToString());
            }

            



            var res = new object();

            //object[] results = new ()
            //object[];
            //{
            //            apiKey,
            //            userHash,
            //            SetID};

            //res = result.ToString();

        }
    }
    public class Themes
    {
        [XmlElement("theme")]
        public string Theme { get; set; }
        [XmlElement("setCount")]
        public string SetCount { get; set; }
        [XmlElement("subthemeCount")]

        public string SubthemeCount { get; set; }
        [XmlElement("yearFrom")]

        public string YearFrom { get; set; }
        [XmlElement("yearTo")]

        public string YearTo { get; set; }
    }

    [Serializable, XmlRoot("ArrayOfThemes")]
    public class ArrayOfThemes
    {
        [XmlElement("themes")]
        public Themes[] Themes { get; set; }
    }


    //private void manejarException(string[] Respuesta)
    //{
    //    if (Respuesta.Length == 1)
    //   {//Manejar Error
    //        string CodigoError = Respuesta[0];
    //       string MensajeError = "";
    //       switch (CodigoError)
    //       {
    //          case "FALLA":
    //              CodigoError = "01";
    //             MensajeError = "No se pudo encontrar resultados.";
    //             break;
    //         default:
    //             MensajeError = CodigoError;
    //             CodigoError = "01";
    //              break;
    //      }
    //      //throw new BussinessException(CodigoError, MensajeError);
    //  }
    // }



}