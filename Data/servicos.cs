using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    public class servicos
    {
        [Key]
        public int id_servicos  { get; set; }
        public string nome_servicos { get; set; }
        public decimal preco_padrao { get; set; }
        public string descricao { get; set; }
        public int ativo { get; set; }
    }
}
