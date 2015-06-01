using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class UsuarioModel

    {

        public virtual string Nombre  {get; set;}
        public virtual string Apellido {get; set;} 
        public virtual string Correo {get; set;}
        public virtual string Telefono {get; set;}
        public virtual string Fecha_Nac {get; set;}

    }
}