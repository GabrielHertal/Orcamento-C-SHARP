using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.FastReport
{
    public class RespondeDataModel
    {
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Content { get; set; }
        public List<OneMoreDataModel> Collection { get; set; }
    }
}
