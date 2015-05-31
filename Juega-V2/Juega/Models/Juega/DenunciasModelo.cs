using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class DenunciasModelo
    {
        public virtual string IdUsuario { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string IdCancha { get; set; }
        public virtual string Cancha { get; set; }
        public virtual string IdEquipo { get; set; }
        public virtual string Equipo { get; set; }

    }

}