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
                var clientes = dbContext.clientes.ToList();
                dataGridView.DataSource = clientes;
            }
        }
    }
}
