using System;
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
}