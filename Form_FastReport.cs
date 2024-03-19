using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.Design;
using Newtonsoft.Json;
using FastReport;
using Orçamento.FastReport;

namespace Orçamento
{
    public partial class Form_FastReport : Form
    {
        public Form_FastReport()
        {
            InitializeComponent();
        }
        private void Form_FastReport_Load(object sender, EventArgs e)
        {
            Report report = new Report();
            var responsemodel = JsonConvert.DeserializeObject<RespondeDataModel>(File.ReadAllText("C:\\Users\\Gabriel\\Desktop\\Projeto orçamento C#\\Orçamento\\Data.json"));
            var data = new List<RespondeDataModel> { responsemodel };
            report.RegisterData(data, "ResponseData");
            report.Design();

        }
    }
}
