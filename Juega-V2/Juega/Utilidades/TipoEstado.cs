namespace Juega.Utilidades
{
    public static class TipoEstado
    {

        public static readonly string Pendiente = "pndte";
        public static readonly string Aprobado = "aprdo";
        public static readonly string Rechazado = "recdo";
        public static readonly string Bloqueado = "block";
        public static readonly string Reservado = "resdo";
        public static readonly string Anulado = "anldo";
        public static readonly string Disponible = "disp";
        public static readonly string Mantimiento = "mant";
        public static readonly string FueraServicio = "nosvr";

        public static string ObtenerDescripcion(string TipoEstado)
        {
            if (TipoEstado == Pendiente)
                return "Pendiente";

            if (TipoEstado == Aprobado)
                return "Aprobado";

            if (TipoEstado == Rechazado)
                return "Rechazado";

            if (TipoEstado == Bloqueado)
                return "Bloqueado";

            if (TipoEstado == Reservado)
                return "Reservado";

            if (TipoEstado == Anulado)
                return "Anulado";

            if (TipoEstado == Disponible)
                return "Disponible";

            if (TipoEstado == Mantimiento)
                return "Mantimiento";

            if (TipoEstado == FueraServicio)
                return "Fuera de Servicio";

            return TipoEstado;
        }
    }
}