namespace Juega.Models.Juega
{
    public class Usuario_Rol
    {
        public Usuario_Rol() { }

        public Usuario_Rol(string _idRol, string _rol, string _idUsuario, string _usuario)
        {
            IdRol = _idRol;
            Rol = _rol;

            IdUsuario = _idUsuario;
            Usuario = _usuario;
        }

        public virtual string IdRol { get; set; }
        public virtual string Rol { get; set; }


        public virtual string IdUsuario { get; set; }
        public virtual string Usuario { get; set; }
    }
}