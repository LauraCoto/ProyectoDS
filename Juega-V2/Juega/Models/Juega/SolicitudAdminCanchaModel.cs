using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class SolicitudAdminCanchaModel
    {
        public virtual long IdSolicitud { get; set; }
        public virtual string FechaCreo { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual long IdUsuario { get; set; }
    }
}