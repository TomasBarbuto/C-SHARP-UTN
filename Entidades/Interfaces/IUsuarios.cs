using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Define las operaciones que deben implementar las clases relacionadas con usuarios.
    /// </summary>
    internal interface IUsuarios
    {
        /// <summary>
        /// Genera un identificador único para el usuario.
        /// </summary>
        /// <returns>Identificador único del usuario.</returns>
        string GenerarIdUsuario();

        /// <summary>
        /// Obtiene una representación en cadena de los datos del usuario.
        /// </summary>
        /// <returns>Cadena que representa los datos del usuario.</returns>
        string MostrarDatosUsuario();
    }
}

