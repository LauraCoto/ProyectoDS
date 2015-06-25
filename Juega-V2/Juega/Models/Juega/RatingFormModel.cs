using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class RatingJugadorModel
    {

        //Valoracion que hizo el jugador
        public virtual long IdValoracion { get; set; }
        public virtual DateTime FechaValoro { get; set; }
        public virtual int Valor { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Comentario { get; set; }


        //Informacion estadistica
        public virtual long IdJugador { get; set; } 

        public virtual int Start5Count { get; set; }
        public virtual int Start4Count { get; set; }
        public virtual int Start3Count { get; set; }
        public virtual int Start2Count { get; set; }
        public virtual int Start1Count { get; set; }

        public virtual decimal Start5Avg { get; set; }
        public virtual decimal Start4Avg { get; set; }
        public virtual decimal Start3Avg { get; set; }
        public virtual decimal Start2Avg { get; set; }
        public virtual decimal Start1Avg { get; set; }

        public virtual decimal CantidadValoraciones { get; set; }
        public virtual decimal PromedioValoraciones { get; set; }

        public RatingJugadorModel()
        {
 
        }

        public RatingJugadorModel(RatingJugadorModel r)
        {
            
            this.IdValoracion = r.IdValoracion;
            this.FechaValoro = r.FechaValoro;
            this.Valor = r.Valor;
            this.Comentario = r.Comentario;
            this.Titulo = r.Titulo;

            this.IdJugador = r.IdJugador; 
            
            this.Start5Count = r.Start5Count;
            this.Start4Count = r.Start4Count;
            this.Start3Count = r.Start3Count;
            this.Start2Count = r.Start2Count;
            this.Start1Count = r.Start1Count;

            this.Start5Avg = r.Start5Avg;
            this.Start4Avg = r.Start4Avg;
            this.Start3Avg = r.Start3Avg;
            this.Start2Avg = r.Start2Avg;
            this.Start1Avg = r.Start1Avg;

            this.CantidadValoraciones = r.CantidadValoraciones;
            this.PromedioValoraciones = r.PromedioValoraciones; 
        }

    }
}