using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Windows.Forms;
using Orçamento.Data;

namespace Orçamento.Function
{
    public class VerificaCPF
    {
        public bool VerificaCpfDB(string documento)
        {
            using (var dbContext = new DbConnect())
            {
                var existecliente = dbContext.clientes
                    .Any(c => c.documento == documento);
                return existecliente;
            }
        }
        public int idlinha;
    }
}
