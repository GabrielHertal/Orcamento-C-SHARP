using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Contato { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public Cliente (int id, string nome, string documento, string contato, string rua, string bairro, string cidade, string uf, string cep)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Contato = contato;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
        }
    }
}
