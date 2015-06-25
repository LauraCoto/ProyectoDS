using System.Collections.Generic;

namespace Juega.Models.Juega
{
    public class MenuPrincipal
    {
        public MenuPrincipal()
        {
            Descripcion = "";
            IdMenu = "";
            Controller = "";
            Action = "";
            UrlIcono = "";
            ListaHijos = new List<MenuPrincipal>(); 
        }

        public virtual string IdMenu { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual string UrlIcono { get; set; }

        public virtual List<MenuPrincipal> ListaHijos { get; set; }
    }
}