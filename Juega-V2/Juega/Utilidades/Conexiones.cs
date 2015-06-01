﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Utilidades
{
    public static class Roles
    {
        public const string Espectador = "adm_espectador";
        public const string Jugador = "adm_jugador";
        public const string Tecnico = "adm_tecnico";
        public const string AdminCancha = "adm_cancha";
        public const string AdminSistema = "adm_sistema";
        public const string Valorar = "adm_valorar";
    }
    public static class Conexiones
    {
        private enum ConexionUsar
        {
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
            var cnn = ConexionUsar.Cris;

            switch (cnn)
            {
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
            var cnn = ConexionUsar.Cris;

            switch (cnn)
            {
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