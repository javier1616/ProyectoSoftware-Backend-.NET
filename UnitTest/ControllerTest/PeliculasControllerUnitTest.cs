using System;
using Xunit;
using PS.Application.Services;
using PS.Domain.Queries;
using Moq;
using PS.Domain.Commands;
using PS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP2_Cine.Controllers;

namespace PeliculasServiceUnitTest
{
    public class PeliculasControllerUnitTest
    {       

        [Fact]
        public void ValidateGetPeliculasById()
        {

            PeliculasDTO peliculaDTO = new PeliculasDTO
            {
                PeliculaId = 1,
                Titulo = "title2",
                Poster = "poster2",
                Sinopsis = "Sinopsis2",
                Trailer = "Trailer2"
            };

            //Moq library
            var mockPeliculasService = new Mock<IPeliculasService>();
            mockPeliculasService.Setup(x => x.GetPeliculaById(1)).Returns(peliculaDTO);
           
            
            PeliculasController peliculasController = new PeliculasController(mockPeliculasService.Object);
            

            var result = peliculasController.GetPeliculasById(1);

            Assert.IsType<OkObjectResult>(result);
   
        }

        [Fact]
        public void ValidateGetAllPeliculas()
        {

            List<Peliculas> listaDePeliculas = new List<Peliculas>();

            
            //Moq library
            var mockPeliculasService = new Mock<IPeliculasService>();
            mockPeliculasService.Setup(x => x.GetAllPeliculas()).Returns(listaDePeliculas);


            PeliculasController peliculasController = new PeliculasController(mockPeliculasService.Object);


            var result = peliculasController.GetAllPeliculas();

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void ValidatePutPelicula()
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
            var mockPeliculasService = new Mock<IPeliculasService>();
            mockPeliculasService.Setup(x => x.UpdatePeliculas(peliculaDTO,1)).Returns(pelicula);


            PeliculasController peliculasController = new PeliculasController(mockPeliculasService.Object);


            var result = peliculasController.PutPelicula(1, peliculaDTO);

            Assert.IsType<OkObjectResult>(result);
        }

    }
}