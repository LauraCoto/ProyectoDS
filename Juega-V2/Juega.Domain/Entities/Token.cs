using System;

namespace Juega.Domain.Entities
{
    public class Token : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string TokenConfirmacion { get; set; }
        public virtual string Correo { get; set; }
        public virtual string TipoEstado { get; set; }

        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}