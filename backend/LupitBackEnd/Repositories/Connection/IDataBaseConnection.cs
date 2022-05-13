using System.Data;

namespace LupitBackEnd.Models
{
    public interface IDataBaseConnection
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }
    }
}