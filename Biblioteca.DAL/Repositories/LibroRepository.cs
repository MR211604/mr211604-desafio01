using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Models;
using Dapper;

namespace Biblioteca.DAL.Repositories
{
    public class LibroRepository(IDatabaseRepository databaseRepository) : ILibroRepository
    {
        public async Task<List<Libro>> GetLibrosAsync()
        {
            var query = "SELECT LibroID as Id, Titulo, FechaPublicacion, AutorId, CategoriaId FROM Libros";
            return await databaseRepository.GetDataByQueryAsync<Libro>(query);
        }
        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            var query = "SELECT LibroID as Id, Titulo, FechaPublicacion, AutorId, CategoriaId FROM Libros WHERE LibroID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters)).FirstOrDefault();
        }
        public async Task<int> InsertLibroAsync(Libro libro)
        {
            var query = "INSERT INTO Libros (Titulo, AutorId, CategoriaId, FechaPublicacion) VALUES (@Titulo, @AutorId, @CategoriaId, @FechaPublicacion); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@AutorId", libro.AutorId);
            parameters.Add("@CategoriaId", libro.CategoriaId);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            return await databaseRepository.InsertAsync(query, parameters);
        }
        public async Task<Libro?> UpdateLibroAsync(Libro libro)
        {
            var query = "UPDATE Libros SET Titulo = @Titulo, AutorId = @AutorId, CategoriaId = @CategoriaId, FechaPublicacion = @FechaPublicacion WHERE LibroID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.Id);
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@AutorId", libro.AutorId);
            parameters.Add("@CategoriaId", libro.CategoriaId);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            await databaseRepository.UpdateAsync<Libro>(query, parameters);
            return libro;
        }
        public async Task<bool> DeleteLibroAsync(int id)
        {
            var query = "DELETE FROM Libros WHERE LibroID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
