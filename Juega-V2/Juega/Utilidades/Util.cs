using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Utilidades
{
    public class Util
    {
        public static DateTime ObtenerFecha(string fecha)
        {
            var arr = fecha.Split('-');

            var dia = arr[0];
            var mes = arr[1];
            var anio = arr[2];

            return new DateTime(anio._ToInt(), mes._ToInt(), dia._ToInt());

        }

    }
}