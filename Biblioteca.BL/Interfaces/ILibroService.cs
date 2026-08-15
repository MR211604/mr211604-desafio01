using Biblioteca.Entities.Dtos;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        public Task<List<LibroDto>> GetAllLibrosAsync();
        public Task<LibroDto?> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(LibroDto libroDto);
        public Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto);
        public Task<bool> DeleteLibroAsync(int id);
    }
}
