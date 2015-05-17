using System;

namespace Juega.Domain.Entities
{
    public class Usuario_Valoracion : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Usuario UsuarioValorado { get; set; }
        public virtual Usuario UsuarioValoro { get; set; }
        public virtual int Valoracion { get; set; }
        public virtual int TipoValoracion { get; set; } //Jugador, Tecnico, AdminCancha
        public virtual DateTime FechaCreo { get; set; }
        public virtual Usuario UsuarioCreo { get; set; }
        public virtual DateTime FechaElimino { get; set; }
        public virtual Usuario UsuarioElimino { get; set; }
        public virtual bool Activo { get; set; }
    }
}