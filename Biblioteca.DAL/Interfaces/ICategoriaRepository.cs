using Biblioteca.Entities.Models;
namespace Biblioteca.DAL.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task<List<Categoria>> GetCategoriasAsync();
        public Task<Categoria?> GetCategoriaByIdAsync(int id);
        public Task<int> InsertCategoriaAsync(Categoria categoria);
        public Task<Categoria?> UpdateCategoriaAsync(Categoria categoria);
        public Task<bool> DeleteCategoriaAsync(int id);
    }
}
