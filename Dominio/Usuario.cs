namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}
