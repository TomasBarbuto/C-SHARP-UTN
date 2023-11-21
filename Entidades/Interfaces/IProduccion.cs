using static Entidades.Stock;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Define las operaciones que deben implementar las clases relacionadas con la producción de productos.
    /// </summary>
    public interface IProduccion
    {
        /// <summary>
        /// Inicia la producción de un producto con el sabor especificado.
        /// </summary>
        /// <param name="sabor">Sabor del producto a producir.</param>
        /// <returns>True si la producción fue exitosa, False en caso contrario.</returns>
        bool Producir(Sabor sabor);

        /// <summary>
        /// Inicia la cocción de un producto con el sabor y cantidad especificados.
        /// </summary>
        /// <param name="sabor">Sabor del producto a cocinar.</param>
        /// <param name="cantidad">Cantidad de unidades a cocinar.</param>
        /// <returns>True si la cocción fue exitosa, False en caso contrario.</returns>
        bool Cocinar(Sabor sabor, int cantidad);
    }
}

