using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class UsuarioModel
    {

        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Edad { get; set; }
        public virtual int NumEquipos { get; set; }
        public virtual int NumComentarios { get; set; }
        public virtual decimal Valoracion { get; set; }
        public virtual RatingJugadorModel InfoValoraciones { get; set; }
        public virtual List<EquiposUsuarioModel> ListaEquipos { get; set; }
        public virtual List<ComentariosUsuarioModel> ListaComentarios { get; set; }
    }

    public class EquiposUsuarioModel
    {
        public virtual long IdEquipo { get; set; }
        public virtual string Nombre { get; set; } 
        public virtual string FotoPrincipal { get; set; }
        public virtual bool Activo { get; set; }
    }

    public class EquiposJugadoresModel
    {
        public virtual long IdJugador { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string FotoPrincipal { get; set; }
        public virtual bool Activo { get; set; }
    }

    public class ComentariosUsuarioModel
    {
        public virtual string UsuarioComento { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Comentario { get; set; }
        public virtual decimal Valoracion { get; set; }
        public virtual string FotoPrincipal { get; set; }
        public virtual string Tiempo { get; set; }
    }
}