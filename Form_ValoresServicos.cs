using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_ValoresServicos : Form
    {
        public Form_ValoresServicos()
        {
            InitializeComponent();
        }
        FormatarValor formatavalor = new FormatarValor();
        Formatar formata = new Formatar();
        public decimal descontototal;
        public decimal acrescimototal;
        public event Action<decimal, decimal, decimal> ValoresConfirmados;
        private void Form_ValoresServicos_Load(object sender, EventArgs e)
        {
        }
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string valororiginal = txt_valororiginal.Text.Replace("R$", "");
            string acrescimo = txt_acrescimo.Text.Replace("R$", "");
            string desconto = txt_desconto.Text.Replace("R$", "");
            string totalfinal = txt_totalfinal.Text.Replace("R$", "");
            ValorOriginal = Convert.ToDecimal(valororiginal);
            Acrescimo = Convert.ToDecimal(acrescimo);
            Desconto = Convert.ToDecimal(desconto);
            TotalFinal = Convert.ToDecimal(totalfinal);
            if (ValoresConfirmados != null)
            {
                ValoresConfirmados.Invoke(ValorOriginal, Desconto, Acrescimo);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private decimal valorOriginal;
        private decimal acrescimo;
        private decimal desconto;
        private decimal totalFinal;
        private void txt_acrescimo_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
        }
        private void txt_desconto_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
        }
        private void txt_totalfinal_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
        }
        private void txt_acrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_desconto_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_totalfinal_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_acrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_totalfinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_acrescimo_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void txt_desconto_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void txt_totalfinal_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalComDescontoOuAcrescimo();
        }
        public decimal ValorOriginal
        {
            get { return valorOriginal; }
            set { valorOriginal = value; txt_valororiginal.Text = value.ToString("C2"); }
        }
        public decimal Acrescimo
        {
            get { return acrescimo; }
            set { acrescimo = value; txt_acrescimo.Text = value.ToString("C2"); }
        }
        public decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; txt_desconto.Text = value.ToString("C2"); }
        }
        public decimal TotalFinal
        {
            get { return totalFinal; }
            set { totalFinal = value; txt_totalfinal.Text = value.ToString("C2"); }
        }
        private void AtualizarTotalComDescontoOuAcrescimo()
        {
            decimal desconto, acrescimo;
            if (decimal.TryParse(txt_desconto.Text.Replace("R$", ""), NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"), out desconto) &&
                decimal.TryParse(txt_acrescimo.Text.Replace("R$", ""), NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"), out acrescimo))
            {
                decimal total = ValorOriginal - desconto + acrescimo;
                txt_totalfinal.Text = total.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                descontototal = desconto;
                acrescimototal = acrescimo;
            }
            else
            {
                MessageBox.Show("Desconto ou Acrescimo inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
