using LupitBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Repositories.Times
{
    public interface ITimesRepository: IBaseRepository
    {
        Task<ResponseModel<List<Time>>> ListarTimes();
        Task<ResponseModel<bool>> AdicionarTime(Time time);
        Task<ResponseModel<bool>> EditarTime(Time time);
        Task<ResponseModel<bool>> RemoverTime(int Id);
    }
}
