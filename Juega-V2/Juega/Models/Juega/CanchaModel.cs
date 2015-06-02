using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class CanchaModel
    {

        public virtual string IdCancha { get; set; }
        public virtual string Complejo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Largo { get; set; }
        public virtual string Ancho { get; set; }
        public virtual string Espectadores { get; set; }
    }
}