using System;
using System.Collections.Generic;

namespace VarianceAndContravariance
{
    class Mammals { }
    class Dogs : Mammals { }

    class Program
    {
        private string texto;
        // Define the delegate.  
        public delegate Mammals HandlerMethod();

        public static Mammals MammalsHandler()
        {
            Console.WriteLine("Mamals");
            return null;
        }

        public static Dogs DogsHandler()
        {
            Console.WriteLine("dog");
            return null;
        }

        // Event handler that accepts a parameter of the EventArgs type.  
        private void MultiHandler(object sender, System.EventArgs e)
        {
            texto = System.DateTime.Now.ToString();
        }

        static void Main(string[] args)
        {
            HandlerMethod handlerMammals = MammalsHandler;
            handlerMammals();
            // Covariance enables this assignment.  
            HandlerMethod handlerDogs = DogsHandler;
            handlerDogs();
        }
    }

  
}
