using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Tamanho { get; set; }
        public decimal PrecoPadrao { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal ValorTotal => Tamanho * PrecoPadrao;
        public Servico(int id, string nome, decimal tamanho, decimal precoPadrao)
        {
            Id = id;
            Nome = nome;
            Tamanho = tamanho;
            PrecoPadrao = precoPadrao;
        }
        public void AtualizarTotal()
        {
            decimal total = ValorTotal - Desconto + Acrescimo;
            Total = total < 0 ? 0 : total;
        }
        public decimal Total { get; private set; }
    }
}
