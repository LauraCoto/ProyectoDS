using System;

namespace Juega.Domain.Entities
{
    public class Cancha_Horario_Dia_Hora : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Cancha_Horario_Dia CanchaHorario { get; set; }
        public virtual DateTime HoraDesde { get; set; }
        public virtual DateTime HoraHasta { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual string TipoEstado { get; set; }
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}
