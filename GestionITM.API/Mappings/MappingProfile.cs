using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    // Configura los mapeos entre entidades y DTOs
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteCreateDto, Estudiante>();
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorCreateDto, Profesor>();
          //CreateMap <Curso, CursoDto>();
          //CreateMap<CursoCreateDto, Curso>();
            CreateMap<Matricula, MatriculaDto>();
            CreateMap<MatriculaCreateDto, Matricula>();
        }
    }
}


