﻿using Microsoft.AspNetCore.Mvc;
using SonicEar_Backend.Interfaces;
using SonicEar_Backend.Models;

namespace SonicEar_Backend.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IDevicesRepository _devicesRepository;

        public DeviceController(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Device>> Get()
        {
            IEnumerable<Device> result = _devicesRepository.GetAll();
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
        public ActionResult<Device> Get(int id)
        {
            Device? device = _devicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Device> Post([FromBody] Device newDevice)
        {
            try
            {
                Device createdDevice = _devicesRepository.Create(newDevice);
                return Created("/" + createdDevice.Id, createdDevice);
            }
            catch (ArgumentNullException ex)  
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public ActionResult<Device> Put(int id, [FromBody] Device device)
        {
            try
            {
                Device? updatedDevice = _devicesRepository.Update(device, id);
                if (updatedDevice == null) return NotFound();
                else return Ok(updatedDevice);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Device> Delete(int id) 
        {
            Device? deletedDevice = _devicesRepository.Delete(id);
            if (deletedDevice == null)
            {
                return NotFound();
            }
            else return Ok(deletedDevice);
        }
    }
}