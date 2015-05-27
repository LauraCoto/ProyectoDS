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
    //[Authorize(Roles = "adm_rol")]
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

                var lista = roleManager.Roles.ToList();

                var roles = new List<Rol>();
                foreach (var i in lista)
                {
                    var r = new Rol();
                    r.Id = i.Id;
                    r.Nombre = i.Name;
                    r.Nombre_Ant = i.Name;
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
                    return Resultado_Advertencia("Ya existe un rol con el mismo nombre.");

                roleManager.Create(new IdentityRole(rol.Nombre));

                return Resultado_Correcto(rol);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        [Authorize]
        public JuegaJson Update(Rol rol)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                if (roleManager.RoleExists(rol.Nombre))
                    return Resultado_Advertencia("Ya existe un rol con el mismo nombre.");

                var rolActualizar = roleManager.FindByName(rol.Nombre_Ant);

                if (rolActualizar == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                rolActualizar.Name = rol.Nombre;
                roleManager.Update(rolActualizar);

                return Resultado_Correcto(rol);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Delete(Rol rolEliminar)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (rolEliminar == null)
                    return Resultado_Advertencia("El registro no es valido.");


                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                if (!roleManager.RoleExists(rolEliminar.Nombre))
                    return Resultado_Advertencia("El rol que intenta eliminar no existe.");


                var rol = roleManager.FindByName(rolEliminar.Nombre);

                if (rol == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                // var userManager =new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext())); 
                if ( rol.Users.Count() > 0)
                    return Resultado_Advertencia("No se puede eliminar este rol tiene usuarios asignados.");

                var resultado = roleManager.Delete(rol);

                if (resultado.Succeeded)
                    return Resultado_Correcto("El rol ha sido eliminado");
                else
                    return Resultado_Advertencia("Ocurrio un error al eliminar el rol.");

            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
    }
}