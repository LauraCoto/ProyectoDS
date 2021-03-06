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
    
    public partial class Denuncia
    {
        public long IdDenuncia { get; set; }
        public string Descripcion { get; set; }
        public string TipoEstado { get; set; }
        public Nullable<long> IdUsuarioDenuncia { get; set; }
        public Nullable<long> IdUsuarioDenunciado { get; set; }
        public Nullable<long> IdCanchaDenunciada { get; set; }
        public Nullable<long> IdEquipoDenunciado { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    
        public virtual Cancha Cancha { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        public virtual Usuario Usuario2 { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
