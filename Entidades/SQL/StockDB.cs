using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Stock;

namespace Entidades.SQL
{
    public static class StockDB
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //Nombre tabla
        const string NOMBRE_TABLA = "Stock";
        //Nombre columnas
        const string HARINA = "Harina";
        const string AZUCAR = "Azucar";
        const string GELATINA = "Gelatina";
        const string LEUDANTE = "Leudantes";
        const string ALMIDON = "Almidon";
        const string GELIFICANTE = "Gelificantes";

        static StockDB()
        {
            connectionString = @"Data Source=.;Initial Catalog=ParcialLaboratorio;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }


        /// <summary>
        /// Carga el stock desde la base de datos.
        /// </summary>
        public static void CargarStock()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"SELECT * FROM {NOMBRE_TABLA}";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Stock.Harina = (int)reader[HARINA];
                        Stock.Azucar = (int)reader[AZUCAR];
                        Stock.SGelatina = (int)reader[GELATINA];
                        Stock.Leudantes = (int)reader[LEUDANTE];
                        Stock.Almidon = (int)reader[ALMIDON];
                        Stock.Gelificantes = (int)reader[GELIFICANTE];

                        foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
                        {
                            Stock.SetearStockSabor((int)reader[sabor.ToString()], sabor);
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
        /// Actualiza el stock en la base de datos.
        /// </summary>
        public static void ActualizarStock()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();

                command.CommandText = $"UPDATE {NOMBRE_TABLA} SET " +
                                      $"{HARINA} = @Harina, " +
                                      $"{AZUCAR} = @Azucar, " +
                                      $"{GELATINA} = @Gelatina, " +
                                      $"{LEUDANTE} = @Leudante, " +
                                      $"{ALMIDON} = @Almidon, " +
                                      $"{GELIFICANTE} = @Gelificante";

                command.Parameters.AddWithValue("@Harina", Stock.Harina);
                command.Parameters.AddWithValue("@Azucar", Stock.Azucar);
                command.Parameters.AddWithValue("@Gelatina", Stock.SGelatina);
                command.Parameters.AddWithValue("@Leudante", Stock.Leudantes);
                command.Parameters.AddWithValue("@Almidon", Stock.Almidon);
                command.Parameters.AddWithValue("@Gelificante", Stock.Gelificantes);

                command.ExecuteNonQuery();

                foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
                {
                    command.CommandText = $"UPDATE {NOMBRE_TABLA} SET {sabor} = @{sabor}";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue($"@{sabor}", Stock.ObtenerStockSabor(sabor));
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
