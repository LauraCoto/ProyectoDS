using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        public virtual string FechaDesde { get; set; }
        public virtual string FechaHasta { get; set; }
        public virtual string FechaClonar { get; set; }

        public CanchaModel()
        {
            InfoValoraciones = new RatingCanchaModel();
            ListaComentarios = new List<ComentariosUsuarioModel>();
            ListaHorarios = new List<Horario_Dia_Model>();
            //FechaClonar = FechaDesde = FechaHasta = DateTime.Now;
        }
    }

    public class Horario_Dia_Model
    {
        public virtual long IdCancha { get; set; }
        public virtual long IdHorario_Dia { get; set; }
        public virtual DateTime dtFecha { get; set; }
        public virtual string Fecha { get; set; }

        public virtual int Dia { get; set; }
        public virtual string Mes { get; set; }
        public virtual int Anio { get; set; }
        public virtual string NombreDia { get; set; }

        public virtual int CantHorarios { get; set; }
        public virtual List<Horario_Dia_Hora_Model> ListaHoras { get; set; }

        public Horario_Dia_Model()
        {
            ListaHoras = new List<Horario_Dia_Hora_Model>();
        }

        public void EstablecerFecha(DateTime _dtFecha)
        {
            var cultura = new CultureInfo("es-ES");
            Fecha = _dtFecha.ToShortDateString();
            dtFecha = _dtFecha;
            Dia = _dtFecha.Day;
            Mes = _dtFecha.ToString("MMMM", cultura).ToUpper(); ;
            Anio = _dtFecha.Year;
            NombreDia = _dtFecha.ToString("dddd", cultura).ToUpper();

        }
    }

    public class Horario_Dia_Hora_Model
    {
        public virtual long IdHorario_Dia { get; set; }
        public virtual long IdHorario_Hora { get; set; }
        
        public virtual string HoraDesde { get; set; }
        public virtual DateTime dtHoraDesde { get; set; }
        
        public virtual string HoraHasta { get; set; }
        public virtual DateTime dtHoraHasta { get; set; }
        
        public virtual string Precio { get; set; }
        public virtual decimal nPrecio { get; set; }
        
        public virtual string IdEstado { get; set; }
        public virtual string Estado { get; set; }
    }
}