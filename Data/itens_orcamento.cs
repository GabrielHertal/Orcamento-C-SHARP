﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    [Table("itens_orcamento")]
    public class itens_orcamento
    {
        [Key]
        public int id_item_orcamento { get; set; }
        public string descricao { get; set; }
        public decimal tamanho { get; set; }
        public decimal total_servicos { get; set; }
        public decimal desconto_total { get; set; }
        public decimal acrescimo_total { get; set; }
        public decimal desconto_unit { get; set; }
        public decimal acrescimo_unit { get; set; }
        public decimal total_unit { get; set; }

        [ForeignKey("orcamentos")]
        public int fk_id_orcamento { get; set; }
        public orcamentos orcamentos { get; set; }

        [ForeignKey("servicos")]
        public int fk_id_servico { get; set; }
        public servicos servicos { get; set; }
    }
}
