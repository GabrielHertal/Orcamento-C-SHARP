using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    [Table("detalhes_orcamento")]
    public class detalhes_orcamento
    {
        [Key]
        public int id_detalhe { get; set; }
        
        [ForeignKey("clientes")]
        public int fk_id_cliente { get; set; }
        public clientes clientes { get; set; }
        
        [ForeignKey("orcamentos")]
        public int fk_orcamento { get; set; }
        public orcamentos orcamentos { get; set; }
       
        [ForeignKey("servicos")]
        public int fk_id_servico { get; set; }
        public servicos servicos { get; set; }

        [ForeignKey("itens_orcamento")]
        public int fk_id_item_orcamento { get; set; }
        public itens_orcamento itens_orcamento { get; set; }
    }
}
