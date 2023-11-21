using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    /// <summary>
    /// Clase general que representa a un usuario en el sistema.
    /// </summary>
    public abstract class Usuario
    {
        /// <summary>
        /// Enumeración que representa los tipos de usuario, como Administrador y Empleado.
        /// </summary>
        public enum TipoUsuario { Administrador = 1, Empleado = 2 }

        private string nombreUsuario;
        protected int dniUsuario;
        private string contrasenia;
        protected TipoUsuario tipoUsuario;

        //creame un constructor sin parametros
        public Usuario()
        {

        }
        /// <summary>
        /// Obtiene o establece el tipo de usuario.
        /// </summary>
        public TipoUsuario Tipo
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }        
        }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public int DniUsuario
        {
            get { return dniUsuario; }
            set { dniUsuario = value; }
        }

        public abstract string GenerarIdUsuario();

        /// <summary>
        /// Constructor para la clase Usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="dniUsuario">DNI del usuario.</param>
        /// <param name="contrasenia">Contraseña del usuario.</param>
        /// <param name="tipoUsuario">Tipo de usuario (1 para Administrador, 2 para Empleado).</param>
        public Usuario(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.dniUsuario = dniUsuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = (TipoUsuario)tipoUsuario;
        }

        /// <summary>
        /// Sobrescribe el método ToString para mostrar la información del usuario.
        /// </summary>
        /// <returns>Información del usuario en formato de cadena de texto.</returns>
        public virtual string MostrarDatosUsuario()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {nombreUsuario}");
            sb.AppendLine($"DNI: {dniUsuario}");
            sb.AppendLine($"Contraseña: {contrasenia}");
            sb.AppendLine($"Tipo de usuario: {(TipoUsuario)tipoUsuario}");
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar si dos usuarios tienen el mismo DNI si lo tiene son el mismo.
        /// </summary>
        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            return usuario1.dniUsuario == usuario2.dniUsuario;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar si dos usuarios tienen diferentes DNI.
        /// </summary>
        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }

        /// <summary>
        /// Utiliza las sobrecargas de == para validar que no haya dos usuarios iguales en la lista
        /// </summary>
        public void AgregarUsuario(Usuario usuario, List<Usuario> listaUsuarios)
        {
            bool esta = false;

            foreach (var user in listaUsuarios)
            {
                if (user == usuario)
                {
                    esta = true;
                    break;
                }
            }

            if (!esta)
            {
                listaUsuarios.Add(usuario);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Usuario other = (Usuario)obj!;
            return this.dniUsuario == other.dniUsuario;
        }


        public override int GetHashCode()
        {
            return dniUsuario.GetHashCode();
        }

        public bool ValidarNombreUsuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            return true;
        }

    }
}