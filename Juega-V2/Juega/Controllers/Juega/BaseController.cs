using Juega.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class BaseController : Controller
    {
        internal JuegaEntities _db = new JuegaEntities();
        internal Mensajes status;

        internal bool UsuarioAutenticado()
        {
            status = Mensajes.L600;
            return Request.IsAuthenticated; 
        }


        internal System.Web.Security.MembershipUser ObtenerUsuario_MemberShip()
        {
            var usuario = System.Web.Security.Membership.GetUser(User.Identity.Name);

            return usuario;
        }


        internal Usuario ObtenerUsuario_Juega()
        {
            var memberShip = ObtenerUsuario_MemberShip();

            if (memberShip != null)
                return null;


            var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == 1);

            return usuario; 

        }
        internal bool TieneAcceso()
        {
            status = Mensajes.L700;

            if (!UsuarioAutenticado())
                return false;
             
             

            return true;

        }


        public  List<string> FindUsersByRole(string[] roles)
        {
            var userList = roles.Select(role => System.Web.Security.Roles.GetUsersInRole(role))
                                .Aggregate((a, b) => a.Union(b).ToArray())
                                .Distinct()
                                .ToList();
            return userList;
        }

        public  List<System.Web.Security.MembershipUser> __FindUsersByRole(string[] roles)
        {
            var userList = roles.Select(role => System.Web.Security.Roles.GetUsersInRole(role))
                                .Aggregate((a, b) => a.Union(b).ToArray())
                                .Distinct()
                                .Select(user => System.Web.Security.Membership.GetUser(user))
                                .ToList();
            return userList;
        } 

        public  System.Web.Security.MembershipUserCollection _FindUsersByRole(string[] roles)
        {
            var msc = new System.Web.Security.MembershipUserCollection();

            roles.Select(role => System.Web.Security.Roles.GetUsersInRole(role))
            .Aggregate((a, b) => a.Union(b).ToArray())
            .Distinct()
            .Select(user => System.Web.Security.Membership.GetUser(user))
            .ToList().ForEach(user => msc.Add(user));

            return msc;
        }


    }
}