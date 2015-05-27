using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Juega.Utilidades;

namespace Juega
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //private enum ConexionUsar
        //{
        //    AppHarbor = 1,
        //    Dramos = 2,
        //    DBustillo = 3,
        //    Rudy = 4,
        //    Laura = 5,
        //    Javier = 6,
        //    Cris = 7,
        //    Maynor = 8,
        //    Jesus = 9,
        //}

        //public static string ObtenerCadenaConexion_Seguridad()
        //{
        //    var cnn = ConexionUsar.Dramos;

        //    switch (cnn)
        //    {
        //        case ConexionUsar.AppHarbor:
        //            return "Seguridad.AppHarbor";

        //        case ConexionUsar.Dramos:
        //            return "Seguridad.dramos";

        //        case ConexionUsar.DBustillo:
        //            return "Seguridad.dbustillo";

        //        case ConexionUsar.Rudy:
        //            return "Seguridad.Rudy";

        //        case ConexionUsar.Laura:
        //            return "Seguridad.Laura";

        //        case ConexionUsar.Javier:
        //            return "Seguridad.Javier";

        //        case ConexionUsar.Cris:
        //            return "Seguridad.Cris";

        //        case ConexionUsar.Maynor:
        //            return "Seguridad.Maynor";

        //        case ConexionUsar.Jesus:
        //            return "Seguridad.Jesus";
        //    }

        //    return "Seguridad.AppHarbor";
        //}



        public ApplicationDbContext() : base(Juega.Utilidades.Conexiones.ObtenerCadenaConexion_Seguridad(), throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}