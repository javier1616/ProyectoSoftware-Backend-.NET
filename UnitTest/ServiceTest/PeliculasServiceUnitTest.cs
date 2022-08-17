using System;
using Xunit;
using PS.Application.Services;
using PS.Domain.Queries;
using Moq;
using PS.Domain.Commands;
using PS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PeliculasServiceUnitTest
{
    public class PeliculasServiceUnitTest
    {       

        [Fact]       
        public void ValidateGetPeliculaById()
        {

            Peliculas pelicula1 = new Peliculas
            {
                PeliculaId = 1,
                Titulo = "title1",
                Poster = "poster1",
                Sinopsis = "Sinopsis1",
                Trailer = "Trailer1"
            };

            //Moq library
            var mockPeliculasQueries = new Mock<IPeliculasQueries>();
            var mockGenericsRepository = new Mock<IGenericsRepository>();

            mockPeliculasQueries.Setup(x => x.GetPeliculaById(1)).Returns(pelicula1);
           
            
            PeliculasService peliculasService = new PeliculasService(mockGenericsRepository.Object,mockPeliculasQueries.Object);
            

            var result = peliculasService.GetPeliculaById(1);

            Assert.IsType<PeliculasDTO>(result);

            var resultNull = peliculasService.GetPeliculaById(20);

            Assert.IsType<PeliculasDTO>(result);
        }

        [Fact]
        public void ValidateGetAllPeliculas()
        {

            List<Peliculas> listaDePeliculas = new List<Peliculas>();

            //Moq library
            var mockPeliculasQueries = new Mock<IPeliculasQueries>();
            var mockGenericsRepository = new Mock<IGenericsRepository>();

            mockPeliculasQueries.Setup(x => x.GetAllPeliculas()).Returns(listaDePeliculas);


            PeliculasService peliculasService = new PeliculasService(mockGenericsRepository.Object, mockPeliculasQueries.Object);


            var result = peliculasService.GetAllPeliculas();

            Assert.IsType<List<Peliculas>>(result);
        }

        [Fact]
        public void ValidateUpdatePeliculas()
        {
            Peliculas pelicula = new Peliculas
            {
                PeliculaId = 1,
                Titulo = "title1",
                Poster = "poster1",
                Sinopsis = "Sinopsis1",
                Trailer = "Trailer1"
            };

            PeliculasDTO peliculaDTO = new PeliculasDTO
            {
                PeliculaId = 1,
                Titulo = "title2",
                Poster = "poster2",
                Sinopsis = "Sinopsis2",
                Trailer = "Trailer2"
            };

            //Moq library
            var mockPeliculasQueries = new Mock<IPeliculasQueries>();
            var mockGenericsRepository = new Mock<IGenericsRepository>();

            mockPeliculasQueries.Setup(x => x.GetPeliculaById(1)).Returns(pelicula);
            mockGenericsRepository.Setup(x => x.Update<Peliculas>(pelicula));


            PeliculasService peliculasService = new PeliculasService(mockGenericsRepository.Object, mockPeliculasQueries.Object);


            var result = peliculasService.UpdatePeliculas(peliculaDTO,1);

            Assert.IsType<Peliculas>(result);
        }

    }
}