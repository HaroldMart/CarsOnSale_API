using Microsoft.AspNetCore.Authentication;

namespace CarsOnSale_API.Models
{
    public class MUsuarios
    {
        public int Id { get; set; }

        public string NombreDeUsuario { get; set; }

        public string clave { get; set; }

        public string Nombre { get; set;}

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

    }
}
