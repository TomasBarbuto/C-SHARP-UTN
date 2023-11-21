using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Stock;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa un producto genérico.
    /// </summary>
    public abstract class Producto
    {
        protected string nombre;
        protected Sabor sabor;

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Obtiene o establece el sabor del bizcochuelo.
        /// </summary>
        public Sabor Sabor
        {
            get { return sabor; }
        }

        /// <summary>
        /// Constructor para la clase Producto.
        /// </summary>
        /// <param name="nombre">Nombre del producto.</param>
        public Producto(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Método abstracto para producir un producto de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del producto a producir.</param>
        /// <returns>Devuelve verdadero si el producto se produce con éxito; de lo contrario, falso.</returns>
        public abstract bool Producir(Sabor sabor);

        public abstract bool Cocinar(Sabor sabor, int cantidad);

        /// <summary>
        /// Método que devuelve un mensaje de error específico en caso de problemas durante la producción del producto.
        /// </summary>
        /// <param name="mensaje">Descripción del tipo de error ocurrido.</param>
        /// <returns>Mensaje de error detallado.</returns>
        public virtual string MensajeDeError(string mensaje)
        {
            return $"No se pudo {mensaje} " + this.nombre + " por falta de stock";
        }
    }
}
