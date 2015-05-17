using System;

namespace Juega.Domain.Entities
{
    public class Cancha_Foto : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Cancha Cancha { get; set; }
        public virtual string Foto { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    
    }
}
