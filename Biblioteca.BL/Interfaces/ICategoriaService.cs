using Biblioteca.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BL.Interfaces
{
    public interface ICategoriaService
    {
        public Task<List<CategoriaDto>> GetAllCategoriasAsync();
        public Task<CategoriaDto?> GetCategoriaByIdAsync(int id);
        public Task<int> InsertCategoriaAsync(CategoriaDto categoriaDto);
        public Task<CategoriaDto?> UpdateCategoriaAsync(CategoriaDto categoriaDto);
        public Task<bool> DeleteCategoriaAsync(int id);
    }
}
