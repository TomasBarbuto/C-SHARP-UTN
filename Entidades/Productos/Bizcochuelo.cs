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
    /// Clase que representa un tipo específico de producto: Bizcochuelo.
    /// </summary>
    public class Bizcochuelo : Producto, IProduccion
    {
        private static int bizcochuelosCocoCocinados;
        private static int bizcochuelosVainillaCocinados;
        private static int bizcochuelosChocolateCocinados;
        /// <summary>
        /// Obtiene o establece las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock.
        /// </summary>
        private static Dictionary<Sabor, int> cantidades = new Dictionary<Sabor, int>
        {
            { Sabor.Chocolate, 0 },
            { Sabor.Vainilla, 0 },
            { Sabor.Coco, 0 }
        };

        /// <summary>
        /// Representa las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock.
        /// </summary>

        public static Dictionary<Sabor, int> Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }

        public static int BizcochuelosCocoCocinados
        {
            get { return bizcochuelosCocoCocinados; }
            set { bizcochuelosCocoCocinados = value; }
        }

        public static int BizcochuelosVainillaCocinados
        {
            get { return bizcochuelosVainillaCocinados; }
            set { bizcochuelosVainillaCocinados = value; }
        }

        public static int BizcochuelosChocolateCocinados
        {
            get { return bizcochuelosChocolateCocinados; }
            set { bizcochuelosChocolateCocinados = value; }
        }

        /// <summary>
        /// Constructor para la clase Bizcochuelo.
        /// </summary>
        /// <param name="nombre">Nombre del bizcochuelo.</param>
        public Bizcochuelo(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }


        /// <summary>
        /// Método para producir un bizcochuelo de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del bizcochuelo a producir.</param>
        /// <returns>Devuelve verdadero si el bizcochuelo se produce con éxito; de lo contrario, falso.</returns>
        public override bool Producir(Sabor sabor)
        {
            int cantidadLeudante = 10;
            int cantidadHarina = 0;
            int cantidadAzucar = 0;
            int cantidadSabor = 10;

            switch (sabor)
            {
                case Sabor.Chocolate:
                    cantidadHarina = 10;
                    cantidadAzucar = 20;
                    break;
                case Sabor.Coco:
                    cantidadHarina = 10;
                    cantidadAzucar = 15;
                    break;
                case Sabor.Vainilla:
                    cantidadHarina = 10;
                    cantidadAzucar = 15;
                    break;
            }

            List<(string, int)> materiasPrimas = new List<(string, int)>
            {
                ("Leudante", cantidadLeudante),
                ("Harina", cantidadHarina),
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
        /// Método para cocinar un cierto número de bizcochuelos de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del bizcochuelo a cocinar.</param>
        /// <param name="cantidad">Cantidad de bizcochuelos a cocinar.</param>
        /// <returns>Devuelve verdadero si se cocinan los bizcochuelos con éxito; de lo contrario, falso.</returns>
        public override bool Cocinar(Sabor sabor, int cantidad)
        {
            bool retorno = false;
            if (Cantidades.ContainsKey(sabor))
            {
                if (Cantidades[sabor] >= cantidad)
                {
                    switch (sabor)
                    {
                        case Sabor.Chocolate:
                            bizcochuelosChocolateCocinados += cantidad;
                            break;
                        case Sabor.Coco:
                            bizcochuelosCocoCocinados += cantidad;
                            break;
                        case Sabor.Vainilla:
                            bizcochuelosVainillaCocinados += cantidad;
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
            todasLasCantidades.Add("BizcochueloCoco", Cantidades[Sabor.Coco]);
            todasLasCantidades.Add("BizcochueloVainilla", Cantidades[Sabor.Vainilla]);
            todasLasCantidades.Add("BizcochueloChocolate", Cantidades[Sabor.Chocolate]);
            return todasLasCantidades;
        }

        /// <summary>
        /// Método para obtener la cantidad de bizcochuelos cocinadas de cada sabor actualmente.
        /// </summary>
        /// <returns>Detalles del stock de bizcochuelos cocinadas en forma de dictionary.</returns>
        public static Dictionary<string, int> ObtenerCantidadesCocinadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("BizcochueloCoco", bizcochuelosCocoCocinados);
            todasLasCantidades.Add("BizcochueloVainilla", bizcochuelosVainillaCocinados);
            todasLasCantidades.Add("BizcochueloChocolate", bizcochuelosChocolateCocinados);
            return todasLasCantidades;
        }
    }
}
