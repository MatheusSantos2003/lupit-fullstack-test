using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Models
{
    public class DataBaseConnection : IDataBaseConnection
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }


        public DataBaseConnection()
        {


            this.Connection = new NpgsqlConnection("Server=localhost;Database=lupit;Uid=postgres;Pwd='root';");
            this.Connection.Open();

        }
    }
}
