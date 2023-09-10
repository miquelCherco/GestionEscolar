using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;

namespace GestionEscolar.Test
{
    public class EvaluacionTesting
    {
        public EvaluacionService service = new EvaluacionService();

        [Fact]
        public void EnviarRespuestaOK()
        {
            int idActividad = 1;
            EnvioRespuestaRequest request = new EnvioRespuestaRequest();
            List<RespuestaRequest> listRespuestas = new List<RespuestaRequest> {
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 1,
                    respuesta = "2"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "10"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 3,
                    respuesta = "Mercurio"
                }
            };
            request.listRespuestas = listRespuestas;

            ActividadResponse r = new ActividadResponse();
            r.nota = 10;
            r.numeroRepeticiones = 3;

            ActividadResponse response = service.EnviarRespuestas(idActividad, request);

            Assert.Equivalent(response,r);
        }

        //Se ha pasado un idActividad = 10 que no existe
        [Fact]
        public void EnviarRespuestaActividadNotFound()
        {
            int idActividad = 10;
            EnvioRespuestaRequest request = new EnvioRespuestaRequest();
            List<RespuestaRequest> listRespuestas = new List<RespuestaRequest> {
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 1,
                    respuesta = "2"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "10"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 3,
                    respuesta = "Mercurio"
                }
            };
            request.listRespuestas = listRespuestas;

            Assert.Throws<ActividadNotFoundException>(() => service.EnviarRespuestas(idActividad, request));
        }

        //Se ha introducido el ejercicio 5 que no existe
        [Fact]
        public void EnviarRespuestaEjercicioNotFound()
        {
            int idActividad = 1;
            EnvioRespuestaRequest request = new EnvioRespuestaRequest();
            List<RespuestaRequest> listRespuestas = new List<RespuestaRequest> {
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 1,
                    respuesta = "2"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "10"
                },
                new RespuestaRequest {
                    idEjercicio = 5,
                    idPregunta = 3,
                    respuesta = "Mercurio"
                }
            };
            request.listRespuestas = listRespuestas;

            Assert.Throws<EjercicioNotFoundException>(() => service.EnviarRespuestas(idActividad, request));
        }

        //Se ha introducido una pregunta que no existe
        [Fact]
        public void EnviarRespuestaPreguntaNotFound()
        {
            int idActividad = 1;
            EnvioRespuestaRequest request = new EnvioRespuestaRequest();
            List<RespuestaRequest> listRespuestas = new List<RespuestaRequest> {
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 1,
                    respuesta = "2"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "10"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 10,
                    respuesta = "Mercurio"
                }
            };
            request.listRespuestas = listRespuestas;

            Assert.Throws<PreguntaNotFoundException>(() => service.EnviarRespuestas(idActividad, request));
        }

        //Se ha introducido una pregunta repetida la numero 2 del ejercicio 1
        [Fact]
        public void EnviarRespuestaPreguntaRepetida()
        {
            int idActividad = 1;
            EnvioRespuestaRequest request = new EnvioRespuestaRequest();
            List<RespuestaRequest> listRespuestas = new List<RespuestaRequest> {
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 1,
                    respuesta = "2"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "10"
                },
                new RespuestaRequest {
                    idEjercicio = 1,
                    idPregunta = 2,
                    respuesta = "Mercurio"
                }
            };
            request.listRespuestas = listRespuestas;

            Assert.Throws<PreguntaRepetidaException>(() => service.EnviarRespuestas(idActividad, request));
        }

        [Fact]
        public void GetNotaOK()
        {
            string evaluacion = "ACTIVIDADES";
            float response = service.GetNotasByEvaluacion(evaluacion);
            Assert.Equal(6.0, response);
        }

        //Se ha introducido la evaluacion Test que no existe
        [Fact]
        public void GetNotaEvaluacionNotFound()
        {
            string evaluacion = "Test";
            Assert.Throws<EvaluacioNotFoundException>(() => service.GetNotasByEvaluacion(evaluacion));
        }

    }
}
