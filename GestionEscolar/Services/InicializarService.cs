using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Repository;
using static GestionEscolar.DTO.InicializarRequest;

namespace GestionEscolar.Services
{
    public class InicializarService
    {
        //Servicios
        private PonderacionesService ponderacionesService = new PonderacionesService();

        //Inicializacion de datos
        public void inicializarDatos(InicializarRequest datos)
        {
            comprobarPoderacionCompetencia(datos.listCompetencias);
            comprobarPoderacionEspecifica(datos.listEspecificas);
            getDatosOK(datos);
            //Aqui guradariamos los datos en caso de tener persistencia de datos
        }

        //Comprobar que la'actividad es correcta
        public void getDatosOK(InicializarRequest datos)
        {
            //guardamos los datos en listas
            List<InicializarRequest.Actividad> listActividades = datos.listActividades;
            List<Competencia> listCompetencia = datos.listCompetencias;
            List<Especifica> listEspecifica = datos.listEspecificas;

            foreach (var actividad in listActividades)            
            {
                //comprobamos que el tipo especifico no este vacio i que exista
                if (actividad.especifica.Equals("") || listEspecifica.Find(especifica => especifica.nombre.Equals(actividad.especifica)) == null)
                    throw new EspecificacionNotExistException("La actividad " + actividad.id + " no existe la especificación");

                //comprobamos que la competencia no este vacio i que exista
                if (actividad.competencia.Equals("") || listCompetencia.Find(competencia => competencia.nombre.Equals(actividad.competencia)) == null)
                    throw new CompetenciaNotExistException("La actividad " + actividad.id + " no existe la competéncia");
            }
        }

        //Comprobamos que las ponderaciones de competencia sumen 100
        private void comprobarPoderacionCompetencia(List<Competencia> listCompetencias)
        {
            float ponderacio = 0;
            foreach (var competencia in listCompetencias)
            {
                ponderacio += competencia.ponderacion;
            }
            if (ponderacio != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }


        //Comprobamos que las ponderaciones de Especifica sumen 100
        private void comprobarPoderacionEspecifica(List<Especifica> listEspecificas)
        {
            float ponderacio = 0;
            foreach (var especifica in listEspecificas)
            {
                ponderacio += especifica.ponderacion;
            }
            if(ponderacio != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }

    }
}