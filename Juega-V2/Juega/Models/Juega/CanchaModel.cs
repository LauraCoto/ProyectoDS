using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class CanchaModel
    {
        public virtual long IdCancha { get; set; } 
        public virtual long IdComplejo { get; set; }


        public virtual string Complejo { get; set; } 
        public virtual string Nombre { get; set; }


        public virtual int Largo { get; set; }
        public virtual int Ancho { get; set; } 
        public virtual int Espectadores { get; set; }

        public virtual decimal Valoracion { get; set; }

        public virtual string FotoPrincipal { get; set; }
        public virtual HttpPostedFileBase Attachment { get; set; }

        public virtual RatingCanchaModel InfoValoraciones { get; set; }
        public virtual List<ComentariosUsuarioModel> ListaComentarios { get; set; }

        public virtual List<Horario_Dia_Model> ListaHorarios { get; set; }
    }

    public class Horario_Dia_Model
    {
        public virtual long IdCancha { get; set; }
        public virtual long IdHorario_Dia { get; set; }
        public virtual DateTime Fecha { get; set; }

        public virtual List<Horario_Dia_Hora_Model> ListaHoras { get; set; }
    }

    public class Horario_Dia_Hora_Model
    {
        public virtual long IdHorario_Dia { get; set; }
        public virtual long IdHorario_Hora { get; set; }
        public virtual DateTime FechaDesde { get; set; }
        public virtual DateTime FechaHasta { get; set; }
    }
}