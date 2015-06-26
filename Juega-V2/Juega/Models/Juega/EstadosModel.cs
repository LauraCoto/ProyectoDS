using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class EstadosModel
    {
        public virtual string IdEstado { get; set; }
        public virtual string Descripcion { get; set; }

        public EstadosModel(string idTipoEstado)
        {
            IdEstado = idTipoEstado;
            Descripcion = Utilidades.TipoEstado.ObtenerDescripcion(idTipoEstado);
        }
    }
}