using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Model;
using GestionEscolar.Repository;
using static GestionEscolar.DTO.InicializarRequest;

namespace GestionEscolar.Services
{
    public class PonderacionesService
    {
        //Variables
        public string ACTIVIDADES = "ACTIVIDADES";
        public string COMPETENCIAS = "COMPETENCIAS";

        //Repositorio
        PonderacionRepository ponderacionRepository = new PonderacionRepository();

        //modificar las ponderaciones
        public PonderacionesResponse modificarPonderacion(string evaluacion, PonderacionesRequest datos)
        {
            int ponderacion = 0;
            //comprovamos que tipo de evaluacion es
            if (evaluacion.ToUpper().Equals(ACTIVIDADES))
            {
                ponderacion = comprobarPoderacionEspecifica(datos);
            }
            else if (evaluacion.ToUpper().Equals(COMPETENCIAS))
            {
                ponderacion = comprobarPoderacionCompetencia(datos);
            }
            else
            {
                throw new EvaluacioNotFoundException("La evaluacion " + evaluacion + " no existe");
            }

            if(ponderacion != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
            //Aqui guardariamos las nuevas ponderaciones en caso de tener persistencia de datos
            PonderacionesResponse ponderacionesResponse = new PonderacionesResponse();
            ponderacionesResponse.listPonderaciones = datos.listPonderaciones;

            return ponderacionesResponse;
        }

        //Comprobar las ponderaciones de competitiva
        private int comprobarPoderacionCompetencia(PonderacionesRequest ponderaciones)
        {
            int ponderacio = 0;
            foreach (var competencia in ponderaciones.listPonderaciones)
            {
                //comprovamos que la competencia exista
                Model.Competencia c = ponderacionRepository.getCompetencias().Find(comp => comp.nombre.Equals(competencia.nombre));
                if(c == null)
                {
                    throw new CompetenciaNotExistException("Competencia no existe");
                }
                ponderacio += competencia.ponderacion;
            }
            return ponderacio;
        }

        //comprovar las ponderaciones Especificas
        private int comprobarPoderacionEspecifica(PonderacionesRequest ponderaciones)
        {
            int ponderacio = 0;
            foreach (var especifica in ponderaciones.listPonderaciones)
            {
                //comprovamos que la especifica exista
                Model.Especifica e = ponderacionRepository.getEspecificas().Find(esp => esp.nombre.Equals(especifica.nombre));
                if (e == null)
                {
                    throw new EspecificacionNotExistException("Especifica " + especifica.nombre + " no existe");
                }
                ponderacio += especifica.ponderacion;
            }
            return ponderacio;
        }
    }
}