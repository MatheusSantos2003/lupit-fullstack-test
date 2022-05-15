using LupitBackEnd.Models;
using LupitBackEnd.Repositories.Jogadores;
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
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadoresRepository _jogadoresRepository;

        public JogadoresController(IJogadoresRepository repository)
        {
            _jogadoresRepository = repository;
        }


        [HttpGet]
        [Route("ListarJogadores")]
        public async Task<IActionResult> ListarJogadores()
        {
            return Ok(await _jogadoresRepository.ListarJogadores());
        }

        [HttpGet]
        [Route("BuscarJogador/{id}")]
        public async Task<IActionResult> BuscarJogador(int id)
        {
            return Ok(await _jogadoresRepository.BuscarJogador(id));
        }



        [HttpPost]
        [Route("AdicionarJogador")]
        public async Task<IActionResult> AdicionarJogadores([FromBody] Jogador jogador)
        {
            return Ok(await _jogadoresRepository.AdicionarJogador(jogador));
        }


        [HttpPut]
        [Route("EditarJogador/{id}")]
        public async Task<IActionResult> EditarJogador(int id,[FromBody] Jogador jogador)
        {
            return Ok(await _jogadoresRepository.EditarJogador(id,jogador));
        }


        [HttpDelete]
        [Route("ExcluirJogador/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jogadoresRepository.RemoverJogador(id));
        }
    }
}
