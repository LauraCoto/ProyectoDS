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
    
    public partial class Equipo_Foto
    {
        public long IdEquipo_Foto { get; set; }
        public string Foto { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<long> IdEquipo { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    
        public virtual Equipo Equipo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
