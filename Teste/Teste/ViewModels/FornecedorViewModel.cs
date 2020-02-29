using System.Collections.Generic;
using Teste.Models;

namespace Teste.Controllers
{
    public class FornecedorViewModel
    {
        public Fornecedor Fornecedor { get; set; }
        public List<Empresa> Empresas { get; set; }
        public string Mensagem { get; set; }

        public bool Sucess { get; set; }

        public FornecedorViewModel(List<Empresa> empresas,Fornecedor fornecedor, string mensagem, bool sucess)
        {
            Fornecedor = fornecedor;
            Mensagem = mensagem;
            Sucess = sucess;
            Empresas = empresas;
        }

    }

}