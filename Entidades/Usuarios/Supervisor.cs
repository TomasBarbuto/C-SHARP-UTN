using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Usuarios.Usuario;

namespace Entidades.Usuarios
{
    public class Supervisor : Operario, IUsuarios
    {

        public Supervisor()
        {

        }

        /// <summary>
        /// Constructor para la clase Supervisor.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="dniUsuario">DNI del usuario.</param>
        /// <param name="contrasenia">Contraseña del usuario.</param>
        /// <param name="tipoUsuario">Tipo de usuario.</param>
        public Supervisor(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario) : base(nombreUsuario, dniUsuario, contrasenia, tipoUsuario)
        {
            idUsuario = GenerarIdUsuario();
        }

        /// <summary>
        /// Genera la identificación del usuario en base a su DNI, con la abreviatura "SU" para Supervisor.
        /// </summary>
        /// <returns>Identificación única para el supervisor.</returns>
        public override string GenerarIdUsuario()
        {
            return $"SU{this.dniUsuario}";
        }

        public override string MostrarDatosUsuario()
        {
            return base.MostrarDatosUsuario();
        }
    }
}
