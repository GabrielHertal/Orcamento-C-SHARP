using Orçamento.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Function
{
    public class PreencheGridView
    {
        public void Preencher(DataGridView dataGridView)
        {
            using (var dbContext = new DbConnect())
            {
                var clientes = dbContext.clientes.OrderBy(c => c.id_cliente).ToList();
                dataGridView.DataSource = clientes;
            }
        }
        public void PreencherServico (DataGridView dataGridView)
        {
            using (var dbcontext = new DbConnect())
            {
                var servicos = dbcontext.servicos.Where(s => s.ativo == 1).OrderBy(s => s.id_servicos).ToList();
                dataGridView.DataSource = servicos;
            }
        }
    }
}
