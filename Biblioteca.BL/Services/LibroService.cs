using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Dtos;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Services
{
    public class LibroService(ILibroRepository repository, IMapper mapper) : ILibroService
    {
        public async Task<List<LibroDto>> GetAllLibrosAsync()
        {
            try
            {
                var result = await repository.GetLibrosAsync();
                return mapper.Map<List<Libro>, List<LibroDto>>(result);
            }
            catch (Exception e)
            {
                return new List<LibroDto>();
            }
        }
        public async Task<LibroDto?> GetLibroByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetLibroByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Libro, LibroDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> InsertLibroAsync(LibroDto libroDto)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(libroDto);
                return await repository.InsertLibroAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(libroDto);
                var result = await repository.UpdateLibroAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Libro, LibroDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> DeleteLibroAsync(int id)
        {
            try
            {
                return await repository.DeleteLibroAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
