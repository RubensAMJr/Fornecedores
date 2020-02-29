using Microsoft.AspNetCore.Mvc;
using Teste.DAO;
using Teste.Models;
using Teste.Classes;
using System.Text.RegularExpressions;
using System;

namespace Teste.Controllers
{
    public class CadastrosController : Controller
    {
        public IActionResult Cadastros()
        {
            return View();
        }

        public IActionResult Empresa(string mensagem,bool sucess)
        {
            string[] uf = Estados.UF.Split(';');
            ViewBag.uf = uf;
            return View(new EmpresaViewModel(new Empresa(),mensagem,sucess));
        }

        public IActionResult Fornecedor(string mensagem,bool sucess)
        {
            return View(new FornecedorViewModel(EmpresaDAO.GetAll(),new Fornecedor(),mensagem,sucess));
        }

        [HttpPost]
        public IActionResult CadastraEmpresa(Empresa empresa)
        {
            if (!CNPJValido(empresa.CNPJ))
            {
                return RedirectToAction("Empresa", new { mensagem = "CNPJ Inalido!", sucess = false });
            }
            EmpresaDAO.Adiciona(empresa);
            return RedirectToAction("Empresa", new { mensagem = "Cadastrada com sucesso", sucess = true });
        }

        [HttpPost]
        public IActionResult CadastraFornecedor(Fornecedor fornecedor)
        {
            const int PESSOA_FISICA = 1;
            const int PESSOA_JURIDICA = 2;

            if (PessoaMaiorDeIdadeCasoEmpresaForDoParana(fornecedor))
                return RedirectToAction("Fornecedor", new { mensagem = "Para empresas do Paraná o fornecedor deve ter mais de 18 anos.", sucess = false });

            else if (fornecedor.TipoPessoa == PESSOA_FISICA && !CPFValido(fornecedor.CPF))
                return RedirectToAction("Fornecedor", new { mensagem = "CPF invalido.", sucess = false });

            else if (fornecedor.TipoPessoa == PESSOA_JURIDICA && !CNPJValido(fornecedor.CNPJ))
                return RedirectToAction("Fornecedor", new { mensagem = "CNPJ invalido.", sucess = false });

            FornecedorDAO.Adiciona(fornecedor);
            return RedirectToAction("Fornecedor", new { mensagem = "Fornecedor cadastrado com sucesso.", sucess = true });
        }

        private static bool CNPJValido(string CNPJ)
        {
            return Regex.IsMatch(CNPJ, @"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}");
        }

        private static bool CPFValido(string CPF)
        {
            return Regex.IsMatch(CPF, @"[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}");
        }

        private static bool PessoaMaiorDeIdadeCasoEmpresaForDoParana(Fornecedor fornecedor)
        {
            return EmpresaDAO.GetById(fornecedor.EmpresaFK).UF.Equals("PR") && (DateTime.Now.Year - fornecedor.DataNascimento.Year) < 18;
        }
    }
}