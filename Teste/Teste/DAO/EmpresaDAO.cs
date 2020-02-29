using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.DAO
{
    public class EmpresaDAO
    {
        public static void Adiciona(Empresa empresa)
        {
            using (var context = new FornecedoresContext())
            {
                context.Empresa.Add(empresa);
                context.SaveChanges();
            }
        }

        public static void Deleta(Empresa empresa)
        {
            using (var context = new FornecedoresContext())
            {
                context.Empresa.Remove(context.Empresa.FirstOrDefault(e => e.CNPJ == empresa.CNPJ));
                context.SaveChanges();
            }
        }

        public static List<Empresa> GetAll()
        {
            using (var context = new FornecedoresContext())
            {
                return context.Empresa.OrderBy(e => e.NomeFantasia).ToList();
            }
        }

        public static List<Empresa> GetAllFiltrado(string filtroNomeFantasia, string filtroCNPJ, string filtroUF)
        {
            using (var context = new FornecedoresContext())
            {
                List<Empresa> empresas = context.Empresa.ToList();
                if (FiltroValido(filtroNomeFantasia))
                    empresas = empresas.Where(e => e.NomeFantasia == filtroNomeFantasia).ToList();

                if (FiltroValido(filtroCNPJ))
                    empresas = empresas.Where(e => e.CNPJ == filtroCNPJ).ToList();

                if (FiltroValido(filtroUF))
                    empresas = empresas.Where(e => e.UF == filtroUF).ToList();

                return empresas;
            }
        }

        public static Empresa GetById(int? Id)
        {
            using (var context = new FornecedoresContext())
            {
                return context.Empresa.Find(Id);
            }
        }

        private static bool FiltroValido(string filtro)
        {
            return filtro != null && filtro != "";
        }
    }
}
