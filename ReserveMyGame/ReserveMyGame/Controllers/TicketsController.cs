using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReserveMyGame.Services.Interfaces;
using ReserveMyGame.Models.User.Customer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveMyGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // POST api/<TicketsController>
        [HttpPost]
        public void Post([FromBody] TicketDTO ticketDTO)
        {
            _ticketService.Create(ticketDTO);
        }
    }
}
