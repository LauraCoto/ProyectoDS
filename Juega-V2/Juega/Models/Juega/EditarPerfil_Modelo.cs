﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Models.Juega
{
    public class EditarPerfil_Modelo
      {
          public virtual long IdUsuario { get; set; }
          public virtual string Nombre { get; set; }
          public virtual string Apellido { get; set; }
          public virtual string FotoPrincipal { get; set; }
          public virtual DateTime FechaNacimiento { get; set; }
          public virtual string Descripcion { get; set; }
          public virtual HttpPostedFileBase Attachment { get; set; }
          public virtual object Foto { get; set; }
      }
}