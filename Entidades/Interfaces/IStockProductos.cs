using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Define las operaciones que deben implementar las clases relacionadas con el stock de productos.
    /// </summary>
    internal interface IStockProductos
    {
        /// <summary>
        /// Obtiene las cantidades fabricadas de productos.
        /// </summary>
        /// <returns>Diccionario que representa las cantidades fabricadas de productos.</returns>
        Dictionary<string, int> ObtenerCantidadesFabricadas();

        /// <summary>
        /// Obtiene las cantidades cocinadas de productos.
        /// </summary>
        /// <returns>Diccionario que representa las cantidades cocinadas de productos.</returns>
        Dictionary<string, int> ObtenerCantidadesCocinadas();
    }
}

