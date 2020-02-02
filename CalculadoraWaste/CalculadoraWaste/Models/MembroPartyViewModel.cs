using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraWaste.Models
{
    public class MembroPartyViewModel
    {
        public string Nome { get; set; }
        public decimal Balance { get; set; }
        public decimal ValorPagar { get; set; }
        public string PagarPara { get; set; }
    }   
}
