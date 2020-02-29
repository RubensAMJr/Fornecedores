using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmpresaFK")]
        public Empresa Empresa { get; set; }

        public int EmpresaFK { get; set; }

        [Required]
        [Column("NOME")]

        public string Nome { get; set; }

        [Required]
        [Column("TIPO_PESSOA")]
        public int TipoPessoa { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("TELEFONE_COMERCIAL")]
        public string TelefoneComercial { get; set; }

        [Column("TELEFONE_RESIDENCIAL")]
        public string TelefoneResidencial { get; set; }

        [Column("TELEFONE_PESSOAL")]
        public string TelefonePessoal { get; set; }

        public Fornecedor()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
