using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Elsa.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Elsa.Server.Pages
{
    public class ViewTicketModel : PageModel
    {
       public Guid TicketId { get; set; }
        public TicketRequest ticketRequest { get; set; }

       public async Task<IActionResult> OnGetAsync(string ticketId)
        //public async void OnGetAsync(Guid ticketId)
        {
           //TicketId = ticketId;

            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(ticketId);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.GetAsync("http://nginx:81/api/Ticket/GetTicket?id=" + ticketId).Result;
//http://ticketprocessingrestapi:80/api/Ticket/GetTicket?id=
                var claim = await response.Content.ReadAsStringAsync();
                ticketRequest = JsonConvert.DeserializeObject<TicketRequest>(claim);
            }
            return Page();

        }









        /*public void OnGet()
        {

        }*/
    }
}
