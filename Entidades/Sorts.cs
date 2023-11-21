using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que proporciona métodos estáticos para ordenar listas de elementos de manera ascendente o descendente.
    /// </summary>
    public class Ordenador
    {
        /// <summary>
        /// Ordena la lista de manera ascendente utilizando el comparador especificado.
        /// </summary>
        /// <typeparam name="T">El tipo de elementos en la lista.</typeparam>
        /// <param name="lista">La lista a ordenar.</param>
        /// <param name="comparador">Función de comparación que determina el orden entre dos elementos.</param>
        public static void OrdenarAscendente<T>(List<T> lista, Func<T, T, int> comparador)
        {
            lista.Sort((a, b) => comparador(a, b));
        }

        /// <summary>
        /// Ordena la lista de manera descendente utilizando el comparador especificado.
        /// </summary>
        /// <typeparam name="T">El tipo de elementos en la lista.</typeparam>
        /// <param name="lista">La lista a ordenar.</param>
        /// <param name="comparador">Función de comparación que determina el orden entre dos elementos.</param>
        public static void OrdenarDescendente<T>(List<T> lista, Func<T, T, int> comparador)
        {
            lista.Sort((a, b) => comparador(b, a));
        }
    }
}
