using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Utilidades
{
    public static class Conexiones
    {
        private enum ConexionUsar
        {
            Aws = 0,
            AppHarbor = 1,
            Dramos = 2,
            DBustillo = 3,
            Rudy = 4,
            Laura = 5,
            Javier = 6,
            Cris = 7,
            Maynor = 8,
            Jesus = 9,
        }

        public static string ObtenerCadenaConexion_Sistema()
        {
            var cnn = ConexionUsar.DBustillo; 

            switch (cnn)
            {
                case ConexionUsar.Aws:
                    return "Juega.A_W_S";

                case ConexionUsar.AppHarbor:
                    return "Juega.AppHarbor";

                case ConexionUsar.Dramos:
                    return "Juega.dramos";

                case ConexionUsar.DBustillo:
                    return "Juega.dbustillo";

                case ConexionUsar.Rudy:
                    return "Juega.Rudy";

                case ConexionUsar.Laura:
                    return "Juega.Laura";

                case ConexionUsar.Javier:
                    return "Juega.Javier";

                case ConexionUsar.Cris:
                    return "Juega.Cris";

                case ConexionUsar.Maynor:
                    return "Juega.Maynor";

                case ConexionUsar.Jesus:
                    return "Juega.Jesus";
            }

            return "Juega.AppHarbor";
        }

        public static string ObtenerCadenaConexion_Seguridad()
        {
            var cnn = ConexionUsar.DBustillo; 

            switch (cnn)
            {
                case ConexionUsar.Aws:
                    return "Seguridad.A_W_S";

                case ConexionUsar.AppHarbor:
                    return "Seguridad.AppHarbor";

                case ConexionUsar.Dramos:
                    return "Seguridad.dramos";

                case ConexionUsar.DBustillo:
                    return "Seguridad.dbustillo";

                case ConexionUsar.Rudy:
                    return "Seguridad.Rudy";

                case ConexionUsar.Laura:
                    return "Seguridad.Laura";

                case ConexionUsar.Javier:
                    return "Seguridad.Javier";

                case ConexionUsar.Cris:
                    return "Seguridad.Cris";

                case ConexionUsar.Maynor:
                    return "Seguridad.Maynor";

                case ConexionUsar.Jesus:
                    return "Seguridad.Jesus";
            }

            return "Seguridad.AppHarbor";
        }

    }

}