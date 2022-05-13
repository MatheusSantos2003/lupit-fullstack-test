using Dapper;
using LupitBackEnd.Models;
using LupitBackEnd.Repositories.Times;
using System;
using System.Collections.Generic;
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
              

        public async Task<List<Time>> ListarTimes()
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("SELECT * FROM TIMES");

            var result = (await _conexao.Connection.QueryAsync<Time>(query.ToString())).ToList();
            return result;
        }

        public void Dispose()
        {
            _conexao.Connection.Dispose();
        }
    }
}