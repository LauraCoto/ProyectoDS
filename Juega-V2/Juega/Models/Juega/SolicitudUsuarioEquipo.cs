﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class SolicitudUsuarioEquipo
    {
        public virtual long IdSolicitud { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string EquipoNombre { get; set; } 
    }
}