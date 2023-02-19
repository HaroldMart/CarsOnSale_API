using CarsOnSale_API.Data;
using CarsOnSale_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Security.Cryptography.X509Certificates;

namespace CarsOnSale_API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : Controller
    {
        //Metodo Get de todos los usuarios
        [HttpGet]
        public async Task <ActionResult<List<MUsuarios>>> Get()
        {
            var function = new DUsuarios();

            var list = await function.MostrarUsuarios();

            return list;
        }

        //Metodo Post para registrar usuarios
        [HttpPost]
        public async Task Post([FromBody] MUsuarios parametros)
        {
            var function = new DUsuarios();

            await function.InsertarUsuario(parametros);
        }

        //Metodo Put para actualizar un usuario
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] MUsuarios parametros)
        {
            var function = new DUsuarios();
            parametros.ID = id;

            await function.ActualizarUsuario(parametros);
            return NoContent();
        }

        //Metodo Delete para eliminar un usuario
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var function = new DUsuarios();
            var parametros = new MUsuarios();
            parametros.ID = id;

            await function.EliminarUsuario(parametros);
            return NoContent();
        }
    }
}
