using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.FastReport
{
    public partial class ResponseDataModelFastReport : Component
    {
        public ResponseDataModelFastReport()
        {
            InitializeComponent();
        }

        public ResponseDataModelFastReport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
