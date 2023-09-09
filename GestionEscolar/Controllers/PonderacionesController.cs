using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{

    [ApiController]
    [Route("ponderaciones")]
    public class PonderacionesController : ControllerBase
    {
        //Servicios
        public PonderacionesService ponderacionesService = new PonderacionesService();

        [HttpPatch]
        [Route("ponderacion/{evaluacion}")]
        //modificar ponderaciones
        public IActionResult ModificarPonderacion(string evaluacion, [FromBody] PonderacionesRequest ponderaciones)
        {
            PonderacionesResponse ponderacionesResponse = new PonderacionesResponse();
            try
            {
                ponderacionesResponse = ponderacionesService.ModificarPonderacion(evaluacion, ponderaciones);
            }
            catch (EvaluacioNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PonderacionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CompetenciaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EspecificacionNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(ponderacionesResponse);
        }

    }
}
