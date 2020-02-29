using System.Collections.Generic;
using Teste.Models;

namespace Teste.Controllers
{
    public class ListaEmpresasViewModel
    {
        public List<Empresa> Empresas { get; set; }
        public string FiltroNome { get; set; }
        public string FiltroCNPJ { get; set; }
        public string FiltroUf { get; set; }

        public ListaEmpresasViewModel(List<Empresa> empresas)
        {
            Empresas = empresas;
        }

    }
}
