using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class CanchaModel
    {
       // private readonly List<ComplejoModel> _Complejos;

        public virtual long IdCancha { get; set; }
        public virtual long IdComplejo { get; set; }
        public virtual string Complejo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int Largo { get; set; }
        public virtual int Ancho { get; set; }
        public virtual int Espectadores { get; set; }

        //public IEnumerable<System.Web.Mvc.SelectListItem> Complejos
        //{
        //    get { return new System.Web.Mvc.SelectList(_Complejos, "IdComplejoDeportivo", "Nombre"); }
        //}

    }
}