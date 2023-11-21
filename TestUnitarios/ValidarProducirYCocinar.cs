using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Productos;
using Entidades;
using static Entidades.Stock;


namespace TestUnitarios
{

    [TestClass]
    public class BizcochueloTests
    {

        [TestMethod]
        public void Producir_BizcochueloChocolate_UsaMateriasPrimasCorrectas()
        {

            Bizcochuelo.Cantidades[Sabor.Chocolate] = 0;

            var resultado = new Bizcochuelo("Chocolate").Producir(Sabor.Chocolate);

            Assert.IsFalse(resultado, "La producción de bizcochuelo de chocolate debería devolver false debido a que no hay suficientes materias primas.");
            Assert.AreEqual(0, Bizcochuelo.Cantidades[Sabor.Chocolate], "La cantidad de bizcochuelos de chocolate no debería haber cambiado.");
        }

        [TestMethod]
        public void Producir_BizcochueloCoco_StockInsuficiente_RetornaFalse()
        {

            Stock.Harina = 5;

            var resultado = new Bizcochuelo("Coco").Producir(Sabor.Coco);

            Assert.IsFalse(resultado, "La producción de bizcochuelo de coco debería fallar debido al stock insuficiente de harina.");
            Assert.AreEqual(0, Bizcochuelo.Cantidades[Sabor.Coco], "La cantidad de bizcochuelos de coco no debería haber cambiado.");
        }

        [TestMethod]
        public void Producir_BizcochueloVainilla_UsaMateriasPrimasCorrectas_Y_ActualizaStock()
        {
            Bizcochuelo.Cantidades[Sabor.Vainilla] = 0;
            Stock.Harina = 20;

            var resultado = new Bizcochuelo("Vainilla").Producir(Sabor.Vainilla);

            Assert.IsFalse(resultado, "La producción de bizcochuelo de vainilla debería de fallar.");
            Assert.AreEqual(0, Bizcochuelo.Cantidades[Sabor.Vainilla], "La cantidad de bizcochuelos de vainilla se ha actualizado correctamente.");
            Assert.AreEqual(20, Stock.Harina, "La cantidad de harina  se ha actualizado correctamente después de usar materias primas.");
        }

    }
}
