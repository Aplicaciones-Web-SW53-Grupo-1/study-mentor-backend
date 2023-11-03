using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ScheduleController(IScheduleData scheduleData)
        {
            _scheduleData = scheduleData;
        }
        
        
        // GET: api/Schedule
        [HttpGet ]
        public IEnumerable<string> Get()
        {
            return new string[] { "asd", "ads" };
        }

        // GET: api/Schedule/5
        [HttpGet("{id}", Name = "GetSchedule")]
        public string Get(int id)
        {
            return ("Id: " + id);
        }

        // POST: api/Schedule
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
