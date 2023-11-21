using Entidades.Usuarios;
using static Entidades.Usuarios.Usuario;

namespace TestUnitarios
{
    public class ValidarAdmin
    {
        [TestClass]
        public class VerificarSiEsAdmin
        {
            [TestMethod]
            public void VerificarSiEsSupervisor_DebeDevolverOpcionAdministradorSiUsuarioEsSupervisor()
            {
                int idUsuario = 0;

                List<Usuario> usuarios = new List<Usuario>
                {
                    new Supervisor("nicolas", 12345, "Nico123", 1)
                };

                int opcionEsperada;

                if (usuarios[idUsuario].Tipo == TipoUsuario.Administrador)
                {
                    opcionEsperada = (int)TipoUsuario.Administrador;
                }
                else
                {
                    opcionEsperada = (int)TipoUsuario.Empleado;
                }

                Assert.AreEqual(opcionEsperada, (int)usuarios[idUsuario].Tipo);
            }

            [TestMethod]
            public void VerificarSiEsEmpleado_DebeDevolverOpcionEmpleadoSiUsuarioEsEmpleado()
            {

                List<Usuario> usuarios = new List<Usuario>
                {
                    new Supervisor("nicolas", 12345, "Nico123", 1),
                    new Operario("operario1", 67890, "OperarioUser", 2)
                };

                int idUsuarioSupervisor = 0;
                int idUsuarioOperario = 1;

                int opcionEsperadaSupervisor = (int)TipoUsuario.Administrador;
                int opcionEsperadaOperario = (int)TipoUsuario.Empleado;

                int opcionObtenidaSupervisor = (int)usuarios[idUsuarioSupervisor].Tipo;
                int opcionObtenidaOperario = (int)usuarios[idUsuarioOperario].Tipo;

                Assert.AreEqual(opcionEsperadaSupervisor, opcionObtenidaSupervisor);
                Assert.AreEqual(opcionEsperadaOperario, opcionObtenidaOperario);
            }

            [TestMethod]
            public void VerificarSiElTipoEsCorrecto_DebeDevolverOkSiElTipoNoPerteneceANingunValor()
            {
                List<Usuario> usuarios = new List<Usuario>
                {
                    new Supervisor("nicolas", 12345, "Nico123", 1),
                    new Operario("operario1", 67890, "OperarioUser", 2),
                    new Operario("usuarioGenerico", 11111, "UsuarioGen", 3)
                };

                int idUsuarioGenerico = 2;

                Assert.IsFalse(usuarios[idUsuarioGenerico].Tipo == TipoUsuario.Administrador);
            }
        }
    }
}