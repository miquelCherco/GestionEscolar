using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{

    [ApiController]
    [Route("evaluacion")]
    public class EvaluacionController : ControllerBase
    {

        //Servicios
        public EvaluacionService evaluacionService = new EvaluacionService();

        [HttpPost]
        [Route("envio-respuestas/{idActividad}")]
        //envio de nuevas respuestas de una actividad
        public IActionResult EnvioRespuestas(int idActividad, [FromBody] EnvioRespuestaRequest envioRespuestaRequest)
        {
            ActividadResponse actividadResponse;
            try
            {
                actividadResponse = evaluacionService.EnviarRespuestas(idActividad, envioRespuestaRequest);
            }
            catch (ActividadNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EjercicioNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PreguntaNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PreguntaRepetidaException ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", actividadResponse);
        }

        [HttpGet]
        [Route("nota-evaluacion/{evaluacion}")]
        //obtener nota por tipo de evaluacion
        public IActionResult GetNotaByEvaluacion(string evaluacion)
        {
            float nota = 0;
            try
            {
                nota = evaluacionService.GetNotasByEvaluacion(evaluacion);
            }
            catch (EvaluacioNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(nota.ToString());
        }
    }
}
