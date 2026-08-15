using Biblioteca.Entities.Dtos;

namespace Biblioteca.BL.Interfaces
{
    public interface IAutorService
    {
        public Task<List<AutorDto>> GetAllAutoresAsync();
        public Task<AutorDto?> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(AutorDto autorDto);
        public Task<AutorDto?> UpdateAutorAsync(AutorDto autorDto);
        public Task<bool> DeleteAutorAsync(int id);
    }
}
