using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    public class orcamentos
    {
        [Key]
        public int id_orcamento { get; set; }
        public string nome_orcamento { get; set; }
        public string localizacao { get; set; }
        public string observacao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_conclusao  { get; set; }

        [ForeignKey("clientes")]
        public int fkid_cliente { get; set; }
        public clientes clientes { get; set; }
    }
}
