using System;

namespace Juega.Domain.Entities
{
    public class ComplejoDeportivo : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefonos { get; set; }
        public virtual string Coodernadas { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}
