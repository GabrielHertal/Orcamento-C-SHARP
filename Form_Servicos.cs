using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_Servicos : Form
    {
        public Form_Servicos()
        {
            InitializeComponent();
        }
        BancodeDados bancodedados = new BancodeDados();
        CarregarDados carregarDados = new CarregarDados();
        Formatar formatar = new Formatar();
        private string _valor;
        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt_valor.Text.Contains(","));
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txt_valor_Leave(object sender, EventArgs e)
        {
            _valor = txt_valor.Text.Replace("R$", "");
            txt_valor.Text = string.Format("{0:C}", Convert.ToDouble(_valor));
        }
        //função preenche moeda textbox
        private void txt_valor_KeyUp(object sender, KeyEventArgs e)
        {
            _valor = txt_valor.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (_valor.Length == 0)
            {
                txt_valor.Text = "0,00" + _valor;
            }
            if (_valor.Length == 1)
            {
                txt_valor.Text = "0,0" + _valor;
            }
            if (_valor.Length == 2)
            {
                txt_valor.Text = "0," + _valor;
            }
            else if (_valor.Length >= 3)
            {
                if (txt_valor.Text.StartsWith("0,"))
                {
                    txt_valor.Text = _valor.Insert(_valor.Length - 2, ",").Replace("0,", "");
                }
                else if (txt_valor.Text.Contains("00,"))
                {
                    txt_valor.Text = _valor.Insert(_valor.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    txt_valor.Text = _valor.Insert(_valor.Length - 2, ",");
                }
            }
            _valor = txt_valor.Text;
            txt_valor.Text = string.Format("{0:C}", Convert.ToDouble(_valor));
            txt_valor.Select(txt_valor.Text.Length, 0);
        }
        private void Form_Servicos_Load(object sender, EventArgs e)
        {
            carregarDados.PreencheListViewServicos(lv_servicos);
            WindowState = FormWindowState.Maximized;
        }
        private void btn_novo_Click(object sender, EventArgs e)
        {
            string servico = txt_servico.Text;
           try
           {
                decimal valorservico = decimal.Parse(txt_valor.Text.Replace("R$", "").Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                string descricao = txt_descricao.Text;

                if (servico == "")
                {
                    MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bancodedados.conectar();
                    string sql = $"INSERT INTO servicos (nome_servico, preco_padrao, descricao) VALUES ('{servico}', '{valorservico}', '{descricao}')";
                    bancodedados.executar(sql);
                    bancodedados.desconectar();
                    carregarDados.PreencheListViewServicos(lv_servicos);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido para o campo 'Valor do Serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if(lv_servicos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um serviço, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linha = lv_servicos.SelectedIndices[0];
            txt_servico.Text = lv_servicos.Items[linha].SubItems[1].Text;
            txt_valor.Text = lv_servicos.Items[linha].SubItems[2].Text;
            txt_descricao.Text = lv_servicos.Items[linha].SubItems[3].Text;
        }
    }
}
