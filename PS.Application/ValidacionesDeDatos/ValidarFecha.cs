using System;
using System.Text.RegularExpressions;

namespace PS.Application.ValidacionesDeDatos
{
    public class ValidarFecha
    {
        public bool Validar(string fecha)
        {
            bool esValido = false;
            string dia,mes,anio;

            if (fecha != "")
            {
            
                // formato de ingreso yyyy-mm-dd
                Regex re = new Regex(@"\d{4}-\d{2}-\d{2}");

                if (re.IsMatch(fecha))
                {
                    dia = fecha.Substring(8, 2);
                    mes = fecha.Substring(5, 2);
                    anio = fecha.Substring(0, 4);

                    if (DateTime.TryParse(dia+"-"+mes+"-"+anio, out var date))
                    {
                        esValido = true;
                    }
                    
                }

            }

            return esValido;
        }

    }
}
