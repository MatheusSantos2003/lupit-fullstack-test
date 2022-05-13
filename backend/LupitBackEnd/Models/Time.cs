using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Models
{
    public class Time
    {
       
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
