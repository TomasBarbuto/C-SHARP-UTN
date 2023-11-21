using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Interfaces;
using static Entidades.Stock;

namespace Entidades.Productos
{
    /// <summary>
    /// Clase que representa un tipo específico de producto: Gelatina.
    /// </summary>
    public class Gelatina : Producto, IProduccion
    {
        private static int gelatinasFrambuesaCocinados;
        private static int gelatinasFrutillaCocinados;
        private static int gelatinasCerezaCocinados;
        /// <summary>
        /// Obtiene o establece las cantidades de los diferentes sabores de gelatina disponibles en el stock.
        /// </summary>
        private static Dictionary<Sabor, int> cantidades = new Dictionary<Sabor, int>
        {
            { Sabor.Frambuesa, 0 },
            { Sabor.Frutilla, 0 },
            { Sabor.Cereza, 0 }
        };

        /// <summary>
        /// Representa las cantidades de los diferentes sabores de flan disponibles en el stock. Proporciona métodos de acceso para obtener y establecer los valores de las cantidades.
        /// </summary>

        public static Dictionary<Sabor, int> Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }

        public static int GelatinasFrambuesaCocinadas
        {
            get { return gelatinasFrambuesaCocinados; }
            set { gelatinasFrambuesaCocinados = value; }
        }

        public static int GelatinasFrutillaCocinadas
        {
            get { return gelatinasFrutillaCocinados; }
            set { gelatinasFrutillaCocinados = value; }
        }

        public static int GelatinasCerezaCocinadas
        {
            get { return gelatinasCerezaCocinados; }
            set { gelatinasCerezaCocinados = value; }
        }

        /// <summary>
        /// Constructor para la clase Gelatina.
        /// </summary>
        /// <param name="nombre">Nombre de la gelatina.</param>
        public Gelatina(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Método para producir una gelatina de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor de la gelatina a producir.</param>
        /// <returns>Devuelve verdadero si la gelatina se produce con éxito; de lo contrario, falso.</returns>

        public override bool Producir(Sabor sabor)
        {
            int cantidadGelatina = 20;
            int cantidadAzucar = 20;
            int cantidadSabor = 10;

            List<(string, int)> materiasPrimas = new List<(string, int)>
            {
                ("Gelatina", cantidadGelatina),
                ("Azucar", cantidadAzucar),
                (sabor.ToString(), cantidadSabor)
            };

            if (Stock.UsarMateriasPrimas(materiasPrimas))
            {
                Cantidades[sabor] += 1;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Método para cocinar un cierto número de gelatinas de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor de la gelatina a cocinar.</param>
        /// <param name="cantidad">Cantidad de gelatinas a cocinar.</param>
        /// <returns>Devuelve verdadero si se cocinan las gelatinas con éxito; de lo contrario, falso.</returns>
        public override bool Cocinar(Sabor sabor, int cantidad)
        {
            bool retorno = false;
            if (Cantidades.ContainsKey(sabor))
            {
                if (Cantidades[sabor] >= cantidad)
                {
                    switch (sabor)
                    {
                        case Sabor.Frambuesa:
                            gelatinasFrambuesaCocinados += cantidad;
                            break;
                        case Sabor.Frutilla:
                            gelatinasFrutillaCocinados += cantidad;
                            break;
                        case Sabor.Cereza:
                            gelatinasCerezaCocinados += cantidad;
                            break;
                    }

                    Cantidades[sabor] -= cantidad;
                    return true;
                }
            }
            return retorno;
        }

        public static Dictionary<string, int> ObtenerCantidadesFabricadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("GelatinaCereza", Cantidades[Sabor.Cereza]);
            todasLasCantidades.Add("GelatinaFrutilla", Cantidades[Sabor.Frutilla]);
            todasLasCantidades.Add("GelatinaFrambuesa", Cantidades[Sabor.Frambuesa]);
            return todasLasCantidades;
        }
        /// <summary>
        /// Método estático para obtener la cantidad de gelatinas cocinadas de cada sabor actualmente.
        /// </summary>
        /// <returns>Detalles del stock de gelatinas cocinadas en forma de dictionary.</returns>

        public static Dictionary<string, int> ObtenerCantidadesCocinadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("GelatinaCereza", gelatinasCerezaCocinados);
            todasLasCantidades.Add("GelatinaFrutilla", gelatinasFrutillaCocinados);
            todasLasCantidades.Add("GelatinaFrambuesa", gelatinasFrambuesaCocinados);
            return todasLasCantidades;
        }
    }
}
