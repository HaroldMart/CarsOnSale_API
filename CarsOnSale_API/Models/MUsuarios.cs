using Microsoft.AspNetCore.Authentication;

namespace CarsOnSale_API.Models
{
    public class MUsuarios
    {
        public int ID { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string clave { get; set; }

        public string direccion { get; set; }

        public int ID_Provincia { get; set; }

        public string telefono { get; set; }

    }
}
