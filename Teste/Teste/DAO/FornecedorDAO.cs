using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.DAO
{
    public static class FornecedorDAO
    {
        public static void Adiciona(Fornecedor fornecedor)
        {
            using (var context = new FornecedoresContext())
            {
                context.Fornecedor.Add(fornecedor);
                context.SaveChanges();
            }
        }

        public static List<Fornecedor> GetAllFiltrado(string filtroNome, string filtroCPF, string filtroCNPJ, DateTime filtroDataCadastro)
        {
            using (var context = new FornecedoresContext())
            {
                List<Fornecedor> fornecedores = context.Fornecedor.ToList();
                if (FiltroValido(filtroNome))
                    fornecedores = fornecedores.Where(f => f.Nome == filtroNome).ToList();

                if (FiltroValido(filtroCPF))
                    fornecedores = fornecedores.Where(f => f.CPF == filtroCPF).ToList();

                if (FiltroValido(filtroCNPJ))
                    fornecedores = fornecedores.Where(f => f.CNPJ == filtroCNPJ).ToList();

                if (FiltroDataValido(filtroDataCadastro))
                    fornecedores = fornecedores.Where(f => f.DataCadastro.ToShortDateString() == filtroDataCadastro.ToShortDateString()).ToList();

                return fornecedores;
            }
        }

        public static List<Fornecedor> GetAll()
        {
            using (var context = new FornecedoresContext())
            {
                return context.Fornecedor.OrderBy(e => e.Nome).ToList();
            }
        }

        public static void Deleta(Fornecedor fornecedor)
        {
            using (var context = new FornecedoresContext())
            {
                context.Fornecedor.Remove(context.Fornecedor.FirstOrDefault(f => f.Id == fornecedor.Id));
                context.SaveChanges();
            }
        }

        private static bool FiltroValido(string filtro)
        {
            return filtro != null && filtro != "";
        }

        private static bool FiltroDataValido(DateTime filtro)
        {
            return filtro.ToShortDateString() != "01/01/0001"; ;
        }
    }
}
