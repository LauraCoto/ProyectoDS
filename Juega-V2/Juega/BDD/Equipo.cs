//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Equipo
    {
        public Equipo()
        {
            this.Denuncia = new HashSet<Denuncia>();
            this.Usuario_Solicitud_Equipo = new HashSet<Usuario_Solicitud_Equipo>();
            this.Equipo_Tecnico = new HashSet<Equipo_Tecnico>();
            this.Equipo_Valoracion = new HashSet<Equipo_Valoracion>();
            this.Equipo_Foto = new HashSet<Equipo_Foto>();
            this.Equipo_Jugador = new HashSet<Equipo_Jugador>();
            this.Reto = new HashSet<Reto>();
        }
    
        public long IdEquipo { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Valoracion { get; set; }
        public string TipoEstado { get; set; }
        public string FotoPrincipal { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public virtual ICollection<Usuario_Solicitud_Equipo> Usuario_Solicitud_Equipo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Equipo_Tecnico> Equipo_Tecnico { get; set; }
        public virtual ICollection<Equipo_Valoracion> Equipo_Valoracion { get; set; }
        public virtual ICollection<Equipo_Foto> Equipo_Foto { get; set; }
        public virtual ICollection<Equipo_Jugador> Equipo_Jugador { get; set; }
        public virtual ICollection<Reto> Reto { get; set; }
    }
}
