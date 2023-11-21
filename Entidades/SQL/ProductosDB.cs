using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Stock;

namespace Entidades.SQL
{   

    public static class ProductosDB
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //Nombre tabla
        const string NOMBRE_TABLA = "Productos";
        //Nombre columnas
        const string IDPRODUCTO = "NumeroProducto";
        const string PRODUCTO = "Producto";
        const string CANTIDAD_FABRICADA = "CantidadFabricada";
        const string CANTIDAD_COCINADA = "CantidadCocinada";

        static ProductosDB()
        {
            connectionString = @"Data Source=.;Initial Catalog=ParcialLaboratorio;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// Carga la cantidad de productos fabricados desde la base de datos a las cantidades de los productos en el sistema.
        /// </summary>
        public static void CargarProductosFabricados()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"SELECT * FROM {NOMBRE_TABLA}";

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read()) { 
                        string nombreProducto = reader[PRODUCTO].ToString();

                        if (nombreProducto == "BizcochueloCoco")
                        {
                            Bizcochuelo.Cantidades[Sabor.Coco] = (int)reader["CantidadFabricada"];
                        }
                        
                        if (nombreProducto == "BizcochueloVainilla")
                        {
                            Bizcochuelo.Cantidades[Sabor.Vainilla] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "BizcochueloChocolate")
                        {
                            Bizcochuelo.Cantidades[Sabor.Chocolate] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "FlanChocolate")
                        {
                            Flan.Cantidades[Sabor.Chocolate] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "FlanVainilla")
                        {
                            Flan.Cantidades[Sabor.Vainilla] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "FlanCaramelo")
                        {
                            Flan.Cantidades[Sabor.Caramelo] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "GelatinaCereza")
                        {
                            Gelatina.Cantidades[Sabor.Cereza] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "GelatinaFrutilla")
                        {
                            Gelatina.Cantidades[Sabor.Frutilla] = (int)reader["CantidadFabricada"];
                        }

                        if (nombreProducto == "GelatinaFrambuesa")
                        {
                            Gelatina.Cantidades[Sabor.Frambuesa] = (int)reader["CantidadFabricada"];
                        }
                    }
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

        /// <summary>
        /// Carga la cantidad de productos cocinados desde la base de datos a las cantidades de los productos en el sistema.
        /// </summary>
        public static void CargarProductosCocinados()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"SELECT * FROM {NOMBRE_TABLA}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreProducto = reader[PRODUCTO].ToString();

                        if (nombreProducto == "BizcochueloCoco")
                        {
                            Bizcochuelo.BizcochuelosCocoCocinados = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "BizcochueloVainilla")
                        {
                            Bizcochuelo.BizcochuelosVainillaCocinados = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "BizcochueloChocolate")
                        {
                            Bizcochuelo.BizcochuelosChocolateCocinados = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "FlanChocolate")
                        {
                            Flan.FlanesChocolateCocinados = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "FlanVainilla")
                        {
                            Flan.FlanesVainillaCocinados = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "FlanCaramelo")
                        {
                            Flan.FlanesCarameloCocinados = (int)reader["CantidadCocinada"];
                        }

                        if(nombreProducto == "GelatinaCereza")
                        {
                            Gelatina.GelatinasCerezaCocinadas = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "GelatinaFrutilla")
                        {
                            Gelatina.GelatinasFrutillaCocinadas = (int)reader["CantidadCocinada"];
                        }

                        if (nombreProducto == "GelatinaFrambuesa")
                        {
                            Gelatina.GelatinasFrambuesaCocinadas = (int)reader["CantidadCocinada"];
                        }
                    }
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

        /// <summary>
        /// Actualiza la cantidad de productos fabricados en la base de datos.
        /// </summary>
        public static void ActualizarProductosFabricados()
        {
            try
            {
                connection.Open();

                foreach (var item in Bizcochuelo.ObtenerCantidadesFabricadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_FABRICADA} = @CantidadFabricada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadFabricada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
                }

                foreach (var item in Flan.ObtenerCantidadesFabricadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_FABRICADA} = @CantidadFabricada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadFabricada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
                }

                foreach (var item in Gelatina.ObtenerCantidadesFabricadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_FABRICADA} = @CantidadFabricada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadFabricada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
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

        /// <summary>
        /// Actualiza la cantidad de productos cocinados en la base de datos.
        /// </summary>
        public static void ActualizarProductosCocinados()
        {
            try
            {
                connection.Open();

                foreach (var item in Bizcochuelo.ObtenerCantidadesCocinadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_COCINADA} = @CantidadCocinada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadCocinada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
                }

                foreach (var item in Flan.ObtenerCantidadesCocinadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_COCINADA} = @CantidadCocinada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadCocinada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
                }

                foreach (var item in Gelatina.ObtenerCantidadesCocinadas())
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {CANTIDAD_COCINADA} = @CantidadCocinada WHERE {PRODUCTO} = @Producto";
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CantidadCocinada", item.Value);
                    command.Parameters.AddWithValue("@Producto", item.Key);

                    command.ExecuteNonQuery();
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
