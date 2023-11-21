using Entidades;


namespace TestUnitarios
{
    [TestClass]
    public class PruebasVerificarExistencia
    {
        [TestMethod]
        public void AgregarMateriaPrima_AgregaCorrectamente()
        {
            Stock.Harina = 10;

            Stock.AgregarMateriaPrima("Harina", 5);

            Assert.AreEqual(15, Stock.Harina, "La cantidad de harina no se ha agregado correctamente al stock.");
        }

        [TestMethod]
        public void VerificarExistencia_StockInsuficiente_RetornaFalse()
        {
            Stock.Harina = 10;
            var materiasPrimas = new List<(string, int)> { ("Harina", 15) };

            bool resultado = Stock.VerificarExistencia(materiasPrimas);

            Assert.IsFalse(resultado, "La verificación de existencia debería ser falsa.");
        }

        [TestMethod]
        public void VerificarExistencia_StockSuficiente_RetornaTrue()
        {

            Stock.Harina = 20;
            var materiasPrimas = new List<(string, int)> { ("Harina", 10) };

            bool resultado = Stock.VerificarExistencia(materiasPrimas);

            Assert.IsTrue(resultado, "La verificación de existencia debería ser verdadera.");
        }

        [TestMethod]
        public void UsarMateriasPrimas_StockSuficiente_RetornaTrue()
        {

            Stock.Harina = 15;
            var materiasPrimas = new List<(string, int)> { ("Harina", 10) };

            var resultado = Stock.UsarMateriasPrimas(materiasPrimas);

            Assert.IsTrue(resultado, "El uso de materias primas debería ser exitoso.");
            Assert.AreEqual(5, Stock.Harina, "La cantidad de harina no se ha actualizado correctamente después de usar materias primas.");
        }
    }
}
