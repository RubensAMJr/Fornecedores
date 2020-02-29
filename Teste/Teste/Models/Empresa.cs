using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        [Column("NOME_FANTASIA")]
        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }


    }
}
