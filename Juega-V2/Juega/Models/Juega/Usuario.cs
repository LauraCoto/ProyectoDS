namespace Juega.Models.Juega
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string _id, string _nombre)
        {
            Id = _id;
            Nombre = _nombre;
        }

        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
    }
}