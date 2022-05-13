using LupitBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Repositories.Times
{
    public interface ITimesRepository: IBaseRepository
    {
        Task<List<Time>> ListarTimes();
    }
}
