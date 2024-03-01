using System;
using System.Collections.Generic;
using System.Globalization;
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
        public decimal ValorTotal => PrecoPadrao * Tamanho;
        public Servico(int id, string nome, string tamanhostring, decimal precoPadrao)
        {
            Id = id;
            Nome = nome;
            Tamanho = decimal.Parse(tamanhostring, CultureInfo.InvariantCulture);
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
