using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DAL.Repositories
{
    public class CategoriaRepository(IDatabaseRepository databaseRepository) : ICategoriaRepository
    {
        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var query = "DELETE FROM Categorias WHERE CategoriaID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            var query = "SELECT CategoriaID as Id, Nombre FROM Categorias WHERE CategoriaID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Categoria>(query, parameters)).FirstOrDefault();
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            var query = "SELECT CategoriaID as Id, Nombre FROM Categorias";
            return await databaseRepository.GetDataByQueryAsync<Categoria>(query);

        }

        public async Task<int> InsertCategoriaAsync(Categoria categoria)
        {
            var query = "INSERT INTO Categorias (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", categoria.Nombre);

            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Categoria?> UpdateCategoriaAsync(Categoria categoria)
        {
            var query = "UPDATE Categorias SET Nombre = @Nombre WHERE CategoriaID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", categoria.Id);
            parameters.Add("@Nombre", categoria.Nombre);
            await databaseRepository.UpdateAsync<Categoria>(query, parameters);
            return categoria;
        }
    }
}
