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
using FirebirdSql.Data.FirebirdClient;

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
        //função preenche moeda textbox
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
            string valorTexto = txt_valor.Text.Replace("R$", "").Replace(",", ".");
            decimal valorservico = decimal.Parse(valorTexto, CultureInfo.InvariantCulture);
            string descricao = txt_descricao.Text;
            if (servico == "")
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bancodedados.conectar();
                string valorFormatado = valorservico.ToString(CultureInfo.InvariantCulture);
                string sql = $"INSERT INTO servicos (nome_servico, preco_padrao, descricao) VALUES ('{servico}', '{valorFormatado}', '{descricao}')";
                bancodedados.executar(sql);
                bancodedados.desconectar();
                carregarDados.PreencheListViewServicos(lv_servicos);
                txt_descricao.Text = "";
                txt_servico.Text = "";
                txt_valor.Text = "R$ 0,00";
            }
        }
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (lv_servicos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um serviço, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linha = lv_servicos.SelectedIndices[0];
            txt_servico.Text = lv_servicos.Items[linha].SubItems[1].Text;
            txt_valor.Text = lv_servicos.Items[linha].SubItems[2].Text;
            txt_descricao.Text = lv_servicos.Items[linha].SubItems[3].Text;
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este serviço?!", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                return;
            }
            else if (lv_servicos.SelectedItems.Count > 0)
            {
                int itemselecionado = lv_servicos.SelectedItems[0].Index;
                int indiceselecionado = Convert.ToInt32(lv_servicos.Items[itemselecionado].Text);
                bancodedados.conectar();
                string sql = $"UPDATE servicos SET ativo = 2 WHERE id_servicos = @ID";
                FbCommand comando = new FbCommand(sql, bancodedados.conexao);
                comando.Parameters.AddWithValue("@ID", indiceselecionado);
                comando.ExecuteNonQuery();
                bancodedados.desconectar();
                lv_servicos.Items.RemoveAt(itemselecionado);
            }
            else
            {
                MessageBox.Show("Selecione um Serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string servico = txt_servico.Text;
            string valorTexto = txt_valor.Text.Replace("R$", "").Replace(",", ".");
            decimal valorservico = decimal.Parse(valorTexto, CultureInfo.InvariantCulture);
            string descricao = txt_descricao.Text;
            if (servico == "")
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bancodedados.conectar();
                int itemselecionado = lv_servicos.SelectedItems[0].Index;
                int indiceselecionado = Convert.ToInt32(lv_servicos.Items[itemselecionado].Text);
                string valortexto = valorservico.ToString(CultureInfo.InvariantCulture);
                string sql = $"UPDATE servicos SET nome_servico = '{servico}', preco_padrao = '{valortexto}', descricao = '{descricao}' WHERE id_servicos = @ID";
                FbCommand comando = new FbCommand(sql, bancodedados.conexao);
                comando.Parameters.AddWithValue("@ID", indiceselecionado);
                comando.ExecuteNonQuery();
                bancodedados.desconectar();
                carregarDados.PreencheListViewServicos(lv_servicos);
                txt_descricao.Text = "";
                txt_servico.Text = "";
                txt_valor.Text = "R$ 0,00";
            }
        }

        private void txt_valor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}