using System;
using System.Collections.Generic;
using PS.Domain.EntitiesDTO;

namespace PS.Application.Services
{
    public interface IFuncionesService
    {
        List<FuncionesDTO> GetFuncionesByDateAndTitle(DateTime fecha, string titulo);
        List<FuncionesDTO> GetFuncionesByDate(DateTime fecha);
        FuncionesDTO CreateFuncion(FuncionesDTOFechaHoraString funcionDTOFechaHoraString);
        bool RemoveFunciones(int id);
        List<FuncionesDTO> GetAllFuncionesByPeliculaId(int id);
        int GetTicketsDisponiblesByFuncionId(int id);
    }

    

}
