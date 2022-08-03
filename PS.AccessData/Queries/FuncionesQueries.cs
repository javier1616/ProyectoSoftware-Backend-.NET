using System;
using System.Collections.Generic;
using System.Linq;
using PS.Domain.Entities;
using PS.Domain.Queries;

namespace PS.AccessData.Queries
{
    public class FuncionesQueries : IFuncionesQueries
    { 

        private readonly TemplateDbContext _context;

        public FuncionesQueries(TemplateDbContext context)
        {
            _context = context;
        }


        public List<Funciones> GetFuncionesByDateAndTitle(DateTime fecha, string titulo)
        {
            var funciones = new List<Funciones>();
            var pelicula = _context.Set<Peliculas>().Where(p => p.Titulo == titulo).FirstOrDefault();

            if (pelicula != null)
            {
                funciones = _context.Set<Funciones>().Where(f => f.PeliculaId == pelicula.PeliculaId &&
                                                                     f.Fecha == fecha).ToList();
            }

            return funciones;

        }

        public List<Funciones> GetFuncionesByDate(DateTime fecha)
        {

            var funciones = _context.Set<Funciones>().Where(f => f.Fecha == fecha).ToList();

            return funciones;

        }

        public List<Funciones> GetFuncionesBySalaId(int id)
        {

            var funciones = _context.Set<Funciones>().Where(f => f.SalaId == id).ToList();

            return funciones;

        }

        public Funciones GetFuncionesById(int id)
        {

            var funciones = _context.Set<Funciones>().Where(f => f.FuncionId == id).FirstOrDefault();

            return funciones;

        }

        public List<Funciones> GetAllFuncionesByPeliculaId(int id)
        {

            var listaDeFunciones = _context.Set<Funciones>().Where(f => f.PeliculaId == id).ToList();

            return listaDeFunciones;

        }

        public int GetTicketsDisponiblesByFuncionId(int id)
        {

            var funcion = _context.Set<Funciones>().Where(f => f.FuncionId == id).FirstOrDefault();
            Salas sala = new Salas();
            List<Tickets> tickets = new List<Tickets>();

            if (funcion != null)
            {
                sala = _context.Set<Salas>().Where(s => s.SalaId == funcion.SalaId).First();
                tickets = _context.Set<Tickets>().Where(t => t.FuncionId == id).ToList();
            }
            else return -1;

            return (sala.Capacidad - tickets.Count());
        }

        public bool ExistePelicula(int id)
        {
            var pelicula = _context.Set<Peliculas>().Where(peli => peli.PeliculaId == id).FirstOrDefault();
            return (pelicula != null);      
        }

        public bool ExisteSala(int id)
        {
            var sala = _context.Set<Salas>().Where(peli => peli.SalaId == id).FirstOrDefault();
            return (sala != null);
        }


    }
}