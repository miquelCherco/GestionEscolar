using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;

namespace GestionEscolar.Test
{
    public class PonderacionTesting
    {
        public PonderacionesService service = new PonderacionesService();


        [Fact]
        public void ModificarPonderacionOk()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest> {
                new PonderacionRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new PonderacionRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new PonderacionRequest {
                    nombre = "Matematicas",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;

            string evaluacion = "COMPETENCIAS";
            PonderacionesResponse response = service.ModificarPonderacion(evaluacion, request);

            PonderacionesResponse ponderacionResponse = new PonderacionesResponse();
            List<PonderacionResponse> listPonderacionesResponse = new List<PonderacionResponse> {
                new PonderacionResponse {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new PonderacionResponse {
                    nombre = "Social",
                    ponderacion = 20
                },
                new PonderacionResponse {
                    nombre = "Matematicas",
                    ponderacion = 50
                }
            };


            ponderacionResponse.listPonderaciones = listPonderacionesResponse;

            Assert.Equivalent(response,ponderacionResponse);
        }

        //Se ha puesto la evaluacion TEST que no existe
        [Fact]
        public void ModificarPonderacionEvaluacionNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest> {
                new PonderacionRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new PonderacionRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new PonderacionRequest {
                    nombre = "Matematicas",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "TEST";

            Assert.Throws<EvaluacioNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));
        }

        //Se ha introducido la especifica Test que no existe
        [Fact]
        public void ModificarPonderacionEspecificaNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest> {
                new PonderacionRequest {
                    nombre = "Prueba",
                    ponderacion = 30
                },
                new PonderacionRequest {
                    nombre = "Actividad",
                    ponderacion = 20
                },
                new PonderacionRequest {
                    nombre = "Test",
                    ponderacion = 50
                },
                new PonderacionRequest {
                    nombre = "Autoevaluacion",
                    ponderacion = 0
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "ACTIVIDADES";
            Xunit.Assert.Throws<EspecificacionNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));
        }


        //Se ha introducido la competencia Test que no existe
        [Fact]
        public void ModificarPonderacionCompetenciaNotFound()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest> {
                new PonderacionRequest {
                    nombre = "Test",
                    ponderacion = 30
                },
                new PonderacionRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new PonderacionRequest {
                    nombre = "Matematicas",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "COMPETENCIAS";

            Xunit.Assert.Throws<CompetenciaNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));

        }

        //Se ha modificado la ponderacion para que no sume 100
        [Fact]
        public void ModificarPonderacionPonderacionError()
        {
            PonderacionesRequest request = new PonderacionesRequest();
            List<PonderacionRequest> listPonderaciones = new List<PonderacionRequest> {
                new PonderacionRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new PonderacionRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new PonderacionRequest {
                    nombre = "Matematicas",
                    ponderacion = 60
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "COMPETENCIAS";

            Xunit.Assert.Throws<PonderacionException>(() => service.ModificarPonderacion(evaluacion, request));

        }
    }
}
