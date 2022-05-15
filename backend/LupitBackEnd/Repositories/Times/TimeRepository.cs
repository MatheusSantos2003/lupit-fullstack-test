using Dapper;
using LupitBackEnd.Models;
using LupitBackEnd.Repositories.Times;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LupitBackEnd.Repositories
{
    public class TimesRepository : ITimesRepository
    {
        IDataBaseConnection _conexao;

        public TimesRepository(IDataBaseConnection conexao)
        {
            _conexao = conexao;
        }
              

        public async Task<ResponseModel<List<Time>>> ListarTimes()
        {
            ResponseModel<List<Time>> response = new ResponseModel<List<Time>>();
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT * FROM Times");

            try
            {
                var result = (await _conexao.Connection.QueryAsync<Time>(query.ToString())).ToList();
                response.Sucesso = true;
                response.Mensagem = "Times Listados!";
                response.Resultado = result;
                return response;
            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema a listar os times! "+e;
                response.Resultado = null;
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

        public async Task<ResponseModel<bool>> AdicionarTime(Time time)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();
            query.AppendLine("INSERT INTO Times (name,created_at,updated_at) VALUES (@name,@created,@updated)");

            parametros.Add("@name", time.name);
            parametros.Add("@created", DateTime.Now,DbType.DateTime );
            parametros.Add("@updated", DateTime.Now, DbType.DateTime);

            try
            {

                var result = await _conexao.Connection.ExecuteAsync(query.ToString(),parametros);
                if (result < 0 || result == 0)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Houve um problema ao Cadastrar O Time! ";
                    response.Resultado = false;
                    return response;
                } else {

                    response.Sucesso = true;
                    response.Mensagem = "Time Cadastrado!";
                    response.Resultado = true;
                    return response;

                }
             
            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao adicionar o time! " + e;
                response.Resultado = false;

                return response;
            }

        }

        public async Task<ResponseModel<bool>> EditarTime(Time time)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();

            query.AppendLine("UPDATE Times SET name = @nome AND updated_at = @updated WHERE Id = @Id");

            parametros.Add("@nome", time.name);
            parametros.Add("@updated", DateTime.Now);
            parametros.Add("@Id", time.Id);


            try
            {

                var result = await _conexao.Connection.ExecuteAsync(query.ToString(), parametros);
                if (result < 0 || result == 0)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Houve um problema ao Editar O Time! ";
                    response.Resultado = false;
                    return response;
                }
                else
                {

                    response.Sucesso = true;
                    response.Mensagem = "Time Editado!";
                    response.Resultado = true;
                    return response;

                }

            }
            catch (Exception e)
            {
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao Editar os times! " + e;
                response.Resultado = false;
                return response;
            }
        }

        public async Task<ResponseModel<bool>> RemoverTime(int Id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            StringBuilder query = new StringBuilder();
            DynamicParameters parametros = new DynamicParameters();

            query.AppendLine("DELETE FROM Times WHERE Id = @Id");

            try
            {
                _conexao.Connection.BeginTransaction();

                var result = await _conexao.Connection.ExecuteAsync(query.ToString(), parametros, _conexao.Transaction);
                response.Sucesso = true;
                response.Mensagem = "Time Excluido!";
                response.Resultado = true;
                _conexao.Transaction.Commit();
                return response;


            }
            catch (Exception e)
            {
                _conexao.Transaction.Rollback();
                response.Sucesso = false;
                response.Mensagem = "Houve um problema ao Exlcuir o time! " + e;
                response.Resultado = false;
                return response;
            }

            
        }
    }
}