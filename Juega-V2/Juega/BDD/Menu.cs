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
    
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public string IdRolSeguridad { get; set; }
        public Nullable<int> Orden { get; set; }
        public string Descripcion { get; set; }
        public string UrlIcon { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<int> IdMenuPadre { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<System.DateTime> FechaElimino { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
