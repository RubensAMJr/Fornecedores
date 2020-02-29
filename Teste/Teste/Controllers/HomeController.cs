using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste.DAO;
using Teste.Models;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string filtroNome, string filtroCPF, string filtroCNPJ,DateTime filtroDataCadastro)
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            if (FiltroValidoFornecedor(filtroNome, filtroCPF, filtroCNPJ, filtroDataCadastro))
                fornecedores = FornecedorDAO.GetAllFiltrado(filtroNome, filtroCPF,filtroCNPJ, filtroDataCadastro);
            else
                fornecedores = FornecedorDAO.GetAll();

            if (fornecedores.Count > 0)
            {
                foreach (var fornecedor in fornecedores)
                {
                    fornecedor.Empresa = EmpresaDAO.GetById(fornecedor.EmpresaFK);
                }
            }

            return View(new ListaFornecedoresViewModel(fornecedores));
        }

        public IActionResult ListaEmpresas(string filtroNome, string filtroCNPJ, string filtroUF)
        {
            List<Empresa> empresas = new List<Empresa>();
            if (FiltroValidoEmpresa(filtroNome, filtroCNPJ, filtroUF))
                empresas = EmpresaDAO.GetAllFiltrado(filtroNome, filtroCNPJ, filtroUF);
            else
                empresas = EmpresaDAO.GetAll();

            return View(new ListaEmpresasViewModel(empresas));
        }

        private static bool FiltroValidoEmpresa(string filtroNome, string filtroCNPJ, string filtroUF)
        {
            return filtroNome != null || filtroCNPJ != null || filtroUF != null;
        }

        private static bool FiltroValidoFornecedor(string filtroNome, string filtroCPF, string filtroCNPJ, DateTime filtroDataCadastro)
        {
            return filtroNome != null || filtroCPF != null || filtroCNPJ != null || filtroDataCadastro.ToShortDateString() != "01/01/0001";
        }

    }
}
