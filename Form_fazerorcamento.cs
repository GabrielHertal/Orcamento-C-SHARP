using FastReport.Data;
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
    public partial class Form_fazerorcamento : Form
    {
        public Form_fazerorcamento()
        {
            InitializeComponent();
        }
        BancodeDados bancodedados = new BancodeDados();
        CarregarDados carregarDados = new CarregarDados();
        Formatar formatar = new Formatar();
        FormatarValor formatavalor = new FormatarValor();

        private decimal valortotaloriginal;
        private decimal descontototal;
        private decimal acrescimototal;
        private void Form_fazerorcamento_Load(object sender, EventArgs e)
        {
            carregarDados.PreencheComboBoxServicos(cbx_serviço);
            carregarDados.PreencheComboboxClientes(cbx_cliente);
        }
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            string servico = cbx_serviço.Text;
            string tamanho = txt_tamanho.Text;
            string valor = txt_total.Text;
            if (string.IsNullOrEmpty(servico) || string.IsNullOrEmpty(tamanho))
            {
                MessageBox.Show("Informe o serviço e o tamanho!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string sql = $"SELECT id_servicos, nome_servico, preco_padrao FROM servicos WHERE nome_servico = '{servico}' ORDER BY id_servicos";
            bancodedados.conectar();
            bancodedados.Consultar(sql);
            if (bancodedados.dados.Read())
            {
                string servicoId = bancodedados.dados["id_servicos"].ToString();
                string nomeServico = bancodedados.dados["nome_servico"].ToString();
                string precoPadrao = bancodedados.dados["preco_padrao"].ToString();
                bool servicoJaAdicionado = lv_servicos.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text == servicoId);
                if (servicoJaAdicionado)
                {
                    MessageBox.Show("Serviço já adicionado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ListViewItem novoItem = new ListViewItem(servicoId);
                    novoItem.SubItems.Add(nomeServico);
                    novoItem.SubItems.Add(tamanho);
                    lv_servicos.Items.Add(novoItem);
                    cbx_serviço.Text = "";
                    txt_tamanho.Text = "";
                    decimal preco;
                    decimal tamanhoDecimal;
                    if (decimal.TryParse(precoPadrao.Replace(".", "").Replace(",", "."), NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out preco) && decimal.TryParse(tamanho, out tamanhoDecimal))
                    {
                        decimal soma = preco * tamanhoDecimal;
                        decimal valorTotalAtual;

                        if (decimal.TryParse(valor.Replace("R$ ", "").Replace(".", ","), out valorTotalAtual))
                        {
                            valorTotalAtual += soma;
                            txt_total.Text = valorTotalAtual.ToString();
                            valortotaloriginal = valorTotalAtual;
                        }
                        else
                        {
                            MessageBox.Show("Valor total inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preço ou tamanho inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            bancodedados.desconectar();
        }
        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (lv_servicos.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecione um Serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult resposta = MessageBox.Show("Deseja realmente excluir este Serviço?", "Confirmação de exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                int linha = lv_servicos.SelectedIndices[0];
                int idservico = Convert.ToInt32(lv_servicos.Items[linha].SubItems[0].Text);
                decimal tamanhoServico;
                if (!decimal.TryParse(lv_servicos.Items[linha].SubItems[2].Text, out tamanhoServico))
                {
                    MessageBox.Show("Tamanho do serviço inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal valorRemovido = ObterValorServico(idservico) * tamanhoServico;
                lv_servicos.Items.RemoveAt(linha);
                AtualizarTotal(valorRemovido);
                MessageBox.Show("Serviço removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txt_desconto_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txt_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_desconto_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_desconto_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void txt_acrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_acrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_acrescimo_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatavalor.TratarKeyPress(sender, e);
        }
        private void txt_total_KeyUp(object sender, KeyEventArgs e)
        {
            formatavalor.TratarKeyUp(sender, e);
        }
        private void txt_total_Leave(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
        }
        private void txt_total_TextChanged(object sender, EventArgs e)
        {
            formatavalor.TratarLeave(sender, e);
        }
        private void cbx_cliente_TextChanged(object sender, EventArgs e)
        {
        }
        private void cbx_serviço_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txt_desconto_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void txt_acrescimo_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void AtualizarTotalComDescontoOuAcrescimo()
        {
            decimal desconto, acrescimo;

            if (decimal.TryParse(txt_desconto.Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"), out desconto) &&
                decimal.TryParse(txt_acrescimo.Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"), out acrescimo))
            {
                decimal total = valortotaloriginal - desconto + acrescimo;
                txt_total.Text = total.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                descontototal = desconto;
                acrescimototal = acrescimo;
            }
            else
            {
                MessageBox.Show("Desconto ou Acrescimo inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal ObterValorServico(int idServico)
        {
            string sql = $"SELECT preco_padrao FROM servicos WHERE id_servicos = {idServico}";
            bancodedados.conectar();
            bancodedados.Consultar(sql);
            if (bancodedados.dados.Read())
            {
                decimal valorServico;
                if (decimal.TryParse(bancodedados.dados["preco_padrao"].ToString(), out valorServico))
                {
                    bancodedados.desconectar();
                    return valorServico;
                }
            }
            bancodedados.desconectar();
            return 0;
        }
        private void AtualizarTotal(decimal valorRemovido)
        {
            decimal valorAtual = ObterValorTotal();
            if (valorRemovido <= valortotaloriginal)
            {
                valorAtual -= valorRemovido;
            }
            else
            {
                valorAtual = 0;
            }
            txt_total.Text = valorAtual.ToString("C");
        }
        private decimal ObterValorTotal()
        {
            decimal valorTotal;
            if (decimal.TryParse(txt_total.Text.Replace("R$", ""), out valorTotal))
            {
                return valorTotal;
            }
            return 0;
        }

        private void btn_finalizaorcamento_Click(object sender, EventArgs e)
        {

        }
    }
}
