using Teste.Models;

namespace Teste.Controllers
{
    public class EmpresaViewModel
    {
        public Empresa Empresa {get;set;}
        public string  Mensagem { get; set; }

        public bool Sucess { get; set; }

        public EmpresaViewModel(Empresa empresa,string mensagem, bool sucess)
        {
            Empresa = empresa;
            Mensagem = mensagem;
            Sucess = sucess;
        }

    }

}