using System;

namespace PS.Application.ValidacionesDeDatos
{
    public class ConvertirStrAHora
    {

        public TimeSpan Convertir(string strHora)
        {
            int hora, minuto;
            TimeSpan result;
            string[] subcadenas;

            subcadenas = strHora.Split(':');

            hora = int.Parse(subcadenas[0]);
            minuto = int.Parse(subcadenas[1]);
            
            result = new TimeSpan(hora, minuto, 0);

            return result;                

        }

    }
}
