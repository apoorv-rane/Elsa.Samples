using HireEmployee.Entities;
using HireEmployee.IRepositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
            candidate.Review = false;
            candidate.PhoneScreening = false;
            candidate.Interview = false;
            candidate.OfferAccepted = false;
            var candidateResult =await _candidateRepository.AddCandidate(candidate);
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(candidateResult);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response1 = client.PostAsync("https://localhost:44391/initiateHiring", httpContent).Result;
            }
            return candidateResult;
        }

        [HttpPost("setReviewStatus")]
        public async Task<bool> UpdateReview(Guid id,bool status)
        {
            Candidate candidate =await _candidateRepository.GetByIdAsync(id);
            candidate.Review = status;
            await _candidateRepository.UpdateAsync(candidate);
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(candidate);
                client.DefaultRequestHeaders.Add("X-Correlation-Id", candidate.Id.ToString());
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PostAsync("https://localhost:44391/handleReview", httpContent).Result;
            }
            return status;
        }

        [HttpPost("setPhoneScreenStatus")]
        public async Task<bool> UpdatePhoneScreen(Guid id, bool status)
        {
            Candidate candidate = await _candidateRepository.GetByIdAsync(id);
            candidate.PhoneScreening = status;
            await _candidateRepository.UpdateAsync(candidate);
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(candidate);
                client.DefaultRequestHeaders.Add("X-Correlation-Id", candidate.Id.ToString());
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PostAsync("https://localhost:44391/handlePhoneScreening", httpContent).Result;
            }
            return status;
        }

        [HttpPost("setInterviewStatus")]
        public async Task<bool> UpdateInterview(Guid id, bool status)
        {
            Candidate candidate = await _candidateRepository.GetByIdAsync(id);
            candidate.Interview = status;
            await _candidateRepository.UpdateAsync(candidate);
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(candidate);
                client.DefaultRequestHeaders.Add("X-Correlation-Id", candidate.Id.ToString());
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PostAsync("https://localhost:44391/handleInterview", httpContent).Result;
            }
            return status;
        }

        [HttpPost("setOfferAcceptedStatus")]
        public async Task<bool> UpdateOfferAccepted(Guid id, bool status)
        {
            Candidate candidate = await _candidateRepository.GetByIdAsync(id);
            candidate.OfferAccepted = status;
            await _candidateRepository.UpdateAsync(candidate);
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(candidate);
                client.DefaultRequestHeaders.Add("X-Correlation-Id", candidate.Id.ToString());
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PostAsync("https://localhost:44391/handleOfeerAccepted", httpContent).Result;
            }
            return status;
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
