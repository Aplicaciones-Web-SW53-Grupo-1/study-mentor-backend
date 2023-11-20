using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleData _scheduleData;
        private IScheduleDomain _scheduleDomain;

        public ScheduleController(IScheduleData scheduleData, IScheduleDomain scheduleDomain)
        {
            _scheduleData = scheduleData;
            _scheduleDomain = scheduleDomain;
        }
        
        // GET: api/Schedule/5
        [HttpGet("{id}", Name = "GetSchedule")]
        public string Get(int id)
        {
            return ("Id: " + id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ScheduleRequest request)
        {
            try
            {
                Schedule schedule = new Schedule()
                {
                Description = request.Description,
                Title = request.Title,
                DateCreated = request.DateCreated,
                StudentId = request.StudentId
                // Agrega otros campos según sea necesario
                };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_scheduleDomain.Create(schedule))
            {
                return Ok();
            }

            return StatusCode(500, "Error interno del servidor");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Schedule/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
