using Microsoft.AspNetCore.Mvc;
using SonicEar_Backend.Classes;
using SonicEar_Backend.Interfaces;
using SonicEar_Backend.Models;

namespace SonicEar_Backend.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private IMeasurementsRepository _measurementsRepository;

        public MeasurementController(IMeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Measurement>> Get()
        {
            IEnumerable<Measurement> result = _measurementsRepository.GetAll();
            if(result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Measurement> Get(int id)
        {
            Measurement? measurement = _measurementsRepository.GetById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return Ok(measurement);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Measurement> Post([FromBody] Measurement newMeasurement)
        {
            try
            {
                Measurement createdMeasurement = _measurementsRepository.Create(newMeasurement);
                return Created("/" + createdMeasurement.Id, createdMeasurement);
            }
            catch (Exception ex) when (ex is ArgumentNullException) 
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Measurement> Delete(int id) 
        {
            Measurement? deletedMeasurement = _measurementsRepository.Delete(id);
            if (deletedMeasurement == null)
            {
                return NotFound();
            }
            else return Ok(deletedMeasurement);
        }
    }
}
