using LupitBackEnd.Models;
using LupitBackEnd.Repositories.Times;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LupitBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimesRepository _timesRepository;

        public TimesController(ITimesRepository repository)
        {
            _timesRepository = repository;
        }

       
        [HttpGet]
        [Route("ListarTimes")]
        public async Task<IActionResult> ListarTimes()
        {
            return Ok(await _timesRepository.ListarTimes());
        }


       
        [HttpPost]
        [Route("AdicionarTime")]
        public async Task<IActionResult> AdicionarTime([FromBody] Time time)
        {
            return Ok(await _timesRepository.AdicionarTime(time));
        }

      
        [HttpPut]
        [Route("EditarTime/{id}")]
        public async Task<IActionResult> EditarTime(int id,[FromBody] Time time)
        {
            return Ok(await _timesRepository.EditarTime(time));
        }

        
        [HttpDelete("ExlcuirTime/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _timesRepository.RemoverTime(id));
        }
    }
}
