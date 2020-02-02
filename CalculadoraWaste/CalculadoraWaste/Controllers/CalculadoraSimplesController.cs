using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CalculadoraWaste.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraWaste.Controllers
{
    public class CalculadoraSimplesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calcular(List<MembroPartyViewModel> membrosParty)
        {
            var balanceTotalParty = membrosParty.Sum(x => x.Balance);
            var balancePorMembro = decimal.Round(balanceTotalParty / membrosParty.Count, 2);
            var membrosComBalanceMaior = membrosParty.Where(x => x.Balance > balancePorMembro);
            var listaPagamentos = new List<MembroPartyViewModel>();

            foreach (var membro in membrosComBalanceMaior)
            {
                foreach (var outroMembro in membrosParty.Where(x => x.Balance < balancePorMembro))
                {
                    if (membro.Balance <= balancePorMembro)
                        continue;

                    var diferencaBalancePorMembro = outroMembro.Balance - balancePorMembro;

                    if (membro.Balance > (diferencaBalancePorMembro < 0 ? diferencaBalancePorMembro * -1 : diferencaBalancePorMembro))
                    {
                        membro.Balance -= diferencaBalancePorMembro < 0 ? diferencaBalancePorMembro * -1 : diferencaBalancePorMembro;
                        membro.ValorPagar = diferencaBalancePorMembro < 0 ? diferencaBalancePorMembro * -1 : diferencaBalancePorMembro;
                        outroMembro.Balance += diferencaBalancePorMembro * -1;
                    }
                    else
                    {
                        var valorMembroPodePagar = membro.Balance - balancePorMembro;

                        membro.Balance -= valorMembroPodePagar;
                        membro.ValorPagar = valorMembroPodePagar;
                        outroMembro.Balance += valorMembroPodePagar;
                    }

                    listaPagamentos.Add(new MembroPartyViewModel
                    {
                        Nome = membro.Nome,
                        Balance = membro.Balance,
                        ValorPagar = membro.ValorPagar,
                        PagarPara = outroMembro.Nome
                    });
                }
            }

            var resultado = new ResultadoViewModel
            {
                BalanceTotalParty = balanceTotalParty,
                BalancePorMembro = balancePorMembro,
                MembroParty = listaPagamentos
            };

            return View("_Resultado", resultado);
        }
    }
}