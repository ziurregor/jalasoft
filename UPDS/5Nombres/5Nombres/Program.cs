using System;

namespace _5Nombres
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Console.WriteLine("Introducir N:");
            int n =Convert.ToInt32 (Console.ReadLine());
            String[] a;
            a = new String[n];
            for (int i = 0; i < n; i++)
            {
                a[i]=Console.ReadLine();
            }

            Console.WriteLine("nombre a buscar");
            string nombreBusca = Console.ReadLine();
            bool sw = false;
            for (int i = 0; i < n; i++)
            {
                if (a[i].Equals(nombreBusca))
                {
                    sw = true;
                    
                }
                
            }

            if (sw)
            {
                Console.WriteLine("Nombre encontrado");
            }
            else
            {
                Console.WriteLine("Nombre no existe");
            }

        }
    }
}
