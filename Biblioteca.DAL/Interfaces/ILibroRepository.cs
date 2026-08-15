using Biblioteca.Entities.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface ILibroRepository
    {
        public Task<List<Libro>> GetLibrosAsync();
        public Task<Libro?> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(Libro libro);
        public Task<Libro?> UpdateLibroAsync(Libro libro);
        public Task<bool> DeleteLibroAsync(int id);
    }
}
