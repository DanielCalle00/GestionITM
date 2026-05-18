using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Dtos;
using GestionITM.Infrastructure.Services;
using AutoMapper;
using GestionITM.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GestionITM.Tests
{
    public class ProfesorServiceTests
    {
        // Prueba 1: El camino triste (validar que falle cuando la especialidad es vacía)
        [Fact]
        public async Task RegistrarProfesor_ConEspecialidadVacia_DebeLanzarExcepcion()
        {
            // 1. Arrange (Preparar el escenario)
            var mockRepository = new Mock<IProfesorRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<ProfesorService>>();

            // Configuramos el mapper para devolver un objeto Profesor base
            mockMapper
                .Setup(m => m.Map<Profesor>(It.IsAny<ProfesorCreateDto>()))
                .Returns(new Profesor());

            var profesorService = new ProfesorService(mockRepository.Object, mockMapper.Object, mockLogger.Object);

            var dtomalo = new ProfesorCreateDto
            {
                Nombre = "Juan Perez",
                Email = "juan@itm.edu.co",
                Especialidad = "" // Especialidad vacía para forzar el error
            };

            // 2. Act & Assert
            // Capturamos la excepción y verificamos que el mensaje contenga la palabra clave
            // Usamos ToLower() y Contains para que sea una prueba robusta ante cambios menores de texto
            var excepcion = await Assert.ThrowsAsync<Exception>(() => profesorService.RegistrarProfesorAsync(dtomalo));

            Assert.Contains("especialidad", excepcion.Message.ToLower());
        }

        // Prueba 2: El camino feliz (Validar que funcione con datos correctos)
        [Fact]
        public async Task RegistrarProfesor_DatosCorrectos_DebeLlamarAlRepositorio()
        {
            // 1. Arrange
            var mockRepository = new Mock<IProfesorRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<ProfesorService>>();

            mockMapper
                .Setup(m => m.Map<Profesor>(It.IsAny<ProfesorCreateDto>()))
                .Returns(new Profesor());

            var profesorService = new ProfesorService(mockRepository.Object, mockMapper.Object, mockLogger.Object);

            var dtobien = new ProfesorCreateDto
            {
                Nombre = "Ana",
                Email = "ana@itm.edu.co",
                Especialidad = "Arquitectura"
            };

            // 2. Act
            await profesorService.RegistrarProfesorAsync(dtobien);

            // 3. Assert
            // Verificamos que se haya intentado guardar en la base de datos exactamente una vez
            mockRepository.Verify(x => x.AgregarAsync(It.IsAny<Profesor>()), Times.Once);
        }
    }
}