using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupitBackEnd.Models
{
    public class Jogador
    {
        public int Id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public int time_id { get; set; }

        public string Time { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
