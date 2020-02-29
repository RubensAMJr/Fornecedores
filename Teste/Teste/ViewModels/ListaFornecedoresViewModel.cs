using System;
using System.Collections.Generic;
using Teste.Models;

namespace Teste.Controllers
{
    public class ListaFornecedoresViewModel
    {
        public List<Fornecedor> Fornecedores { get; set; }
        public string FiltroNome { get; set; }

        public string FiltroCPF { get; set; }

        public string FiltroCNPJ { get; set; }
        public DateTime FiltroDataCadastro { get; set; }

        public ListaFornecedoresViewModel(List<Fornecedor> fornecedors)
        {
            Fornecedores = fornecedors;
        }

    }
}
