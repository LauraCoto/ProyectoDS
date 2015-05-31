using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class Rol
    {
        public Rol() { }

        public Rol(string _id, string _nombre)
        {
            Id = _id;
            Nombre = _nombre;
            Nombre_Ant = _nombre;
        }

        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Nombre_Ant { get; set; }
    }

    public class MenuPrincipal
    {
        public MenuPrincipal()
        {
            Descripcion = "";
            Controller = "";
            Action = "";
            UrlIcono = "";
        }

        public virtual string Descripcion { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual string UrlIcono { get; set; }
    }

    public class Controladores
    {
        public Controladores()
        {
            Nombre = "";
        }

        public virtual string Nombre { get; set; }
    }

    public class Acciones
    {
        public virtual string Nombre { get; set; }
    }

    public class Usuario
    {
        public Usuario() { }

        public Usuario(string _id, string _nombre)
        {
            Id = _id;
            Nombre = _nombre;
        }

        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
    }

    public class Usuario_Rol
    {
        public Usuario_Rol() { }

        public Usuario_Rol(string _idRol, string _rol, string _idUsuario, string _usuario)
        {
            IdRol = _idRol;
            Rol = _rol;

            IdUsuario = _idUsuario;
            Usuario = _usuario;
        }

        public virtual string IdRol { get; set; }
        public virtual string Rol { get; set; }


        public virtual string IdUsuario { get; set; }
        public virtual string Usuario { get; set; }
    }
}