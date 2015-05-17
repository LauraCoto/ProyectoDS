
using Juega.Domain.Entities;

namespace Juega.Domain
{
    public interface IEntity
    {
        long Id { get; set; }
        bool Activo { get; set; }

        System.DateTime FechaCreo { get; set; }
        Usuario UsuarioCreo { get; set; }

        Usuario UsuarioElimino { get; set; }
        System.DateTime FechaElimino { get; set; }
    }
}
