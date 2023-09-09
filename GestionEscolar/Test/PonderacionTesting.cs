using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;

namespace GestionEscolar.Test
{
    [TestClass]
    public class PonderacionTesting
    {
        public PonderacionesService service = new PonderacionesService();
       

        //[TestMethod]
        //public void ModificarPonderacionOk()
        //{
        //    PonderacionesRequest request = new PonderacionesRequest();
        //    List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest>();

        //    PonderacionRequest matematicas = new PonderacionRequest();
        //    matematicas.nombre = "Matematicas";
        //    matematicas.ponderacion = 20;
        //    listPonderaciones.Add(matematicas);

        //    PonderacionRequest digital = new PonderacionRequest();
        //    digital.nombre = "Digital";
        //    digital.ponderacion = 20;
        //    listPonderaciones.Add(digital);

        //    PonderacionRequest social = new PonderacionRequest();
        //    social.nombre = "Social";
        //    social.ponderacion = 60;
        //    listPonderaciones.Add(social);

        //    request.listPonderaciones = listPonderaciones;
        //    string evaluacion = "ACTIVIDADES";

        //    //Assert.AreEqual(() => service.ModificarPonderacion(evaluacion, request));
        //}

        [TestMethod]
        public void ModificarPonderacionEvaluacionNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest>();

            PonderacionRequest matematicas = new PonderacionRequest();
            matematicas.nombre = "Matematicas";
            matematicas.ponderacion = 20;
            listPonderaciones.Add(matematicas);

            PonderacionRequest digital = new PonderacionRequest();
            digital.nombre = "Digital";
            digital.ponderacion = 20;
            listPonderaciones.Add(digital);

            PonderacionRequest social = new PonderacionRequest();
            social.nombre = "Social";
            social.ponderacion = 60;
            listPonderaciones.Add(social);

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "TEST";

            Assert.ThrowsException<EvaluacioNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));
        }

        [TestMethod]
        public void ModificarPonderacionEspecificaNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest>();

            PonderacionRequest ejercicio = new PonderacionRequest();
            ejercicio.nombre = "Ejercicio";
            ejercicio.ponderacion = 20;
            listPonderaciones.Add(ejercicio);

            PonderacionRequest prueba = new PonderacionRequest();
            prueba.nombre = "Prueba";
            prueba.ponderacion = 20;
            listPonderaciones.Add(prueba);

            PonderacionRequest actividad = new PonderacionRequest();
            actividad.nombre = "Actividad";
            actividad.ponderacion = 60;
            listPonderaciones.Add(actividad);


            PonderacionRequest autoevaluacion = new PonderacionRequest();
            autoevaluacion.nombre = "Autoevaluacion";
            autoevaluacion.ponderacion = 60;
            listPonderaciones.Add(autoevaluacion);

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "ACTIVIDADES";

            Assert.ThrowsException<EspecificacionNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));
        }

        [TestMethod]
        public void ModificarPonderacionCompetenciaNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest>();

            PonderacionRequest matematicas = new PonderacionRequest();
            matematicas.nombre = "Matematicas";
            matematicas.ponderacion = 20;
            listPonderaciones.Add(matematicas);

            PonderacionRequest digital = new PonderacionRequest();
            digital.nombre = "Digital";
            digital.ponderacion = 20;
            listPonderaciones.Add(digital);

            PonderacionRequest social = new PonderacionRequest();
            social.nombre = "Social";
            social.ponderacion = 60;
            listPonderaciones.Add(social);

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "ACTIVIDADES";

            Assert.ThrowsException<CompetenciaNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));

        }

        [TestMethod]
        public void ModificarPonderacionPonderacionError()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest>();

            PonderacionRequest matematicas = new PonderacionRequest();
            matematicas.nombre = "Matematicas";
            matematicas.ponderacion = 40;
            listPonderaciones.Add(matematicas);

            PonderacionRequest digital = new PonderacionRequest();
            digital.nombre = "Digital";
            digital.ponderacion = 20;
            listPonderaciones.Add(digital);

            PonderacionRequest social = new PonderacionRequest();
            social.nombre = "Social";
            social.ponderacion = 60;
            listPonderaciones.Add(social);

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "ACTIVIDADES";

            Assert.ThrowsException<PonderacionException>(() => service.ModificarPonderacion(evaluacion, request));

        }
    }
}
