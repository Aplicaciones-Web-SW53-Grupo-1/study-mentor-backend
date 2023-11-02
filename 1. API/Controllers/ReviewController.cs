using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewData _reviewData;
        private IReviewDomain _reviewDomain;
        
        //automapper
        private IMapper _mapper;

        public ReviewController(IReviewData reviewData, IReviewDomain reviewDomain, IMapper mapper)
        {
            _reviewData = reviewData;
            _reviewDomain = reviewDomain;
            _mapper = mapper;
        }
        
        // GET: api/Review
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Review/5
        [HttpGet("{id}", Name = "GetReview")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Review
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
