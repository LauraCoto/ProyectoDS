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
    
    public partial class Cancha
    {
        public Cancha()
        {
            this.Cancha_Horario_Dia = new HashSet<Cancha_Horario_Dia>();
            this.Denuncia = new HashSet<Denuncia>();
            this.Cancha_Valoracion = new HashSet<Cancha_Valoracion>();
            this.Cancha_Foto = new HashSet<Cancha_Foto>();
        }
    
        public long IdCancha { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> NumEspectadores { get; set; }
        public Nullable<int> Largo { get; set; }
        public Nullable<int> Ancho { get; set; }
        public Nullable<int> Valoracion { get; set; }
        public string TipoEstado { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<long> IdComplejoDeportivo { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    
        public virtual ICollection<Cancha_Horario_Dia> Cancha_Horario_Dia { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public virtual ICollection<Cancha_Valoracion> Cancha_Valoracion { get; set; }
        public virtual ICollection<Cancha_Foto> Cancha_Foto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ComplejoDeportivo ComplejoDeportivo { get; set; }
    }
}
