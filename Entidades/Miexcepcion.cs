using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepción lanzada cuando no hay suficiente stock de una materia prima o producto.
    /// </summary>
    public class StockInsuficienteException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StockInsuficienteException"/> con el mensaje de error especificado.
        /// </summary>
        /// <param name="message">Mensaje de error que describe la excepción.</param>
        public StockInsuficienteException(string message) : base(message)
        {
        }
    }
}

