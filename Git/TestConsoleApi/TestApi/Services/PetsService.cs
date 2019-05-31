using System;
using System.Collections.Generic;
using TestApi.Model;

namespace TestApi.Services
{
    public class PetsService : IPetsService
    {
        private List<Pets> pets;

        public PetsService()
        {
            this.pets = new List<Pets>()
            {
            new Pets() {
               Cod=1,
                Name="Gizmo",
                LastName="Ruiz",
                Age=2
},
            new Pets()
            {
                Cod=2,
                Name="Duke",
                LastName="Ruiz",
                Age=4

            }


            };
        }

       

        public Pets Create(Pets pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pets> GetAll()
        {
            return this.pets;
        }

        public Pets Update(int cod, Pets pet)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

       

       
    }
}
