using AutoMapper;
using Biblioteca.Entities.Dtos;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autor, AutorDto>()
            .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
            .ForMember(destination => destination.Nombre, opts => opts.MapFrom(source => source.Nombre))
            .ForMember(destination => destination.Apellido, opts => opts.MapFrom(source => source.Apellido))
            .ReverseMap();

            CreateMap<Libro, LibroDto>()
            .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
            .ForMember(destination => destination.Titulo, opts => opts.MapFrom(source => source.Titulo))
            .ReverseMap();

            CreateMap<Categoria, CategoriaDto>()
            .ForMember(destination => destination.Nombre, opts => opts.MapFrom(source => source.Nombre))
            .ReverseMap();

        }
    }
}
