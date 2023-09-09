using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
using GestionEscolar.Services;
using static GestionEscolar.DTO.InicializarRequest;

namespace GestionEscolar.Test
{
    public class InicializarTesting
    {
        public InicializarService service = new InicializarService();

        [Fact]
        public void InicializarDatosOk()
        {
            InicializarRequest request = new InicializarRequest();
            List<ActividadRequest> listActividades = new List<ActividadRequest>
            {
                new ActividadRequest
                {
                    id = 1,
                    nombre = "Actividad 1",
                    listEjercicios = new List<EjercicioRequest>
                    {
                        new EjercicioRequest
                        {
                            id = 1,
                            listPreguntas = new List<PreguntaRequest>
                            {
                                new PreguntaRequest
                                {
                                    id = 1,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 1 + 1",
                                    respuestaEsperada = "2"
                                }
                            }
                        }
                    },
                    competencia = "Social",
                    especifica = "Prueba",
                    nota = 10
                }
            };

            List<EspecificaRequest> listEspecifica = new List<EspecificaRequest> {
                new EspecificaRequest {
                    nombre = "Prueba",
                    ponderacion = 30
                },
                new EspecificaRequest {
                    nombre = "Actividad",
                    ponderacion = 20
                },
                new EspecificaRequest {
                    nombre = "Ejercicio",
                    ponderacion = 50
                },
                new EspecificaRequest {
                    nombre = "Autoevaluacion",
                    ponderacion = 0
                }
            };

            List<CompetenciaRequest> listCompetencia = new List<CompetenciaRequest> {
                new CompetenciaRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new CompetenciaRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new CompetenciaRequest {
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };
            request.listActividades = listActividades;
            request.listCompetencias = listCompetencia;
            request.listEspecificas = listEspecifica;
            Assert.True(service.InicializarDatos(request));
        }

        [Fact]
        public void InicializarDatosEspecificacionNotFound()
        {
            InicializarRequest request = new InicializarRequest();
            List<ActividadRequest> listActividades = new List<ActividadRequest>
            {
                new ActividadRequest
                {
                    id = 1,
                    nombre = "Actividad 1",
                    listEjercicios = new List<EjercicioRequest>
                    {
                        new EjercicioRequest
                        {
                            id = 1,
                            listPreguntas = new List<PreguntaRequest>
                            {
                                new PreguntaRequest
                                {
                                    id = 1,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 1 + 1",
                                    respuestaEsperada = "2"
                                }
                            }
                        }
                    },
                    competencia = "Social",
                    especifica = "",
                    nota = 10
                }
            };

            List<EspecificaRequest> listEspecifica = new List<EspecificaRequest> {
                new EspecificaRequest {
                    nombre = "Prueba",
                    ponderacion = 30
                },
                new EspecificaRequest {
                    nombre = "Actividad",
                    ponderacion = 20
                },
                new EspecificaRequest {
                    nombre = "Ejercicio",
                    ponderacion = 50
                },
                new EspecificaRequest {
                    nombre = "Autoevaluacion",
                    ponderacion = 0
                }
            };

            List<CompetenciaRequest> listCompetencia = new List<CompetenciaRequest> {
                new CompetenciaRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new CompetenciaRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new CompetenciaRequest {
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };
            request.listActividades = listActividades;
            request.listCompetencias = listCompetencia;
            request.listEspecificas = listEspecifica;

            Assert.Throws<EspecificacionNotFoundException>(() => service.InicializarDatos(request));
        }

        [Fact]
        public void InicializarDatosCompetenciaNotFound()
        {
            InicializarRequest request = new InicializarRequest();
            List<ActividadRequest> listActividades = new List<ActividadRequest>
            {
                new ActividadRequest
                {
                    id = 1,
                    nombre = "Actividad 1",
                    listEjercicios = new List<EjercicioRequest>
                    {
                        new EjercicioRequest
                        {
                            id = 1,
                            listPreguntas = new List<PreguntaRequest>
                            {
                                new PreguntaRequest
                                {
                                    id = 1,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 1 + 1",
                                    respuestaEsperada = "2"
                                }
                            }
                        }
                    },
                    competencia = "",
                    especifica = "Ejercicio",
                    nota = 10
                }
            };

            List<EspecificaRequest> listEspecifica = new List<EspecificaRequest> {
                new EspecificaRequest {
                    nombre = "Prueba",
                    ponderacion = 30
                },
                new EspecificaRequest {
                    nombre = "Actividad",
                    ponderacion = 20
                },
                new EspecificaRequest {
                    nombre = "Ejercicio",
                    ponderacion = 50
                },
                new EspecificaRequest {
                    nombre = "Autoevaluacion",
                    ponderacion = 0
                }
            };

            List<CompetenciaRequest> listCompetencia = new List<CompetenciaRequest> {
                new CompetenciaRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new CompetenciaRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new CompetenciaRequest {
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };
            request.listActividades = listActividades;
            request.listCompetencias = listCompetencia;
            request.listEspecificas = listEspecifica;

            Assert.Throws<CompetenciaNotFoundException>(() => service.InicializarDatos(request));
        }

        [Fact]
        public void InicializarDatosPonderacionError()
        {
            InicializarRequest request = new InicializarRequest();
            List<ActividadRequest> listActividades = new List<ActividadRequest>
            {
                new ActividadRequest
                {
                    id = 1,
                    nombre = "Actividad 1",
                    listEjercicios = new List<EjercicioRequest>
                    {
                        new EjercicioRequest
                        {
                            id = 1,
                            listPreguntas = new List<PreguntaRequest>
                            {
                                new PreguntaRequest
                                {
                                    id = 1,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 1 + 1",
                                    respuestaEsperada = "2"
                                }
                            }
                        }
                    },
                    competencia = "",
                    especifica = "Ejercicio",
                    nota = 10
                }
            };

            List<EspecificaRequest> listEspecifica = new List<EspecificaRequest> {
                new EspecificaRequest {
                    nombre = "Prueba",
                    ponderacion = 30
                },
                new EspecificaRequest {
                    nombre = "Actividad",
                    ponderacion = 20
                },
                new EspecificaRequest {
                    nombre = "Ejercicio",
                    ponderacion = 50
                },
                new EspecificaRequest {
                    nombre = "Autoevaluacion",
                    ponderacion = 0
                }
            };

            List<CompetenciaRequest> listCompetencia = new List<CompetenciaRequest> {
                new CompetenciaRequest {
                    nombre = "Digital",
                    ponderacion = 30
                },
                new CompetenciaRequest {
                    nombre = "Social",
                    ponderacion = 20
                },
                new CompetenciaRequest {
                    nombre = "Matematica",
                    ponderacion = 80
                }
            };
            request.listActividades = listActividades;
            request.listCompetencias = listCompetencia;
            request.listEspecificas = listEspecifica;

            Assert.Throws<PonderacionException>(() => service.InicializarDatos(request));
        }
    }
}
