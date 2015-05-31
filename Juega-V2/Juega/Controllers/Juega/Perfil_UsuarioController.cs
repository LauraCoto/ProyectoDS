using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class Perfil_UsuarioController : JuegaController
    {
        // GET: Perfil_Usuario
        public ActionResult Index()
        {
            return View();
        }

        public JuegaJson Obtener_Perfil()
        {
            
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                var usuario = ObtenerUsuario_Juega();
                return Resultado_Correcto(usuario);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);

            }
        }
    }
}