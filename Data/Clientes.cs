using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    
    public class clientes
    {
        [Key]
        public int id_cliente { get; set; }
        public string nome{ get; set; }
        public string documento { get; set; }
        public string contato { get; set; }
        public int ativo { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
    }
}
