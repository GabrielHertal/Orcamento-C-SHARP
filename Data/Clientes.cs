using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    public class Clientes
    {
        public int id_clientes { get; set; }
        public string nome_cliente { get; set; }
        public string documento { get; set; }
        public string contato { get; set; }
        public int ativo { get; set; }
    }
}
