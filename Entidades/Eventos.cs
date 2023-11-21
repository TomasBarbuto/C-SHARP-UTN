using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática que define eventos relacionados con la producción.
    /// </summary>
    public static class Eventos
    {
        /// <summary>
        /// Evento que se dispara cuando se completa la producción de un producto.
        /// </summary>
        public static event Action<string, int> ProduccionRealizada;

        /// <summary>
        /// Invoca el evento de producción realizada con los parámetros proporcionados.
        /// </summary>
        /// <param name="producto">El nombre del producto producido.</param>
        /// <param name="cantidad">La cantidad de unidades producidas.</param>
        public static void Invoke(string producto, int cantidad)
        {
            ProduccionRealizada?.Invoke(producto, cantidad);
        }
    }
}
