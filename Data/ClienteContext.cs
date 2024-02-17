using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Orçamento.Data
{
    public class ClienteContext : DbContext
    {
        public DbSet<Clientes> Cliente { get; set; }
    }
}
