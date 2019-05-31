using System;
using System.Web;
using System.Web.UI;

using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
//using System.Windows.Forms;
//using Core;

namespace wswf
{

    public partial class Default : System.Web.UI.Page
    {
        public void button1Clicked(object sender, EventArgs args)
        {
            button1.Text = "You clicked me";



            //throw new NotImplementedException();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json; charset=utf-8"));
            var response = client.GetAsync(client.BaseAddress + "/todos/1").Result;
            var data = response.Content.ReadAsStringAsync().Result;
        }
    }
}
