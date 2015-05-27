using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class Rol
    {
        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Nombre_Ant { get; set; }
    }
}