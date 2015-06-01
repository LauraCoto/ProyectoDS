using Juega.BDD;
using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
     [Authorize(Roles = Utilidades.Roles.AdminSistema)]
    public class MenuController : JuegaController
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

                _db.Configuration.ProxyCreationEnabled = false;
                _db.Configuration.LazyLoadingEnabled = false;

                var lista = _db.Menu.ToList();

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        public JuegaJson GetMenu()
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                _db.Configuration.LazyLoadingEnabled = false;

                var menu = _db.Menu.Where(x => x.IdMenuPadre == null).OrderBy(y => y.Orden).ToList();

                if (menu == null)
                    return Resultado_Error("Error al cargar el menu.");

                var lista = new List<MenuPrincipal>();

                foreach (var item in menu)
                {
                    var mp = new MenuPrincipal();

                    var qNodosHijos = _db.Menu.Where(x => x.IdMenuPadre == item.IdMenu);
                    if (qNodosHijos == null)
                        continue;

                    var listaNodosHijos = qNodosHijos.ToList();
                    if (listaNodosHijos.Count() <= 0)
                        continue;


                    mp.IdMenu = item.IdMenu.ToString();
                    mp.Descripcion = item.Descripcion;
                    mp.Action = item.Action;
                    mp.Controller = item.Controller;
                    mp.UrlIcono = item.UrlIcon;
                    mp.ListaHijos = new List<MenuPrincipal>();

                    foreach (var itemHijo in listaNodosHijos)
                    {
                        var hijo = new MenuPrincipal();
                        hijo.IdMenu = item.IdMenu.ToString();
                        hijo.Action = itemHijo.Action;
                        hijo.Controller = itemHijo.Controller;
                        hijo.Descripcion = itemHijo.Descripcion;
                        hijo.UrlIcono = itemHijo.UrlIcon;


                        mp.ListaHijos.Add(hijo);

                    }

                    lista.Add(mp);
                }


                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        public JuegaJson GetControllers()
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var controladores = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type));

                var lista = new List<Controladores>();

                lista.Add(new Controladores());
                foreach (var c in controladores)
                {
                    var cc = new Controladores();
                    cc.Nombre = c.Name.Replace("Controller", "");
                    lista.Add(cc);
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Create(Menu menu)
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(menu.Descripcion, -1))
                    return Resultado_Advertencia("Ya existe un elemento del menu con el mismo nombre.");

                _db.Menu.Add(menu);
                _db.SaveChanges();

                return Resultado_Correcto(menu, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Update(Menu menu)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                if (ExisteRegistro(menu.Descripcion, menu.IdMenu))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(menu).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(menu, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Delete(Menu menu)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (menu == null)
                    return Resultado_Advertencia("El registro no es valido.");

                var item = _db.Menu.FirstOrDefault(x => x.IdMenu == menu.IdMenu);

                if (item == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                var menus = _db.Menu.Select(x => x.IdMenuPadre == item.IdMenu && x.Activo == true).ToList();

                //if (item..Count() > 0)
                //    return Resultado_Advertencia("Este elemento del menu contiene registros hijos, debe eliminarlos.");


                _db.Menu.Remove(item);
                _db.SaveChanges();

                return Resultado_Correcto(menu, "El registro ha sido eliminado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var item = _db.Menu.FirstOrDefault(x => x.Descripcion == nombre &&
                                                                x.IdMenu != IdExcluir
                                                                );

            return item != null;
        }
    }
}
