using GestionEscolar.Controllers;
using GestionEscolar.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEscolar.Test
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        { 
            ActividadRepository actividadRepository = new ActividadRepository();
            var testActividades = actividadRepository.getActividades();
            var controller = new ActividadController();

            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testActividades.Count, result.Count);
        }
    }
}
