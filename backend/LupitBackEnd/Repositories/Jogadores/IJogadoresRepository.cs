using LupitBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Repositories.Jogadores
{
    public interface IJogadoresRepository : IBaseRepository
    {
        Task<ResponseModel<List<Jogador>>> ListarJogadores();
        Task<ResponseModel<Jogador>> BuscarJogador(int id);
        Task<ResponseModel<bool>> AdicionarJogador(Jogador jogador);
        Task<ResponseModel<bool>> EditarJogador(int id,Jogador jogador);
        Task<ResponseModel<bool>> RemoverJogador(int Id);


    }
}
