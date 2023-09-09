using GestionEscolar.Controllers;
using GestionEscolar.Exceptions;
using GestionEscolar.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEscolar.Test
{
    [TestClass]
    public class EvaluacionTesting
    {
        [TestMethod]
        public void EnviarRespuestaOK()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void EnviarRespuestaActividadNotFound()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void EnviarRespuestaEjercicioNotFound()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void EnviarRespuestaPreguntaNotFound()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void EnviarRespuestaPreguntaRepetida()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void GetNotaOK()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<PonderacionException>();
        }

        [TestMethod]
        public void GetNotaEvaluacionNotFound()
        {
            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
            //Assert.ThrowsException<EvaluacioNotFoundException>();
        }

    }
}
