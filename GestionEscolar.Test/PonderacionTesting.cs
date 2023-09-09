﻿using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
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
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;

            string evaluacion = "COMPETENCIAS";
            PonderacionesResponse response = service.ModificarPonderacion(evaluacion, request);

            Assert.IsType<PonderacionesResponse>(response);
        }

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
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "TEST";
            
            Assert.Throws<EvaluacioNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));
        }

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
                    nombre = "Matematica",
                    ponderacion = 50
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "COMPETENCIAS";

            Xunit.Assert.Throws<CompetenciaNotFoundException>(() => service.ModificarPonderacion(evaluacion, request));

        }

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
                    nombre = "Matematica",
                    ponderacion = 60
                }
            };

            request.listPonderaciones = listPonderaciones;
            string evaluacion = "COMPETENCIAS";

            Xunit.Assert.Throws<PonderacionException>(() => service.ModificarPonderacion(evaluacion, request));

        }
    }
}