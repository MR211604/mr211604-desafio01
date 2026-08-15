using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Dtos;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Services
{
    public class CategoriaService(ICategoriaRepository repository, IMapper mapper) : ICategoriaService
    {
        public async Task<List<CategoriaDto>> GetAllCategoriasAsync()
        {
            try
            {
                var result = await repository.GetCategoriasAsync();
                return mapper.Map<List<Categoria>, List<CategoriaDto>>(result);
            }
            catch (Exception e)
            {
                return new List<CategoriaDto>();
            }
        }

        public async Task<CategoriaDto?> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetCategoriaByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Categoria, CategoriaDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> InsertCategoriaAsync(CategoriaDto categoriaDto)
        {
            try
            {
                var entity = mapper.Map<CategoriaDto, Categoria>(categoriaDto);
                return await repository.InsertCategoriaAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<CategoriaDto?> UpdateCategoriaAsync(CategoriaDto categoriaDto)
        {
            try
            {
                var entity = mapper.Map<CategoriaDto, Categoria>(categoriaDto);
                var result = await repository.UpdateCategoriaAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Categoria, CategoriaDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            try
            {
                return await repository.DeleteCategoriaAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
