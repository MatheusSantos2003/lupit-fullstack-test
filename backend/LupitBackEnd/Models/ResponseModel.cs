using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Models
{
    public class ResponseModel<T>
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public T Resultado { get; set; }
    }
}
