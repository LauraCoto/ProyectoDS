using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class EquiposModel
    {
        public virtual long IdEquipo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual decimal Valoracion { get; set; } 
        public virtual string FotoPrincipal { get; set; }

        public virtual RatingEquipoModel InfoValoraciones { get; set; }
        public virtual List<EquiposJugadoresModel> ListaJugadores { get; set; }
        public virtual List<ComentariosUsuarioModel> ListaComentarios { get; set; }
    }
}