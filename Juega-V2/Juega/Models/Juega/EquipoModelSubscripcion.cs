using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class EquipoModelSubscripcion
    {
        public virtual long IdEquipo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int Valoracion { get; set; }
        public virtual string FotoPrincipal { get; set; }
        public virtual string Estado { get; set; }
    }
}