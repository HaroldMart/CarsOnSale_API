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
                using(var cmd = new SqlCommand("getAllUsers", sql))
                {
                    await sql.OpenAsync();

                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var usuarios = new MUsuarios();

                            usuarios.ID = (int)item["ID"];
                            usuarios.nombres = (string)item["nombres"];
                            usuarios.apellidos = (string)item["apellidos"];
                            usuarios.clave = (string)item["clave"];
                            usuarios.direccion = (string)item["direccion"];
                            usuarios.ID_Provincia = (int)item["ID_Provincia"];
                            usuarios.telefono = (string)item["telefono"];
                            
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
                using(var cmd = new SqlCommand("addUser", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", parametros.nombres);
                    cmd.Parameters.AddWithValue("@lastname", parametros.apellidos);
                    cmd.Parameters.AddWithValue("@clave", parametros.clave);
                    cmd.Parameters.AddWithValue("@addres", parametros.direccion);
                    cmd.Parameters.AddWithValue("@provincia", parametros.ID_Provincia);
                    cmd.Parameters.AddWithValue("@tel", parametros.telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }

        public async Task ActualizarUsuario(MUsuarios parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("upUser", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.ID);
                    cmd.Parameters.AddWithValue("@name", parametros.nombres);
                    cmd.Parameters.AddWithValue("@lastname", parametros.apellidos);
                    cmd.Parameters.AddWithValue("@clave", parametros.clave);
                    cmd.Parameters.AddWithValue("@addres", parametros.direccion);
                    cmd.Parameters.AddWithValue("@provincia", parametros.ID_Provincia);
                    cmd.Parameters.AddWithValue("@tel", parametros.telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }

        public async Task EliminarUsuario(MUsuarios parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("[delUser]", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.ID);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
    }
}
