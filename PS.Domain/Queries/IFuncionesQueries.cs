using System;
using System.Collections.Generic;
using PS.Domain.Entities;

namespace PS.Domain.Queries
{
    public interface IFuncionesQueries
    {
        List<Funciones> GetFuncionesByDateAndTitle(DateTime fecha, string titulo);
        List<Funciones> GetFuncionesByDate(DateTime fecha);
        List<Funciones> GetFuncionesBySalaId(int id);

        Funciones GetFuncionesById(int id);
        List<Funciones> GetAllFuncionesByPeliculaId(int id);
        int GetTicketsDisponiblesByFuncionId(int id);

        bool ExistePelicula(int id);
        bool ExisteSala(int id);

    }
}
