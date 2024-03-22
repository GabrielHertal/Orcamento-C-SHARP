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
using Orçamento.Data;
using Orçamento.Function;

namespace Orçamento
{
    public partial class Form_Servicos : Form
    {
        public Form_Servicos()
        {
            InitializeComponent();
        }
        CarregarDados carregarDados = new CarregarDados();
        Formatar formatar = new Formatar();
        PreencheGridView preenchergrid = new PreencheGridView();
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
            preenchergrid.PreencherServico(dataGridView1);
            WindowState = FormWindowState.Maximized;
        }
        private void btn_novo_Click(object sender, EventArgs e) 
        {
            if (editar == true)
            {
                MessageBox.Show("Serviço já adicionado, clique em Salvar para fazer as alterações!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;    
            }
            string servico = txt_servico.Text;
            string valorTexto = txt_valor.Text.Replace("R$", "");
            decimal valorservico;

            if (!decimal.TryParse(valorTexto, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out valorservico))
            {
                MessageBox.Show("Valor do serviço inválido!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string descricao = txt_descricao.Text;
            if (string.IsNullOrEmpty(servico))
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (var dbContext = new DbConnect())
            {
                var novoServico = new servicos
                {
                    nome_servico = servico,
                    preco_padrao = valorservico,
                    descricao = descricao
                };
                dbContext.servicos.Add(novoServico);
                dbContext.SaveChanges();
            }
            preenchergrid.PreencherServico(dataGridView1);
            txt_descricao.Text = "";
            txt_servico.Text = "";
            txt_valor.Text = "R$ 0,00";
        }
        public bool editar = false;
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            editar = true;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um serviço, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linha = dataGridView1.SelectedRows[0].Index;
            txt_servico.Text = dataGridView1.Rows[linha].Cells[1].Value.ToString();
            txt_valor.Text = "R$" + dataGridView1.Rows[linha].Cells[2].Value.ToString();
            txt_descricao.Text = dataGridView1.Rows[linha].Cells[3].Value.ToString();
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um Serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este serviço?!", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                int idServico = Convert.ToInt32(dataGridView1.SelectedRows[0].Index);
                using (var dbContext = new DbConnect())
                {
                    var servicoParaExcluir = dbContext.servicos.FirstOrDefault(s => s.id_servicos == idServico && s.ativo != 2);
                    if (servicoParaExcluir != null)
                    {
                        servicoParaExcluir.ativo = 2;
                        dbContext.SaveChanges();
                        preenchergrid.PreencherServico(dataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("Serviço não encontrado ou já está excluído!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                MessageBox.Show("Selecione um Serviço e clique em Editar Serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_descricao.Text = "";
                txt_servico.Text = "";
                txt_valor.Text = "R$ 0,00";
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um Serviço na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string servico = txt_servico.Text;
            string valorTexto = txt_valor.Text.Replace("R$", "").Replace(",", ".");
            decimal valorservico = decimal.Parse(valorTexto, CultureInfo.InvariantCulture);
            string descricao = txt_descricao.Text;
            if (string.IsNullOrWhiteSpace(servico))
            {
                MessageBox.Show("O campo 'Serviço' não pode estar vazio!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int idServicoSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            using (var dbContext = new DbConnect())
            {
                var servicoParaAtualizar = dbContext.servicos.FirstOrDefault(s => s.id_servicos == idServicoSelecionado);
                if (servicoParaAtualizar != null)
                {
                    servicoParaAtualizar.nome_servico = servico;
                    servicoParaAtualizar.preco_padrao = valorservico;
                    servicoParaAtualizar.descricao = descricao;
                    dbContext.SaveChanges();
                    preenchergrid.PreencherServico(dataGridView1);
                    txt_descricao.Text = "";
                    txt_servico.Text = "";
                    txt_valor.Text = "R$ 0,00";
                }
                else
                {
                    MessageBox.Show("O Serviço selecionado não foi encontrado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            editar = false; 
        }
        private void txt_valor_TextChanged(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}