using Juega.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    public class RolesController : JuegaController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                //roleManager.Create(new IdentityRole("Prueba"));

                var lista = roleManager.Roles.ToList();

                var roles = new List<Rol>();
                foreach (var i in lista)
                {
                    var r = new Rol();
                    r.Id = i.Id;
                    r.Nombre = i.Name;
                    roles.Add(r);

                }

                return Resultado_Correcto(roles);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        [Authorize]
        public JuegaJson Create(Rol rol)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                if (roleManager.RoleExists(rol.Nombre))
                    return Resultado_Error("Ya existe un rol con el mismo nombre.");

                roleManager.Create(new IdentityRole(rol.Nombre));

                return Resultado_Correcto(rol);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Delete(string rol)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                var usuarios = System.Web.Security.Roles.GetUsersInRole(rol);

                if (usuarios != null && usuarios.Count() > 0)
                    return Resultado_Error("No se puede eliminar este rol porque esta asignado a los usuarios:" + usuarios);

                var eliminado = System.Web.Security.Roles.DeleteRole(rol);

                if (eliminado)
                    return Resultado_Correcto("El rol ha sido eliminado");
                else
                    return Resultado_Error("Ocurrio un error al eliminar el rol.");

            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
    }
}