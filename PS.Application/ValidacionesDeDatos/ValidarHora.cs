using System;
using System.Text.RegularExpressions;

namespace PS.Application.ValidacionesDeDatos
{
    public class ValidarHora
    {
        public bool Validar(string horario)
        {
            bool esValido = false;
            int hora, minutos;
            string[] subcadenas;
            

            if (horario != "")
            {

                Regex re = new Regex(@"\d{1,2}:\d{2}");

                if (re.IsMatch(horario))
                {
                    subcadenas = horario.Split(':');

                    hora = Int32.Parse(subcadenas[0]);
                    minutos = Int32.Parse(subcadenas[1]);

                    if (hora < 24 && minutos < 60)
                    {
                        esValido = true;
                    }
                }

            }
            return esValido;
        }

    }
}
