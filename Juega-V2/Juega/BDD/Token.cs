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
    
    public partial class Token
    {
        public long IdToken { get; set; }
        public string TokenConfirmacion { get; set; }
        public string Correo { get; set; }
        public string TipoEstado { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
