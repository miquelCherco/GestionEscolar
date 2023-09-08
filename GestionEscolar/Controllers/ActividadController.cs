using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    [ApiController]
    [Route("actividades")]
    public class ActividadController : ControllerBase
    {
        //Servicios
        public InicializarService inicializarService = new InicializarService();
        public EvaluacionService evaluacionService = new EvaluacionService();
        public PonderacionesService ponderacionesService = new PonderacionesService();

        [HttpPost]
        [Route("inicializarDatos")]
        //Inicializar datos
        public dynamic inicializarDatos([FromBody] InicializarRequest inicializarRequest)
        {
            try
            {
                inicializarService.inicializarDatos(inicializarRequest);
                return "OK";
            }
            catch (CompetenciaNotExistException ex)
            {
                return ex.Message;
            }
            catch (EspecificacionNotExistException ex)
            {
                return ex.Message;
            }
            catch (PonderacionException ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("envioRespuestas")]
        //envio de nuevas respuestas de una actividad
        public dynamic envioRespuestas(int idActividad, [FromBody] EnvioRespuestaRequest envioRespuestaRequest)
        {
            ActividadResponse actividadResponse = null;
            try
            {
                actividadResponse = evaluacionService.enviarRespuestas(idActividad,envioRespuestaRequest);
            }catch (ActividadNotFoundException ex)
            {
                return ex.Message;
            }
            catch (EjercicioNotFoundException ex)
            {
                return ex.Message;
            }
            catch (PreguntaNotFoundException ex)
            {
                return ex.Message;
            }
            catch (PreguntaRepetidaExeption ex)
            {
                return ex.Message;
            }
            return actividadResponse;
        }

        [HttpGet]
        [Route("getNotasByEvaluacion")]
        //obtener nota por tipo de evaluacion
        public dynamic getNotaByEvaluacion(String evaluacion)
        {
            float nota = 0;
            try
            {
                nota = evaluacionService.getNotasByEvaluacion(evaluacion);
            }catch (EvaluacioNotFoundException ex)
            {
                return ex.Message;
            }
            return nota.ToString();
        }


        [HttpPatch]
        [Route("modificarPonderacion")]
        //modificar ponderaciones
        public dynamic modificarPonderacion(String evaluacion,[FromBody] PonderacionesRequest ponderaciones)
        {

            PonderacionesResponse ponderacionesResponse = new PonderacionesResponse();
            try
            {
                ponderacionesResponse = ponderacionesService.modificarPonderacion(evaluacion,ponderaciones);
            }
            catch (EvaluacioNotFoundException ex)
            {
                return ex.Message;
            }
            catch (PonderacionException ex)
            {
                return ex.Message;
            }
            catch (CompetenciaNotExistException ex)
            {
                return ex.Message;
            }
            catch (EspecificacionNotExistException ex)
            {
                return ex.Message;
            }
            return ponderacionesResponse;
        }

    }
}

