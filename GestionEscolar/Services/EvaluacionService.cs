using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
using GestionEscolar.Repository;
using Actividad = GestionEscolar.Model.Actividad;

namespace GestionEscolar.Services
{
    public class EvaluacionService
    {
        //Varibales
        public string ACTIVIDADES = "ACTIVIDADES";
        public string COMPETENCIAS = "COMPETENCIAS";

        //Repositorios
        private ActividadRepository actividadRepository = new ActividadRepository();
        private PonderacionRepository ponderacionRepository = new PonderacionRepository();
        private RepeticionesActividadesRepository repeticionesActividades = new RepeticionesActividadesRepository();

        //obtener la nota de una actividad por las respuestas enviadas i devolver la cantidad de repeticiones de l'actividad
        public ActividadResponse EnviarRespuestas(int idActividad, EnvioRespuestaRequest datos)
        {
            //obtenemos l'actividad
            Actividad actividad = actividadRepository.GetActividades().Find(act => act.id == idActividad);
            if (actividad == null)
                throw new ActividadNotFoundException("La Actividad " + idActividad + " no existe");

            int aciertos = 0;
            Dictionary<int,List<int>> listEjerciciosPregunta = new Dictionary<int,List<int>>();
            //recorremoslas respuestas
            foreach (var respuesta in datos.listRespuestas)
            {
                //obtenemos el ejercicio
                Ejercicio ejercicio = actividad.listEjercicios.Find(ej => ej.id == respuesta.idEjercicio);
                if (ejercicio == null)
                    throw new EjercicioNotFoundException("El ejercicio " + respuesta.idEjercicio + " no existe");

                //obtenemos la pregunta
                Pregunta pregunta = ejercicio.listPreguntas.Find(preg => preg.id == respuesta.idPregunta);
                if (pregunta == null)
                    throw new PreguntaNotFoundException("La pregunta " + respuesta.idPregunta + " no existe");

                List<int> listPreguntas = new List<int>();
                if (listEjerciciosPregunta.ContainsKey(ejercicio.id))
                {
                    if (listEjerciciosPregunta[ejercicio.id].Contains(pregunta.id))
                    {
                        throw new PreguntaRepetidaException("La pregunta " + pregunta.id + " se ha enviado mas de una vez");
                    }
                }

                listPreguntas.Add(pregunta.id);
                listEjerciciosPregunta[ejercicio.id] = listPreguntas;

                //comprobamos que la respuesta sea correcta
                if (pregunta.respuestaEsperada.Equals(respuesta.respuesta.ToString()))
                {
                    aciertos++;
                }
                //Aqui guardariamos las respuestas en caso de tener persistencia de datos
            }
            int numPreguntas = 0;
            foreach (var ejercicios in actividad.listEjercicios)
            {
                foreach (var pregunta in ejercicios.listPreguntas)
                {
                    numPreguntas++;
                }
            }
            float nota = aciertos / (float)numPreguntas * 10;

            //Aqui guardariamos la nota de l'actividad en caso de tener persistenica de datos

            int repeticiones = repeticionesActividades.GetRepeticionesActividades().Find(act => act.idActividad == idActividad).repticiones;

            //Añadir repeticion en caso de tener persistencia
            repeticiones++;

            ActividadResponse actividadResponse = new ActividadResponse();

            actividadResponse.nota = nota;
            actividadResponse.numeroRepeticiones = repeticiones;
             
            return actividadResponse;
        }

        //Obtener las nota por tipo de evaluacion
        public float GetNotasByEvaluacion(string evaluacion)
        {
            float nota = 0;
            //comprobamos de que tipo de evaluación nos pasan
            if (evaluacion.ToUpper().Equals(ACTIVIDADES))
            {
                nota = CalcularNotaPorActividad();
            }
            else if (evaluacion.ToUpper().Equals(COMPETENCIAS))
            {
                nota = CalcularNotaPorCompetencia();
            }
            else
            {
                throw new EvaluacioNotFoundException("La evaluacion " + evaluacion + " no existe");
            }
            return nota;
        }

        //calcular la nota por competencia
        private float CalcularNotaPorCompetencia()
        {
            Dictionary<string,List<float>> notas = new Dictionary<string,List<float>>();
            foreach (var actividad in actividadRepository.GetActividades())
            {
                //si auno no hay la competenci en el diccionario lo añadimos
                if (!notas.ContainsKey(actividad.competencia))
                {
                    List<float> list = new List<float>();
                    list.Add(actividad.nota);
                    notas.Add(actividad.competencia, list);
                }
                else
                {
                    List<float> list = notas.GetValueOrDefault(actividad.competencia);
                    list.Add(actividad.nota);
                    notas[actividad.competencia] = list;
                }
            }
            float notaFinal = 0;
            //recorremos el diccionario para hacer el calculo
            foreach (var competenica in notas)
            {
                List<float> list = competenica.Value;
                float sumNota = list.Sum(x => x);
                float ponderacio = ponderacionRepository.GetCompetencias().Find(comp => comp.nombre.Equals(competenica.Key)).ponderacio;
                float media = sumNota / list.Count;

                notaFinal += media * ponderacio / 100;
            }

            return notaFinal;
        }

        // Calcular la nota per tipo de actividad
        private float CalcularNotaPorActividad()
        {
            Dictionary<string, List<float>> notas = new Dictionary<string, List<float>>();
            foreach (var actividad in actividadRepository.GetActividades())
            {
                //si aun no hay el tipo especifico en el diccionario lo añadimos
                if (!notas.ContainsKey(actividad.especifica))
                {
                    List<float> list = new List<float>();
                    list.Add(actividad.nota);
                    notas.Add(actividad.especifica, list);
                }
                else
                {
                    List<float> list = notas.GetValueOrDefault(actividad.especifica);
                    list.Add(actividad.nota);
                    notas[actividad.especifica] = list;
                }
            }
            float notaFinal = 0;

            //recorremos el diccionario para hacer el calculo
            foreach (var especifica in notas)
            {
                List<float> list = especifica.Value;
                float sumNota = list.Sum(x => x);
                float ponderacio = ponderacionRepository.GetEspecificas().Find(espe => espe.nombre.Equals(especifica.Key)).ponderacio;
                float media = sumNota / list.Count;

                notaFinal += media * ponderacio / 100;
            }

            return notaFinal;
        }

    
    }
}
