using HireEmployee.Entities;
using HireEmployee.IRepositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpPost("AddCandidate")]
        public async Task<Candidate> Create(Candidate candidate)
        {
            candidate.Job = null;
            var candidateResult =await _candidateRepository.AddCandidate(candidate);
            return candidateResult;
        }

        [HttpPost("GetAllCandidateById")]
        public async Task<IEnumerable<Candidate>> allCandidate(Guid id)
        {
            return await _candidateRepository.getAllCandidate(id);
        }

        [HttpPost("ConductPhoneScreening")]
        public void phoneScreening(string idString)
        {
            Guid id = Guid.Parse(idString);
            //Place request to conduct phone screening
        }

    }
}
