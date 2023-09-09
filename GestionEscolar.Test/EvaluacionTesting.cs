using GestionEscolar.Controllers;
using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
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
            ActividadResponse response = service.EnviarRespuestas(idActividad, request);
            Assert.IsType<ActividadResponse>(response);
        }

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
                    respuesta = "10"
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

        [Fact]
        public void GetNotaEvaluacionNotFound()
        {
            string evaluacion = "Test";
            Assert.Throws<EvaluacioNotFoundException>(() => service.GetNotasByEvaluacion(evaluacion));
        }

    }
}
