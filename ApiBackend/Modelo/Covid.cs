using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.Modelo
{
    public class Covid
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public int PositiveCases { get; set; }
        public int ConfirmedDeaths { get; set; }
        public int RecoveredPeople { get; set; }
        public string UserName { get; set; }
    }
}
