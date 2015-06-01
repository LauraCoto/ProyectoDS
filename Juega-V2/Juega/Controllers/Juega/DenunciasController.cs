using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    public class DenunciasController : JuegaController
    {
        // GET: Denuncias
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

                _db.Configuration.ProxyCreationEnabled = false;

                var denuncias = _db.Denuncia.Where(x => x.TipoEstado == "Pendiente").ToList();
                var canchas = _db.Cancha.ToList();
                var equipos = _db.Equipo.ToList();
                var usuarios = _db.Usuario.ToList();




                var lista = new List<DenunciasModelo>();

                foreach (var d in denuncias)
                {

                    var dm = new DenunciasModelo();

                    if (d.IdCanchaDenunciada != null)
                    {
                        var c = canchas.FirstOrDefault(x => x.IdCancha == d.IdCanchaDenunciada);
                        dm.IdCancha = d.IdCanchaDenunciada.ToString();
                        dm.Cancha = c == null ? "" : c.Nombre;
                    }


                    if (d.IdUsuarioDenuncia != null)
                    {
                        var ud = usuarios.FirstOrDefault(x => x.IdUsuario == d.IdUsuarioDenuncia);
                        dm.IdUsuarioDenuncia = d.IdUsuarioDenuncia.ToString();
                        dm.UsuarioDenuncia = ud == null ? "" : ud.Nombre;
                    }

                    if (d.IdUsuarioDenunciado != null)
                    {
                        var ud2 = usuarios.FirstOrDefault(x => x.IdUsuario == d.IdUsuarioDenunciado);
                        dm.IdUsuarioDenunciado = d.IdUsuarioDenunciado.ToString();
                        dm.UsuarioDenunciado = ud2 == null ? "" : ud2.Nombre;
                    }

                    if (d.Equipo != null)
                    {
                        var e = equipos.FirstOrDefault(x => x.IdEquipo == d.IdEquipoDenunciado);
                        dm.IdEquipo = d.IdEquipoDenunciado.ToString();
                        dm.Equipo = e == null ? "" : e.Nombre;
                    }
                    dm.IdDenuncia = d.IdDenuncia.ToString();
                    dm.Descripcion = d.Descripcion;
                    
                    lista.Add(dm);
                    
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }

        }

       
        public JuegaJson Ignorar(DenunciasModelo modelo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var nIdDenuncia = int.Parse(modelo.IdDenuncia);
                var denuncia = _db.Denuncia.FirstOrDefault(x => x.IdDenuncia == nIdDenuncia);
                denuncia.TipoEstado = "Rechazado";


                _db.Entry(denuncia).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(modelo, "La Denuncia ha sido Rechazada.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }



        public JuegaJson BloquearEquipo(DenunciasModelo modelo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var nIdDenuncia = int.Parse(modelo.IdDenuncia);
                var denuncia = _db.Denuncia.FirstOrDefault(x => x.IdDenuncia == nIdDenuncia);
                denuncia.TipoEstado = "Procesado";


                var nIdEquipo = int.Parse(modelo.IdEquipo);
                var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == nIdEquipo);
                equipo.TipoEstado = "Bloqueado";


                _db.Entry(denuncia).State = EntityState.Modified;
                _db.Entry(equipo).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(modelo, "La Denuncia ha sido Procesada,Equipo Bloqueado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        public JuegaJson BloquearCancha(DenunciasModelo modelo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var nIdDenuncia = int.Parse(modelo.IdDenuncia);
                var denuncia = _db.Denuncia.FirstOrDefault(x => x.IdDenuncia == nIdDenuncia);
                denuncia.TipoEstado = "Procesado";


                var nIdCancha = int.Parse(modelo.IdCancha);
                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == nIdCancha);
                cancha.TipoEstado = "Bloqueado";


                _db.Entry(denuncia).State = EntityState.Modified;
                _db.Entry(cancha).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(modelo, "La Denuncia ha sido Procesada,Equipo Bloqueado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        public JuegaJson BloquearUsuario(DenunciasModelo modelo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var nIdDenuncia = int.Parse(modelo.IdDenuncia);
                var denuncia = _db.Denuncia.FirstOrDefault(x => x.IdDenuncia == nIdDenuncia);
                denuncia.TipoEstado = "Procesado";


                var nIdUsuario = int.Parse(modelo.IdUsuarioDenunciado);
                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nIdUsuario);
                usuario.TipoEstado = "Bloqueado";

                var UsersContext = new ApplicationDbContext();
                var users = UsersContext.Users.ToList();

                var usuarioseguridad = users.FirstOrDefault(x => x.Id == usuario.IdUsuarioSeguridad);
                usuarioseguridad.LockoutEnabled = true;

                


                _db.Entry(denuncia).State = EntityState.Modified;
                _db.Entry(usuario).State = EntityState.Modified;
                _db.SaveChanges();
                UsersContext.SaveChanges();


                return Resultado_Correcto(modelo, "La Denuncia ha sido Procesada,Equipo Bloqueado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }











    }
}