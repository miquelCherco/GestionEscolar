﻿using GestionEscolar.DTO;
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

        [HttpPost]
        [Route("inicializar-datos")]
        //Inicializar datos
        public IActionResult InicializarDatos([FromBody] InicializarRequest inicializarRequest)
        {
            try
            {
                inicializarService.InicializarDatos(inicializarRequest);
            }
            catch (CompetenciaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EspecificacionNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PonderacionException ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("", "OK");
        }
    }
}

