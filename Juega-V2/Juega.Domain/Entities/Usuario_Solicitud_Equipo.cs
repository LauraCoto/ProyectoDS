using System;

namespace Juega.Domain.Entities
{
    public class Usuario_Solicitud_Equipo : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}