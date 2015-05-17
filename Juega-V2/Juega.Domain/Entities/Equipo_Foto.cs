using System;

namespace Juega.Domain.Entities
{
    public class Equipo_Foto : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Equipo Usuario { get; set; }
        public virtual string Foto { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}