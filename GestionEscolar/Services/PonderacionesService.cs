using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
using GestionEscolar.Repository;

namespace GestionEscolar.Services
{
    public class PonderacionesService
    {
        //Variables
        public const string ACTIVIDADES = "ACTIVIDADES";
        public const string COMPETENCIAS = "COMPETENCIAS";
        public const int PERCENTATGE = 100;

        //Repositorio
        PonderacionRepository ponderacionRepository = new PonderacionRepository();

        //modificar las ponderaciones
        public PonderacionesResponse ModificarPonderacion(string evaluacion, PonderacionesRequest datos)
        {
            int ponderacion = 0;
            //comprovamos que tipo de evaluacion es
            if (evaluacion.ToUpper().Equals(ACTIVIDADES))
            {
                ponderacion = ComprobarPoderacionEspecifica(datos);
            }
            else if (evaluacion.ToUpper().Equals(COMPETENCIAS))
            {
                ponderacion = ComprobarPoderacionCompetencia(datos);
            }
            else
            {
                throw new EvaluacioNotFoundException("La evaluacion " + evaluacion + " no existe");
            }

            if(ponderacion != PERCENTATGE)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
            //Aqui guardariamos las nuevas ponderaciones en caso de tener persistencia de datos
            PonderacionesResponse ponderacionesResponse = ModificarClaseResponse(datos.listPonderaciones);

            return ponderacionesResponse;
        }

        //Modificamos la classe para que sea la correcta para enviar los datos (de request a response)
        private PonderacionesResponse ModificarClaseResponse(List<PonderacionRequest> listPonderacionRequest)
        {
            PonderacionesResponse ponderacionesResponse = new PonderacionesResponse();
            List<PonderacionResponse> listPonderacionResponse = new List<PonderacionResponse> ();
            foreach (var ponderacion in listPonderacionRequest)
            {
                PonderacionResponse ponderacionResponse = new PonderacionResponse();
                ponderacionResponse.nombre = ponderacion.nombre;
                ponderacionResponse.ponderacion = ponderacion.ponderacion;
                listPonderacionResponse.Add(ponderacionResponse);
            }
            ponderacionesResponse.listPonderaciones = listPonderacionResponse;
            return ponderacionesResponse;
        }

        //Comprobar las ponderaciones de competitiva
        private int ComprobarPoderacionCompetencia(PonderacionesRequest ponderaciones)
        {
            int ponderacio = 0;
            foreach (var competencia in ponderaciones.listPonderaciones)
            {
                //comprovamos que la competencia exista
                Model.Competencia competenciaActual = ponderacionRepository.GetCompetencias().Find(comp => comp.nombre.Equals(competencia.nombre));
                if(competenciaActual == null)
                {
                    throw new CompetenciaNotFoundException("Competencia no existe");
                }
                ponderacio += competencia.ponderacion;
            }
            return ponderacio;
        }

        //comprovar las ponderaciones Especificas
        private int ComprobarPoderacionEspecifica(PonderacionesRequest ponderaciones)
        {
            int ponderacio = 0;
            foreach (var especifica in ponderaciones.listPonderaciones)
            {
                //comprovamos que la especifica exista
                Model.Especifica especificaActual = ponderacionRepository.GetEspecificas().Find(esp => esp.nombre.Equals(especifica.nombre));
                if (especificaActual == null)
                {
                    throw new EspecificacionNotFoundException("Especifica " + especifica.nombre + " no existe");
                }
                ponderacio += especifica.ponderacion;
            }
            return ponderacio;
        }
    }
}