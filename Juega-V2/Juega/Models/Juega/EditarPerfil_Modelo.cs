using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Models.Juega
{
      public class EditarModel
      {
          public virtual long IdUsuario { get; set; }
          public virtual string Nombre { get; set; }
          public virtual string Apellido { get; set; }
          public virtual string FotoPrincipal { get; set; }
          public virtual string FechaNacimiento { get; set; }
          public virtual string Descripcion { get; set; }
      }
}