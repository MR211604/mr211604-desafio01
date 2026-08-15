using Biblioteca.Entities.Models;
using System;
namespace Biblioteca.DAL.Interfaces
{
    public interface IAutorRepository
    {
        public Task<List<Autor>> GetAutoresAsync();
        public Task<Autor?> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(Autor autor);
        public Task<Autor?> UpdateAutorAsync(Autor autor);
        public Task<bool> DeleteAutorAsync(int id);
    }
}
