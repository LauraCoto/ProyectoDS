using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juega.Domain.Entities
{
    public class Usuario : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Telefonos { get; set; }
        public virtual bool Confirmado { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual int Valoracion { get; set; }
        public virtual bool EsEspectador { get; set; }
        public virtual bool EsAdminCancha { get; set; }
        public virtual bool EsAdminEquipo { get; set; }
        public virtual bool EsJugador { get; set; }

        public virtual DateTime FechaNacimiento { get; set; }
        public virtual DateTime FechaCreo { get; set; }


        [ForeignKey("__UsuarioCreo")]
        public virtual Usuario UsuarioCreo { get; set; }

        public virtual DateTime FechaElimino { get; set; }

         [ForeignKey("__UsuarioElimino")]
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}
