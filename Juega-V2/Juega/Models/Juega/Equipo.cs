using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class EquipoModel
    {
        //public virtual long IdEquipo { get; set; }
        //public virtual string Nombre { get; set; }


        public EquipoModel() { }

        public EquipoModel(long _idEquipo, string _Nombre, string _idUsuario, string _usuario)
        {
            IdEquipo = _idEquipo;
            Nombre = _Nombre;

            IdUsuario = _idUsuario;
            Usuario = _usuario;
        }

        public virtual long IdEquipo { get; set; }
        public virtual string Nombre { get; set; }


        public virtual string IdUsuario { get; set; }
        public virtual string Usuario { get; set; }

        //public class EquipoModel
        //{
        //    public EquipoModel() { }

        //    public EquipoModel(string _idEquipo, string _Nombre, string _idUsuario, string _usuario)
        //    {
        //        IdEquipo = _idEquipo;
        //        Nombre = _Nombre;

        //        IdUsuario = _idUsuario;
        //        Usuario = _usuario;
        //    }

        //    public virtual string IdEquipo { get; set; }
        //    public virtual string Nombre { get; set; }


        //    public virtual string IdUsuario { get; set; }
        //    public virtual string Usuario { get; set; }
        //}
        
    }
}