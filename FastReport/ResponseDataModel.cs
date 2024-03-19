using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.FastReport
{
    public partial class ResponseDataModel : Component
    {
        public ResponseDataModel()
        {
            InitializeComponent();
        }

        public ResponseDataModel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
