using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Models;
using Dapper;

namespace Biblioteca.DAL.Repositories
{
    public class AutorRepository(IDatabaseRepository databaseRepository) : IAutorRepository
    {
        public async Task<List<Autor>> GetAutoresAsync()
        {
            var query = "SELECT AutorID as Id, Nombre, Apellido FROM Autores";
            return await databaseRepository.GetDataByQueryAsync<Autor>(query);
        }


        public async Task<Autor?> GetAutorByIdAsync(int id)
        {
            var query = "SELECT AutorID as Id, Nombre, Apellido FROM Autores WHERE AutorID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Autor>(query, parameters)).FirstOrDefault();
        }


        public async Task<int> InsertAutorAsync(Autor autor)
        {
            var query = "INSERT INTO Autores (Nombre, Apellido) VALUES (@Nombre, @Apellido); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", autor.Nombre);
            parameters.Add("@Apellido", autor.Apellido);

            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Autor?> UpdateAutorAsync(Autor autor)
        {
            var query = "UPDATE Autores SET Nombre = @Nombre, Apellido = @Apellido WHERE AutorID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", autor.Id);
            parameters.Add("@Nombre", autor.Nombre);
            parameters.Add("@Apellido", autor.Apellido);
            await databaseRepository.UpdateAsync<Autor>(query, parameters);
            return autor;
        }
        public async Task<bool> DeleteAutorAsync(int id)
        {
            var query = "DELETE FROM Autores WHERE AutorID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }

    }
}
