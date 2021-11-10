using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TicketProcessingRestApi.Entities;
using TicketProcessingRestApi.IRepository.IRepository;

namespace TicketProcessingRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository _ticketRepository)
        {
            this.ticketRepository = _ticketRepository;
        }

        [HttpGet("GetAllTickets")]
        public async Task<ActionResult> GetAllUsers()
        {
            var dtos = (await ticketRepository.ListAllAsync()).OrderBy(x => x.CreateDate);
            return Ok(dtos);
        }



        [HttpPost("AddTicket")]
        public async Task<Ticket> Create(Ticket ticketEntity)
        {
            ticketEntity.CreateDate = DateTime.Now;

            var response = await ticketRepository.AddAsync(ticketEntity);
            /* using(HttpClient httpClient = new HttpClient())
             {
                 string JsonResult = JsonConvert.SerializeObject(response);
                 StringContent stringContent = new StringContent(JsonResult, System.Text.Encoding.UTF8, "application/json");
                 HttpResponseMessage httpResponse = httpClient.PostAsync("", httpContent).Result);
             }*/

            return response;
        }

        [HttpPut("assignManager")]
        public async Task<ActionResult> AssignTicketToMAnager(Ticket ticketEntity)
        {
            TimeSpan start = new TimeSpan(10, 0, 0); //10am o'clock
            TimeSpan end = new TimeSpan(20, 0, 0); //8pm o'clock

            TimeSpan now = DateTime.Now.TimeOfDay;

            if (start <= end)
            {
                if ((now >= start) && (now <= end))
                {
                    switch (ticketEntity.TicketType)
                    {
                        case "IT":
                            ticketEntity.assignManager = "vaibhav.kulkarni@gmail.com";
                            break;
                        case "HR":
                            ticketEntity.assignManager = "simrangmail.com";
                            break;
                        case "Admin":
                            ticketEntity.assignManager = "vaibhav.kulkarni@gmail.com";
                            break;
                    }
                }
            }
            else
            {
                switch (ticketEntity.TicketType)
                {
                    case "IT":
                        ticketEntity.assignManager = "neha.haridas@gmail.com";
                        break;
                    case "HR":
                        ticketEntity.assignManager = "Shradha@gmail.com";
                        break;
                    case "Admin":
                        ticketEntity.assignManager = "bhavesh@gmail.com";
                        break;
                }

            }

            await ticketRepository.UpdateAsync(ticketEntity);
            return Ok();
        }
        [HttpPut("AssignTicket")]
        public async Task<ActionResult> AssignTickettoPerson(Ticket ticketEntity)
        {
            ticketEntity.assignDate = DateTime.Now;
            await ticketRepository.UpdateAsync(ticketEntity);
            return Ok();
        }
        [HttpPut("IsResloved")]
        public async Task<ActionResult> IssueResolve(Ticket ticketEntity)
        {
            ticketEntity.isResolved = true;
            await ticketRepository.UpdateAsync(ticketEntity);
            return Ok();
        }
    }
}
