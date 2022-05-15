using Dapper;
using LupitBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LupitBackEnd.Repositories.Jogadores
{
    public class JogadoresRepository : IJogadoresRepository
    {
        IDataBaseConnection _conexao;

        public JogadoresRepository(IDataBaseConnection conexao)
        {
            _conexao = conexao;
        }


        public async Task<ResponseModel<List<Jogador>>> ListarJogadores()
        {
            ResponseModel<List<Jogador>> response = new ResponseModel<List<Jogador>>();
            StringBuilder query = new StringBuilder();
            query.AppendLine(" SELECT jogadores.*, public.times.name as Time FROM jogadores INNER JOIN public.times ON public.times.id = jogadores.time_id");

            try
            {
                var result = (await _conexao.Connection.QueryAsync<Jogador>(query.ToString())).ToList();
                response.Sucesso = true;
                response.Mensagem = "Jogadores Listados!";
                response.Resultado = result;
                return response;
            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema a listar os Jogadores! " + e;
                response.Resultado = null;
                return response;
            }
        }
        public async Task<ResponseModel<bool>> AdicionarJogador(Jogador jogador)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();
            query.AppendLine("INSERT INTO Jogadores (name,age,time_id,created_at,updated_at)  VALUES (@name,@age,@timeId,@created,@updated)");

            parametros.Add("@name", jogador.name);
            parametros.Add("@age", jogador.age);
            parametros.Add("@timeId", jogador.time_id);
            parametros.Add("@created", DateTime.Now);
            parametros.Add("@updated", DateTime.Now);

            try
            {

                var result = await _conexao.Connection.ExecuteAsync(query.ToString(), parametros);
                if (result < 0 || result == 0)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Houve um problema ao Cadastrar O Jogador! ";
                    response.Resultado = false;
                    return response;
                }
                else
                {

                    response.Sucesso = true;
                    response.Mensagem = "Jogador Cadastrado!";
                    response.Resultado = true;
                    return response;

                }

            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao adicionar o Jogador! " + e;
                response.Resultado = false;
                return response;
            }
        }

        public async Task<ResponseModel<bool>> EditarJogador(int id,Jogador jogador)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();

            query.AppendLine("UPDATE Jogadores SET name = @nome,age = @age , time_id = @timeId , updated_at = @updated WHERE id = @Id");

            parametros.Add("@nome", jogador.name);
            parametros.Add("@age", jogador.age);
            parametros.Add("@timeId", jogador.time_id);
            parametros.Add("@updated", DateTime.Now);
            parametros.Add("@Id", id);


            try
            {

                var result = await _conexao.Connection.ExecuteAsync(query.ToString(), parametros);
                if (result < 0 || result == 0)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Houve um problema ao Editar O Jogador! ";
                    response.Resultado = false;
                    return response;
                }
                else
                {

                    response.Sucesso = true;
                    response.Mensagem = "Jogador Editado!";
                    response.Resultado = true;
                    return response;

                }

            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao Editar o Jogador! " + e;
                response.Resultado = false;
                return response;
            }
        }

 
        public async Task<ResponseModel<bool>> RemoverJogador(int Id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();

            query.AppendLine("DELETE FROM Jogadores WHERE id = @Id");
            parametros.Add("@Id", Id);

            try
            {


                var result = await _conexao.Connection.ExecuteAsync(query.ToString(), parametros, _conexao.Transaction);
                response.Sucesso = true;
                response.Mensagem = "Jogador Excluido!";
                response.Resultado = true;
              
                return response;


            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao Exlcuir o Jogador! " + e;
                response.Resultado = false;
                return response;
            }

        }




        public void Dispose()
        {
            if (_conexao.Transaction != null)
            {
                _conexao.Transaction.Dispose();
            }
            _conexao.Connection.Dispose();
        }

        public async Task<ResponseModel<Jogador>> BuscarJogador(int id)
        {
            ResponseModel<Jogador> response = new ResponseModel<Jogador>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();
            query.AppendLine(" SELECT j.*,t.name as Time FROM jogadores j INNER JOIN times t ON t.id = j.time_id");
            query.AppendLine(" WHERE j.id = @id");
            parametros.Add("@id",id);


            try
            {
                var result = await _conexao.Connection.QueryFirstAsync<Jogador>(query.ToString(),parametros);
                response.Sucesso = true;
                response.Mensagem = "Jogadores Listados!";
                response.Resultado = result;
               return response;
            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema a listar os Jogadores! " + e;
                response.Resultado = null;
                return response;
            }


        }
    }
}
