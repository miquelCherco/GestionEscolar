using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using static GestionEscolar.DTO.InicializarRequest;

namespace GestionEscolar.Services
{
    public class InicializarService
    {

        //Inicializacion de datos
        public Boolean InicializarDatos(InicializarRequest datos)
        {
            ComprobarPoderacionCompetencia(datos.listCompetencias);
            ComprobarPoderacionEspecifica(datos.listEspecificas);
            GetDatosOK(datos);
            return true;
            //Aqui guradariamos los datos en caso de tener persistencia de datos
        }

        //Comprobar que la'actividad es correcta
        private void GetDatosOK(InicializarRequest datos)
        {
            //guardamos los datos en listas
            List<ActividadRequest> listActividades = datos.listActividades;
            List<CompetenciaRequest> listCompetencia = datos.listCompetencias;
            List<EspecificaRequest> listEspecifica = datos.listEspecificas;

            foreach (var actividad in listActividades)            
            {
                //comprobamos que el tipo especifico no este vacio i que exista
                if (actividad.especifica.Equals("") || listEspecifica.Find(especifica => especifica.nombre.Equals(actividad.especifica)) == null)
                    throw new EspecificacionNotFoundException("La actividad " + actividad.id + " no existe la especificación");

                //comprobamos que la competencia no este vacio i que exista
                if (actividad.competencia.Equals("") || listCompetencia.Find(competencia => competencia.nombre.Equals(actividad.competencia)) == null)
                    throw new CompetenciaNotFoundException("La actividad " + actividad.id + " no existe la competéncia");
            }
        }

        //Comprobamos que las ponderaciones de competencia sumen 100
        private void ComprobarPoderacionCompetencia(List<CompetenciaRequest> listCompetencias)
        {
            float ponderacion = 0;
            foreach (var competencia in listCompetencias)
            {
                ponderacion += competencia.ponderacion;
            }
            if (ponderacion != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }


        //Comprobamos que las ponderaciones de Especifica sumen 100
        private void ComprobarPoderacionEspecifica(List<EspecificaRequest> listEspecificas)
        {
            float ponderacion = 0;
            foreach (var especifica in listEspecificas)
            {
                ponderacion += especifica.ponderacion;
            }
            if(ponderacion != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }

    }
}