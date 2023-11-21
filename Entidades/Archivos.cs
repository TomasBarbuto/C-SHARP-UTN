using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{

    /// <summary>
    /// Clase estática que gestiona la manipulación de archivos en la aplicación.
    /// </summary>
    public static class Archivos
    {
        private const string Directorio = "C:\\Users\\RYZEN\\Desktop\\laboratorio_2_Parcial\\";
        private const string pathTXT = Directorio + "Errores.txt";
        private const string pathXML = Directorio + "Stock.xml";
        private const string pathJSON = Directorio + "configuracion.json";

        // Clase interna para almacenar detalles de errores.
        private class RegistroDeErrores
        {
            public DateTime FechaHora { get; set; }
            public string Descripcion { get; set; }
            public string Clase { get; set; }
            public string Metodo { get; set; }
        }

        /// <summary>
        /// Registra un error en el archivo de log.
        /// </summary>
        /// <param name="ex">La excepción que se registrará.</param>
        /// <param name="clase">El nombre de la clase donde ocurrió el error.</param>
        /// <param name="metodo">El nombre del método donde ocurrió el error.</param>
        public static void AgregarErrorLog(Exception ex, string clase, string metodo)
        {
            RegistroDeErrores error = new RegistroDeErrores
            {
                FechaHora = DateTime.Now,
                Descripcion = ex.Message,
                Clase = clase,
                Metodo = metodo
            };

            GuardarRegistroLog(error);
        }

        /// <summary>
        /// Guarda un registro de error en un archivo de texto.
        /// </summary>
        /// <param name="error">El objeto que contiene detalles del error.</param>
        private static void GuardarRegistroLog(RegistroDeErrores error)
        {
            if (!Directory.Exists(Directorio))
            {
                Directory.CreateDirectory(Directorio);
            }

            using (StreamWriter writer = new StreamWriter(pathTXT, true))
            {
                writer.WriteLine($"Fecha y Hora: {error.FechaHora}");
                writer.WriteLine($"Descripción: {error.Descripcion}");
                writer.WriteLine($"Clase: {error.Clase}");
                writer.WriteLine($"Método: {error.Metodo}");
                writer.WriteLine("".PadRight(30, '-'));
            }
        }

        /// <summary>
        /// Guarda datos de stock de manera asíncrona en un archivo XML.
        /// </summary>
        /// <typeparam name="T">El tipo de datos de stock.</typeparam>
        /// <param name="datosStock">Los datos de stock a guardar.</param>
        /// <param name="cancellationToken">Token de cancelación para la tarea asíncrona.</param>
        public static async Task GuardarStockXMLAsync<T>(T datosStock, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                XmlDocument documento = new XmlDocument();
                XmlElement titulo = documento.CreateElement("Stock");

                if (datosStock is IEnumerable<KeyValuePair<string, int>> enumerableStock)
                {
                    foreach (var data in enumerableStock)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }

                        XmlElement itemElement = documento.CreateElement("MateriaPrima");
                        itemElement.SetAttribute("Nombre", data.Key);
                        itemElement.SetAttribute("Cantidad", data.Value.ToString());
                        titulo.AppendChild(itemElement);
                    }
                }
                documento.AppendChild(titulo);
                documento.Save(pathXML);
            }, cancellationToken);
        }
    }
}
