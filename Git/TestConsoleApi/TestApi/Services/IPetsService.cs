using System;
using System.Collections.Generic;
using Pets;
using TestApi.Model;

namespace TestApi.Services
{
    public interface IPetsService
    {
        IEnumerable<Pets> GetAll();
        Pets Create(Pets pet);
        Pets Update(int cod, Pets pet);
        
        void Delete(int cod);
    }
}
