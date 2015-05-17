using System;

namespace Juega.Domain.Entities
{
    public class Denuncia : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Usuario UsuarioDenuncia { get; set; }
        public virtual Usuario UsuarioDenunciado { get; set; }
        public virtual Cancha CanchaDenunciada { get; set; }
        public virtual Equipo EquipoDenunciado { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}