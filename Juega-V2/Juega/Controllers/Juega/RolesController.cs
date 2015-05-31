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
    // [Authorize(Roles = Utilidades.Roles.AdminSistema)]
    public class RolesController : JuegaController
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ManageRole()
        {
            return View();
        }

        public JuegaJson GetAllUsersInRol()
        {
            try
            {
                var UsersContext = new ApplicationDbContext();
                var users = UsersContext.Users.ToList();

                var lista = new List<Usuario_Rol>();
                foreach (var r in UsersContext.Roles.ToList())
                {
                    foreach (var u in r.Users)
                    {
                        var user = users.Find(x => x.Id == u.UserId);

                        if (user == null)
                            continue;

                        var model = new Usuario_Rol(r.Id, r.Name, user.Id, user.UserName);
                        lista.Add(model);
                    }
                }

                return Resultado_Correcto(lista);

            }
            catch (Exception ex)
            {
                return Resultado_Exception(ex);
            }
        }

        public JuegaJson GetAllUsers()
        {
            try
            {
                var UsersContext = new ApplicationDbContext();
                var users = UsersContext.Users.ToList();

                var lista = new List<Usuario>();
                foreach (var u in users)
                {
                    var usuario = new Usuario(u.Id, u.UserName);
                    lista.Add(usuario);
                }

                return Resultado_Correcto(lista);

            }
            catch (Exception ex)
            {
                return Resultado_Exception(ex);
            }
        }

        public JuegaJson GetAllRoles()
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
                    var r = new Rol(i.Id, i.Name);
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

                if (rol.Users.Count() > 0)
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

        [HttpPost]
        [Authorize]
        public JuegaJson AddUserToRol(Usuario_Rol model)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var context = new ApplicationDbContext();
                var usuario = context.Users.FirstOrDefault(x => x.Id == model.IdUsuario);
                var rol = context.Roles.FirstOrDefault(x => x.Id == model.IdRol);

                if (usuario == null)
                    return Resultado_Advertencia("El usuario al que intenta configurar no existe.");

                if (rol == null)
                    return Resultado_Advertencia("El rol al que intenta configurar no existe.");

                var identityRol = new IdentityUserRole();
                identityRol.RoleId = model.IdRol;
                identityRol.UserId = model.IdUsuario;

                model.Rol = rol.Name;
                model.Usuario = usuario.UserName;

                usuario.Roles.Add(identityRol);
                context.SaveChanges();

                return Resultado_Correcto(model);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        [Authorize]
        public JuegaJson DeleteUserFromRol(Usuario_Rol model)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var rol = roleManager.FindById(model.IdRol);

                if (rol == null)
                    return Resultado_Advertencia("El rol al que intenta actualizar no existe.");

                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));
                var usuario = userManager.FindById(model.IdUsuario);


                if (usuario == null)
                    return Resultado_Advertencia("El usuario al que intenta eliminar no existe.");

                var identityRol = new IdentityUserRole();
                identityRol.RoleId = model.IdRol;
                identityRol.UserId = model.Usuario;

                usuario.Roles.Add(identityRol);
                usuario.Roles.Remove(identityRol);

                return Resultado_Correcto(rol);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

    }
}