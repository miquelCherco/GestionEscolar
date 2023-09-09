using GestionEscolar.Model;
using System.Reflection.Metadata.Ecma335;

namespace GestionEscolar.Repository
{
    public class ActividadRepository
    {
        public List<Actividad> list = new List<Actividad>
            {
                new Actividad
                {
                    id = 1,
                    nombre = "Actividad 1",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    id = 1,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 1 + 1",
                                    respuestaEsperada = "2"
                                },
                                new Pregunta
                                {
                                    id = 2,
                                    tipo = TipoPregunta.Numerica,
                                    pregunta = "Suma 5 + 5",
                                    respuestaEsperada = "10"
                                },
                                new Pregunta
                                {
                                    id = 3,
                                    tipo = TipoPregunta.Textual,
                                    pregunta = "¿Qual es el planeta mas cerca del sol?",
                                    respuestaEsperada = "Mercurio"
                                }
                            }
                        }
                    },
                    competencia = "Digital",
                    especifica = "Ejercicio",
                    nota = 10
                },
                new Actividad
                {
                    id = 2,
                    nombre = "Actividad 2",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    pregunta = "",
                                    respuesta = ""
                                }
                            }
                        }
                    },
                    competencia = "Matematica",
                    especifica = "Ejercicio",
                    nota = 10
                },
                new Actividad
                {
                    id = 3,
                    nombre = "Actividad 3",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    pregunta = "",
                                    respuesta = ""
                                }
                            }
                        }
                    },
                    competencia = "Digital",
                    especifica = "Autoevaluacion",
                    nota = 10
                },
                new Actividad
                {
                    id = 4,
                    nombre = "Actividad 4",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    pregunta = "",
                                    respuesta = ""
                                }
                            }
                        }
                    },
                    competencia = "Social",
                    especifica = "Ejercicio",
                    nota = 10
                },
                new Actividad
                {
                    id = 5,
                    nombre = "Actividad 5",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    pregunta = "",
                                    respuesta = ""
                                }
                            }
                        }
                    },
                    competencia = "Digital",
                    especifica = "Prueba",
                    nota = 10
                },
                new Actividad
                {
                    id = 6,
                    nombre = "Actividad 6",
                    listEjercicios = new List<Ejercicio>
                    {
                        new Ejercicio
                        {
                            id = 1,
                            listPreguntas = new List<Pregunta>
                            {
                                new Pregunta
                                {
                                    pregunta = "",
                                    respuesta = ""
                                }
                            }
                        }
                    },
                    competencia = "Digital",
                    especifica = "Prueba",
                    nota = 10
                }
//            };
//            }
        };

        public List<Actividad> GetActividades()
        {
            return list;
        }
    }

   
}
