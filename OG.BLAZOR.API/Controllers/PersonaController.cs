using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OG.BLAZOR.BUSINESS;
using OG.BLAZOR.ENTITIES;

namespace OG.BLAZOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetPersonas()
        {
            try
            {
                return Ok(await new BPersona().GetPersonas());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EPersona>> GetPersona(int id)
        {
            try
            {
                var result = await new BPersona().GetPersona(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<EPersona>> AddPersona(EPersona p)
        {
            try
            {
                if (p == null)
                {
                    return BadRequest();
                }
                var result = await new BPersona().IngresarBD(p);
                if (result != 1)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<EPersona>> UpdatePersona(int id, EPersona p)
        {
            try
            {
                if (id != p.Id)
                {
                    return BadRequest();
                }
                var result = await new BPersona().ModificarBD(p);
                if (result != 1)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                var updatedPersona = await Task.FromResult(new BPersona().GetPersona(id));
                if (updatedPersona == null)
                {
                    return NotFound();
                }
                return Ok(updatedPersona);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EPersona>> DeletePersona(int id, EPersona p)
        {
            try
            {
                if (id != p.Id)
                {
                    return BadRequest();
                }
                var result = await new BPersona().ElminarBD(p);
                if (result != 1)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}