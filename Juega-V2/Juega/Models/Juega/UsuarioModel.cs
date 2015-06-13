using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class UsuarioModel
    {

        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Edad { get; set; }
        public virtual int NumEquipos { get; set; }
        public virtual int Valoracion { get; set; }

        //public virtual string Foto_Principal { get; set; }
    }
}