using System;
using System.Collections.Generic;
using PS.Application.ValidacionesDeDatos;
using PS.Domain.Commands;
using PS.Domain.Entities;
using PS.Domain.EntitiesDTO;
using PS.Domain.Queries;

namespace PS.Application.Services
{
    
    public class FuncionesService : IFuncionesService
    {

        private readonly IGenericsRepository _repository;
        private readonly IFuncionesQueries _query;

        public FuncionesService(IGenericsRepository repository,IFuncionesQueries query)
        {
            _repository = repository;
            _query = query;
        }

       
        public List<FuncionesDTO> GetFuncionesByDateAndTitle(DateTime fecha, string titulo)
        {
              
            List<Funciones> listaDeFunciones;
            List<FuncionesDTO> listaDeFuncionesDTO = new List<FuncionesDTO>();

            listaDeFunciones = _query.GetFuncionesByDateAndTitle(fecha, titulo);

            foreach (Funciones elem in listaDeFunciones)
            {
                FuncionesDTO funcionDTO = new FuncionesDTO
                {
                    FuncionId = elem.FuncionId,
                    PeliculaId = elem.PeliculaId,
                    SalaId = elem.SalaId,
                    Fecha = elem.Fecha,
                    Horario = elem.Horario
                };

                listaDeFuncionesDTO.Add(funcionDTO);
            
            }

            return listaDeFuncionesDTO;

        }

        public List<FuncionesDTO> GetFuncionesByDate(DateTime fecha)
        {

            List<Funciones> listaDeFunciones;
            List<FuncionesDTO> listaDeFuncionesDTO = new List<FuncionesDTO>();

            listaDeFunciones = _query.GetFuncionesByDate(fecha);

            foreach (Funciones elem in listaDeFunciones)
            {
                FuncionesDTO funcionDTO = new FuncionesDTO
                {
                    FuncionId = elem.FuncionId,
                    PeliculaId = elem.PeliculaId,
                    SalaId = elem.SalaId,
                    Fecha = elem.Fecha,
                    Horario = elem.Horario
                };

                listaDeFuncionesDTO.Add(funcionDTO);

            }

            return listaDeFuncionesDTO;

        }

        public FuncionesDTO CreateFuncion(FuncionesDTOFechaHoraString funcionDTOFechaHoraString)
        {

            var convertidorFecha = new ConvertirStrAFecha();
            var convertidorHora = new ConvertirStrAHora();
            var validadorFecha = new ValidarFecha();
            var validadorHora = new ValidarHora();
            var funcionDTO = new FuncionesDTO();


            if (validadorFecha.Validar(funcionDTOFechaHoraString.Fecha) &&
                validadorHora.Validar(funcionDTOFechaHoraString.Horario) &&
                _query.ExistePelicula(funcionDTOFechaHoraString.PeliculaId) &&
                _query.ExisteSala(funcionDTOFechaHoraString.SalaId))
            {

                funcionDTO.PeliculaId = funcionDTOFechaHoraString.PeliculaId;
                funcionDTO.SalaId = funcionDTOFechaHoraString.SalaId;
                funcionDTO.Fecha = convertidorFecha.Convertir(funcionDTOFechaHoraString.Fecha);
                funcionDTO.Horario = convertidorHora.Convertir(funcionDTOFechaHoraString.Horario);



                TimeSpan ventana = new TimeSpan(2, 30, 0);


                List<Funciones> funcionesSuperpuestas = new List<Funciones>();
                List<Funciones> funcionesConIgualDiaSala = new List<Funciones>();

                var funcionesConIgualSala = _query.GetFuncionesBySalaId(funcionDTOFechaHoraString.SalaId);

                foreach (Funciones elem in funcionesConIgualSala)
                {
                    if (elem.Fecha == funcionDTO.Fecha)
                    {
                        funcionesConIgualDiaSala.Add(elem);
                    }

                }

                TimeSpan horaInicioNuevaFuncion = funcionDTO.Horario;
                TimeSpan horaFinNuevaFuncion = funcionDTO.Horario + ventana;

                foreach (Funciones elem in funcionesConIgualDiaSala)
                {
                    if (((elem.Horario >= horaInicioNuevaFuncion) && (elem.Horario < horaFinNuevaFuncion)) ||
                         (((elem.Horario + ventana) > horaInicioNuevaFuncion) && (elem.Horario <= horaInicioNuevaFuncion)))
                    {
                        funcionesSuperpuestas.Add(elem);
                    }

                }

                if (funcionesSuperpuestas.Count == 0)
                {

                    var entity = new Funciones
                    {
                        PeliculaId = funcionDTO.PeliculaId,
                        SalaId = funcionDTO.SalaId,
                        Fecha = funcionDTO.Fecha,
                        Horario = funcionDTO.Horario
                    };

                    _repository.Add<Funciones>(entity);

                    return funcionDTO;

                }

                return null;

            }

            else return null;

        }


        public List<FuncionesDTO> GetAllFuncionesByPeliculaId(int id)
        {
            List<FuncionesDTO> listaDeFuncionesDTO = new List<FuncionesDTO>();


            if (_query.ExistePelicula(id))
            {
                var listaDeFunciones = _query.GetAllFuncionesByPeliculaId(id);

                foreach (Funciones elem in listaDeFunciones)
                {
                    FuncionesDTO funcion = new FuncionesDTO
                    {
                        FuncionId = elem.FuncionId,
                        PeliculaId = elem.PeliculaId,
                        SalaId = elem.SalaId,
                        Fecha = elem.Fecha,
                        Horario = elem.Horario
                    };

                    listaDeFuncionesDTO.Add(funcion);

                }

                return listaDeFuncionesDTO;
            }

            return null;
        }


        public bool RemoveFunciones(int id)
        {
            bool flagDeBorrado = false;
            var entity = _query.GetFuncionesById(id);
            if (entity != null)
            {
                _repository.Remove<Funciones>(entity);
                flagDeBorrado = true;
            }
            return flagDeBorrado;
        }

        public int GetTicketsDisponiblesByFuncionId(int id)
        {

            var cantidadDeTicketsDisponibles = _query.GetTicketsDisponiblesByFuncionId(id);

            return cantidadDeTicketsDisponibles;

        }

    }

}
