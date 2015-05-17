using System;

namespace Juega.Domain.Entities
{
    public class Cancha_Reservacion :IEntity
    {

        public virtual long Id { get; set; }
        public virtual Cancha_Horario_Dia_Hora HorarioReservado { get; set; }
        public virtual DateTime FechaReservacion { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}