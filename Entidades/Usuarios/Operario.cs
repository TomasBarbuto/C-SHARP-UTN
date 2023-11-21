using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    /// <summary>
    /// Clase que representa a un operario en el sistema.
    /// </summary>
    public class Operario : Usuario, IUsuarios
    {
        protected string idUsuario;

        //Creame un constructor sin parametros
        public Operario()
        {

        }
        /// <summary>
        /// Constructor para la clase Operario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="dniUsuario">DNI del usuario.</param>
        /// <param name="contrasenia">Contraseña del usuario.</param>
        /// <param name="tipoUsuario">Tipo de usuario.</param>
        public Operario(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario) : base(nombreUsuario, dniUsuario, contrasenia, tipoUsuario)
        {
            idUsuario = GenerarIdUsuario();
        }

        /// <summary>
        /// Propiedad para obtener la identificación del usuario.
        /// </summary>
        public string IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        /// <summary>
        /// Genera la identificación del usuario en base a su DNI.
        /// </summary>
        /// <returns>Identificación única para el usuario.</returns>
        public override string GenerarIdUsuario()
        {
            return $"OP{this.dniUsuario}";
        }

        /// <summary>
        /// Devuelve una representación en cadena de texto del objeto Operario.
        /// </summary>
        /// <returns>Información detallada del operario.</returns>
        public override string MostrarDatosUsuario()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {idUsuario}");
            sb.AppendLine($"Nombre: {NombreUsuario}");
            sb.AppendLine($"DNI: {dniUsuario}");
            sb.AppendLine($"Tipo de usuario: {this.tipoUsuario}");
            return sb.ToString();
        }
    }
}
