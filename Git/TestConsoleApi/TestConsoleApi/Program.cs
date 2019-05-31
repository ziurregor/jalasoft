using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Model;
using TestConsoleApi.Services;

namespace TestConsoleApi
{
    class Program
    {
        private static List<Pets> pets;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("ToDos List");
            await GetPets();



        }



        public static async Task GetPets()
        {
            PetsService service = new PetsService();
            pets= await service.GetAllPets();
        }
    }
}
