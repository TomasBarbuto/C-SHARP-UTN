using Entidades.Interfaces;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Usuarios.Usuario;

namespace Entidades.SQL
{
    public static class UsuarioDB
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //Nombre tabla
        const string NOMBRE_TABLA = "Usuarios";
        //Nombre columnas
        const string ID_USUARIO = "idUsuario";
        const string NOMBRE_USUARIO = "NombreUsuario";
        const string DNI_USUARIO = "DNIUsuario";
        const string CONSTRASENIA = "Contrasenia";
        const string TIPO_USUARIO = "TipoUsuario";

        static UsuarioDB()
        {
            connectionString = @"Data Source=.;Initial Catalog=ParcialLaboratorio;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="DniUsuario">DNI del usuario.</param>
        /// <param name="contrasenia">Contraseña del usuario.</param>
        /// <param name="tipoUsuario">Tipo de usuario.</param>
        public static void Insert(string idUsuario, string nombreUsuario, int DniUsuario, string contrasenia, int tipoUsuario)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"INSERT INTO {NOMBRE_TABLA} " +
                                      $"({ID_USUARIO}, {NOMBRE_USUARIO}, {DNI_USUARIO}, {CONSTRASENIA}, {TIPO_USUARIO}) " +
                                      "VALUES (@IdUsuario, @NombreUsuario, @DniUsuario, @Contrasenia, @TipoUsuario)";

                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@DniUsuario", DniUsuario);
                command.Parameters.AddWithValue("@Contrasenia", contrasenia);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

                int rows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Actualiza un campo específico de un usuario en la base de datos.
        /// </summary>
        /// <param name="campoAModificar">Campo a modificar.</param>
        /// <param name="nuevoValor">Nuevo valor del campo.</param>
        /// <param name="idUsuario">Identificador del usuario.</param>
        public static void Update(string campoAModificar, string nuevoValor, string idUsuario)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {campoAModificar} = @NuevoValor WHERE {ID_USUARIO} = @IdUsuario";

                command.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Obtiene un usuario de la base de datos por su ID.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Usuario obtenido de la base de datos.</returns>
        public static Usuario Select(string idUsuario)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"SELECT * FROM {NOMBRE_TABLA} WHERE {ID_USUARIO} = @IdUsuario";
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                Usuario usuario = null;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int tipoUsuario = Convert.ToInt32(reader[TIPO_USUARIO]);

                        if (tipoUsuario == (int)Usuario.TipoUsuario.Administrador)
                        {
                            usuario = new Supervisor();
                        }
                        else if (tipoUsuario == (int)Usuario.TipoUsuario.Empleado)
                        {
                            usuario = new Operario();
                        }

                        if (usuario is not null)
                        {
                            usuario.NombreUsuario = Convert.ToString(reader[NOMBRE_USUARIO]);
                            usuario.DniUsuario = Convert.ToInt32(reader[DNI_USUARIO]);
                            usuario.Contrasenia = Convert.ToString(reader[CONSTRASENIA]);
                            usuario.Tipo = (Usuario.TipoUsuario)tipoUsuario;
                        }
                    }
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios almacenados en la base de datos.
        /// </summary>
        /// <returns>Lista de usuarios almacenados en la base de datos.</returns>
        public static List<Usuario> SelectAll()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"SELECT * FROM {NOMBRE_TABLA}";

                List<Usuario> usuarios = new List<Usuario>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tipoUsuario = Convert.ToInt32(reader[TIPO_USUARIO]);

                        Usuario usuario = null;

                        if (tipoUsuario == (int)Usuario.TipoUsuario.Administrador)
                        {
                            usuario = new Supervisor();
                            
                        }
                        else if (tipoUsuario == (int)Usuario.TipoUsuario.Empleado)
                        {
                            usuario = new Operario();
                        }

                        usuario.NombreUsuario = Convert.ToString(reader[NOMBRE_USUARIO]);
                        usuario.DniUsuario = Convert.ToInt32(reader[DNI_USUARIO]);
                        usuario.Contrasenia = Convert.ToString(reader[CONSTRASENIA]);
                        usuario.Tipo = (Usuario.TipoUsuario)tipoUsuario;

                        usuarios.Add(usuario); 
                    }
                }

                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos por su ID.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario a eliminar.</param>
        public static void Delete(string idUsuario)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"DELETE FROM {NOMBRE_TABLA} WHERE {ID_USUARIO} = @IdUsuario";
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception($"No se encontró ningún usuario con el ID {idUsuario} para eliminar.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
