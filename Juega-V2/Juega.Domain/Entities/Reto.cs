using System;

namespace Juega.Domain.Entities
{
    public class Reto : IEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime FechaReto { get; set; }

        public virtual Equipo EquipoRetador { get; set; }
        public virtual Equipo EquipoRetado { get; set; }
        public virtual Cancha_Reservacion CanchaReservacion { get; set; }
        public virtual int ResultadoEquipoRetador { get; set; }
        public virtual int ResultadoEquipoRetada { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }

    }
}