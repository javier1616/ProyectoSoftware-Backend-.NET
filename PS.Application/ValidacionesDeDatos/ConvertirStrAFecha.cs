using System;
using System.Text.RegularExpressions;

namespace PS.Application.ValidacionesDeDatos
{
    public class ConvertirStrAFecha
    {

        public DateTime Convertir(string fecha)
        {
            string dia, mes, anio;

            Regex re = new Regex(@"\d{4}-\d{2}-\d{2}");

            if (re.IsMatch(fecha))
            {
                dia = fecha.Substring(8, 2);
                mes = fecha.Substring(5, 2);
                anio = fecha.Substring(0, 4);

                if (DateTime.TryParse(dia + "-" + mes + "-" + anio, out var date))
                {
                    return date;
                }
                else
                {
                    
                    return DateTime.MinValue;    //  (1/1/0001 12:00:00 AM)
                }

            }

           
            return DateTime.MinValue;    //  (1/1/0001 12:00:00 AM)

        }

    }
}
