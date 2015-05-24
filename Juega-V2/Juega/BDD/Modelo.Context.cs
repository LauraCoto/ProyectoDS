﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Juega.BDD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class JuegaEntities : DbContext
    {
        private enum ConexionUsar
        {
            Remoto = 1,
            Dramos = 2,
            DBustillo = 3,
            Rudy = 4,
            Laura = 5,
            Javier = 6,
            Cris = 7,
            Maynor = 8,
            Jesus = 9,

        }
        private static string ObtenerCadenaConexion()
        {
            var cnn = ConexionUsar.Dramos;

            switch (cnn)
            {
                case ConexionUsar.Remoto:
                    return "Juega.Remoto";

                case ConexionUsar.Dramos:
                    return "Juega.Local.dramos";

                case ConexionUsar.DBustillo:
                    return "Juega.Local.dbustillo";

                case ConexionUsar.Rudy:
                    return "Juega.Local.Rudy";

                case ConexionUsar.Laura:
                    return "Juega.Local.Laura";

                case ConexionUsar.Javier:
                    return "Juega.Local.Javier";

                case ConexionUsar.Cris:
                    return "Juega.Local.Cris";

                case ConexionUsar.Maynor:
                    return "Juega.Local.Maynor";

                case ConexionUsar.Jesus:
                    return "Juega.Local.Jesus"; 
            }

            return "Juega.Remoto"; 
        }

        public JuegaEntities() : base("name=" + ObtenerCadenaConexion()) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Cancha_Foto> Cancha_Foto { get; set; }
        public virtual DbSet<Cancha_Horario_Dia> Cancha_Horario_Dia { get; set; }
        public virtual DbSet<Cancha_Horario_Dia_Hora> Cancha_Horario_Dia_Hora { get; set; }
        public virtual DbSet<Cancha_Reservacion> Cancha_Reservacion { get; set; }
        public virtual DbSet<Cancha_Valoracion> Cancha_Valoracion { get; set; }
        public virtual DbSet<ComplejoDeportivo> ComplejoDeportivo { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Equipo_Foto> Equipo_Foto { get; set; }
        public virtual DbSet<Equipo_Jugador> Equipo_Jugador { get; set; }
        public virtual DbSet<Equipo_Tecnico> Equipo_Tecnico { get; set; }
        public virtual DbSet<Equipo_Valoracion> Equipo_Valoracion { get; set; }
        public virtual DbSet<Reto> Reto { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Usuario_Foto> Usuario_Foto { get; set; }
        public virtual DbSet<Usuario_Registro_Acceso> Usuario_Registro_Acceso { get; set; }
        public virtual DbSet<Usuario_Solicitud_AdminCancha> Usuario_Solicitud_AdminCancha { get; set; }
        public virtual DbSet<Usuario_Solicitud_Equipo> Usuario_Solicitud_Equipo { get; set; }
        public virtual DbSet<Usuario_Valoracion> Usuario_Valoracion { get; set; }
    }
}
