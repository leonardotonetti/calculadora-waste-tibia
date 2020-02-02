using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraWaste.Models
{
    public class ResultadoViewModel
    {
        public decimal BalanceTotalParty { get; set; }
        public decimal BalancePorMembro { get; set; }

        public List<MembroPartyViewModel> MembroParty { get; set; }
    }
}
