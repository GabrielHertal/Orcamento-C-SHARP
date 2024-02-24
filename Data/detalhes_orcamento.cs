using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    public class detalhes_orcamento
    {
        [Key]
        public int id_orcamento { get; set; }
        
        [ForeignKey("clientes")]
        public int fk_id_cliente { get; set; }
        public clientes clientes { get; set; }
        
        [ForeignKey("orcamento")]
        public int fk_orcamento { get; set; }
        public orcamento orcamento { get; set; }
       
        [ForeignKey("servicos")]
        public int fk_id_servico { get; set; }
        public servicos servicos { get; set; }

        [ForeignKey("item_orcamento")]
        public int fk_item_orcamento { get; set; }
        public item_orcamento item_orcamento { get; set; }
    }
}
