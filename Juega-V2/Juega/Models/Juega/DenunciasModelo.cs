using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class DenunciasModelo
    {
        public virtual string IdUsuarioDenuncia { get; set; }
        public virtual string UsuarioDenuncia { get; set; }
        public virtual string IdUsuarioDenunciado { get; set; }
        public virtual string UsuarioDenunciado { get; set; }
        public virtual string IdCancha { get; set; }
        public virtual string Cancha { get; set; }
        public virtual string IdEquipo { get; set; }
        public virtual string Equipo { get; set; }
        public virtual string IdDenuncia { get; set; }
        public virtual string Descripcion { get; set; }
    }
}