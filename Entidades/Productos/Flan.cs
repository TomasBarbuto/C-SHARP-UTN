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
    /// Clase que representa un tipo específico de producto: Flan.
    /// </summary>
    public class Flan : Producto, IProduccion
    {
        private static int flanesCarameloCocinados;
        private static int flanesChocolateCocinados;
        private static int flanesVainillaCocinados;
        /// <summary>
        /// Obtiene o establece las cantidades de los diferentes sabores de flan disponibles en el stock.
        /// </summary>
        private static Dictionary<Sabor, int> cantidades = new Dictionary<Sabor, int>
        {
            { Sabor.Chocolate, 0 },
            { Sabor.Vainilla, 0 },
            { Sabor.Caramelo, 0 }
        };

        /// <summary>
        /// Representa las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock. Proporciona métodos de acceso para obtener y establecer los valores de las cantidades.
        /// </summary>

        public static Dictionary<Sabor, int> Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }

        public static int FlanesCarameloCocinados
        {
            get { return flanesCarameloCocinados; }
            set { flanesCarameloCocinados = value; }
        }

        public static int FlanesChocolateCocinados
        {
            get { return flanesChocolateCocinados; }
            set { flanesChocolateCocinados = value; }
        }

        public static int FlanesVainillaCocinados
        {
            get { return flanesVainillaCocinados; }
            set { flanesVainillaCocinados = value; }
        }

        /// <summary>
        /// Constructor para la clase Flan.
        /// </summary>
        /// <param name="nombre">Nombre del flan.</param>
        public Flan(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Método para producir un flan de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del flan a producir.</param>
        /// <returns>Devuelve verdadero si el flan se produce con éxito; de lo contrario, falso.</returns>
        public override bool Producir(Sabor sabor)
        {
            int cantidadAlmidon = 0;
            int cantidadAzucar = 0;
            int cantidadGelificante = 10;
            int cantidadSabor = 10;

            switch (sabor)
            {
                case Sabor.Chocolate:
                    cantidadAlmidon = 15;
                    cantidadAzucar = 15;
                    break;
                case Sabor.Caramelo:
                    cantidadAlmidon = 10;
                    cantidadAzucar = 20;
                    break;
                case Sabor.Vainilla:
                    cantidadAlmidon = 10;
                    cantidadAzucar = 20;
                    break;
            }

            List<(string, int)> materiasPrimas = new List<(string, int)>
            {
                ("Almidon", cantidadAlmidon),
                ("Gelificante", cantidadGelificante),
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
        /// Método para cocinar un cierto número de flanes de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del flan a cocinar.</param>
        /// <param name="cantidad">Cantidad de flanes a cocinar.</param>
        /// <returns>Devuelve verdadero si se cocinan los flanes con éxito; de lo contrario, falso.</returns>
        public override bool Cocinar(Sabor sabor, int cantidad)
        {
            bool retorno = false;
            if (Cantidades.ContainsKey(sabor))
            {
                if (Cantidades[sabor] >= cantidad)
                {
                    switch (sabor)
                    {
                        case Sabor.Caramelo:
                            flanesCarameloCocinados += cantidad;
                            break;
                        case Sabor.Chocolate:
                            flanesChocolateCocinados += cantidad;
                            break;
                        case Sabor.Vainilla:
                            flanesVainillaCocinados += cantidad;
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
            todasLasCantidades.Add("FlanCaramelo", Cantidades[Sabor.Caramelo]);
            todasLasCantidades.Add("FlanChocolate", Cantidades[Sabor.Chocolate]);
            todasLasCantidades.Add("FlanVainilla", Cantidades[Sabor.Vainilla]);
            return todasLasCantidades;
        }

        /// <summary>
        /// Método estático para obtener la cantidad de flanes cocinados de cada sabor actualmente.
        /// </summary>
        /// <returns>Detalles del stock de flanes cocinados en forma de dictionary.</returns>

        public static Dictionary<string, int> ObtenerCantidadesCocinadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("FlanCaramelo", flanesCarameloCocinados);
            todasLasCantidades.Add("FlanChocolate", flanesChocolateCocinados);
            todasLasCantidades.Add("FlanVainilla", flanesVainillaCocinados);
            return todasLasCantidades;
        }
    }
}
