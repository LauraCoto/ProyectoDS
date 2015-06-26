using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Juega.Utilidades
{
    public class Util
    {
        public static DateTime ObtenerFecha(string fecha)
        {
            var arr = fecha.Split('-');

            var mes = arr[0];
            var dia = arr[1];
            var anio = arr[2];

            return new DateTime(anio._ToInt(), mes._ToInt(), dia._ToInt());

        }

        public static string FormatoDinero(decimal valor)
        {
            if (valor._IsNullOrEmpty())
                valor = 0;

            //var format = new System.Globalization.NumberFormatInfo();

            //format.CurrencyDecimalDigits = 2;
            //format.CurrencyDecimalSeparator = ",";
            //format.CurrencyGroupSeparator = "";

            //var formato = string.Format("{0:C}", valor);

            var formato =string.Format(new CultureInfo("es-hn", false), "{0:n2}",valor);

            return formato;
        }

    }
}