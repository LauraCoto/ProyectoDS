using System;

namespace Juega.Domain.Entities
{
    public class Cancha_Valoracion :IEntity
    {
        public virtual long Id { get; set; }
        public virtual int Valoracion { get; set; }
        public virtual string Comentario { get; set; }
        public virtual Cancha Cancha { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }

    }
}
