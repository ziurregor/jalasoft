using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Model;



namespace TestConsoleApi.Services
{
    class PetsService : HttpService
    {
        public PetsService()
        {
        }

        public async Task<List<Pets>> GetAllPets()
        {
            List<Pets> Pets;
            Pets = await Get<List<Pets>>(path: $"{baseUrl}/pets");
            return Pets;
        }


       
    }
}
