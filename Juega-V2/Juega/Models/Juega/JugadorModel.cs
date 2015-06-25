namespace Juega.Models.Juega
{
    public class JugadorModel
    {

        public virtual long IdJugador { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Edad { get; set; }
        public virtual int NumEquipos { get; set; }
        public virtual decimal Valoracion { get; set; }
        public virtual string FotoPrincipal { get; set; }
    }
}