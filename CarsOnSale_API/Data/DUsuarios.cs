using CarsOnSale_API.Conexion;
using CarsOnSale_API.Models;
using System.Data.SqlClient;
using System.Data;

namespace CarsOnSale_API.Data
{
    public class DUsuarios
    {
        ConexionDB cn = new ConexionDB();

        public async Task <List<MUsuarios>> MostrarUsuarios()
        {
            var list = new List<MUsuarios>();

            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_ListaUsuarios", sql))
                {
                    await sql.OpenAsync();

                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var usuarios = new MUsuarios();

                            usuarios.Id = (int)item["Id"];
                            usuarios.NombreDeUsuario = (string)item["NombreDeUsuario"];
                            usuarios.Nombre = (string)item["Nombre"];
                            usuarios.Apellido = (string)item["Apellido"];
                            usuarios.clave = (string)item["clave"];
                            usuarios.Correo = (string)item["Correo"];
                            usuarios.Telefono = (string)item["Telefono"];
                            
                            list.Add(usuarios);
                        }
                    }
                }
            }

            return list;
        }

        public async Task InsertarUsuario(MUsuarios parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_registrar", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreDeUsuario", parametros.NombreDeUsuario);
                    cmd.Parameters.AddWithValue("@clave", parametros.clave);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", parametros.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }

        public async Task ActualizarUsuario(MUsuarios parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_modificarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", parametros.Id);
                    cmd.Parameters.AddWithValue("@NombreDeUsuario", parametros.NombreDeUsuario);
                    cmd.Parameters.AddWithValue("@clave", parametros.clave);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", parametros.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }

        public async Task EliminarUsuario(MUsuarios parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("[SP_eliminarRegistro]", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", parametros.Id);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
    }
}
