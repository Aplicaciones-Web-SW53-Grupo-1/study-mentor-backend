using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _1._API.Response;
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
    public class ScoreController : ControllerBase
    {
        private IScoreDomain _scoreDomain;
        private IScoreData _scoreData;
        private IMapper _mapper;

        public ScoreController(IScoreDomain scoreDomain, IScoreData scoreData, IMapper mapper)
        {
            _scoreDomain = scoreDomain;
            _scoreData = scoreData;
            _mapper = mapper;
        }

        // GET: api/Score
        [HttpGet]
        public async Task<List<ScoreResponse>> GetAsync()
        {
            var scores = await _scoreData.GetAllAsync();
            var scoreResponses = _mapper.Map<List<Score>, List<ScoreResponse>>(scores);
            return scoreResponses;
        }

        // GET: api/Score/scores/student/1
        [HttpGet("scores/student/{studentId}")]
        public List<ScoreResponse> GetScoresByStudent(int studentId)
        {
            var scores = _scoreData.GetByIdStudent(studentId);
            var scoreResponses = _mapper.Map<List<Score>, List<ScoreResponse>>(scores);
            return scoreResponses;
        }

        // GET: api/Score/scores/tutor/1
        [HttpGet("scores/tutor/{tutorId}")]
        public List<ScoreResponse> GetScoresByTutor(int tutorId)
        {
            var scores = _scoreData.GetByIdTutor(tutorId);
            var scoreResponses = _mapper.Map<List<Score>, List<ScoreResponse>>(scores);
            return scoreResponses;
        }

        // POST: api/Score
        [HttpPost]
        public IActionResult Post([FromBody] ScoreRequest request)
        {
            if (ModelState.IsValid)
            {
                var score = _mapper.Map<ScoreRequest, Score>(request);
                // Añadir lógica para establecer tutorId y studentId según tus requisitos
                return Ok(_scoreDomain.Create(score));
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Score/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Score/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
