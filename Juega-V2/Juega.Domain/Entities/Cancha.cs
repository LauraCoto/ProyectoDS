
using System;

namespace Juega.Domain.Entities
{
    public class Cancha : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual ComplejoDeportivo ComplejoDeportivo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int NumEspectadores { get; set; }
        public virtual int Largo { get; set; }
        public virtual int Ancho { get; set; }
        public virtual int Valoracion { get; set; }
        public virtual  string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}