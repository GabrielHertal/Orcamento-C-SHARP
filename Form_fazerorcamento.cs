using FastReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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

        public decimal valortotaloriginal;
        public decimal descontototal;
        public decimal acrescimototal;
        private List<Servico> listaServicos = new List<Servico>();

        private void Form_fazerorcamento_Load(object sender, EventArgs e)
        {
            carregarDados.PreencheComboBoxServicos(cbx_serviço);
            carregarDados.PreencheComboboxClientes(cbx_cliente);
        }
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            string servico = cbx_serviço.Text;
            string tamanho = txt_tamanho.Text;
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
                int servicoId = Convert.ToInt32(bancodedados.dados["id_servicos"]);
                string nomeServico = bancodedados.dados["nome_servico"].ToString();
                decimal precoPadrao = Convert.ToDecimal(bancodedados.dados["preco_padrao"]);

                bool servicoJaAdicionado = listaServicos.Any(item => item.Id == servicoId);

                if (servicoJaAdicionado)
                {
                    MessageBox.Show("Serviço já adicionado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Servico novoServico = new Servico(servicoId, nomeServico, Convert.ToInt32(Convert.ToDecimal(tamanho)), precoPadrao);
                    using (Form_ValoresServicos valoresservicos = new Form_ValoresServicos())
                    {
                        valoresservicos.ValorOriginal = novoServico.ValorTotal;
                        DialogResult result = valoresservicos.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            novoServico.Desconto = valoresservicos.Desconto;
                            novoServico.Acrescimo = valoresservicos.Acrescimo;
                            novoServico.AtualizarTotal();
                            valoresservicos.ValoresConfirmados += AtualizarTextBoxes;
                            valoresservicos.ShowDialog();
                            valoresservicos.ValoresConfirmados -= AtualizarTextBoxes;
                            listaServicos.Add(novoServico);
                            ListViewItem novoItem = new ListViewItem(novoServico.Id.ToString());
                            novoItem.SubItems.Add(novoServico.Nome);
                            novoItem.SubItems.Add(novoServico.Tamanho.ToString());
                            novoItem.SubItems.Add(novoServico.Desconto.ToString("C2"));
                            novoItem.SubItems.Add(novoServico.Acrescimo.ToString("C2"));
                            novoItem.SubItems.Add(novoServico.Total.ToString("C2"));
                            lv_servicos.Items.Add(novoItem);
                            AtualizarTotais();
                        }
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
                CalcularTotaisListView(); 
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
        private void AtualizarTotalGeral()
        {
            decimal totalgeral = 0;
            foreach (Servico servico in listaServicos)
            {
                totalgeral += servico.Total;
            }
            txt_total.Text = (totalgeral - descontototal + acrescimototal).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
        }
        private void ExibirFormValoresServicos(Servico servico)
        {
            using (Form_ValoresServicos formValores = new Form_ValoresServicos())
            {
                DialogResult result = formValores.ShowDialog();
                if (result == DialogResult.OK)
                {
                    servico.Desconto = formValores.Desconto;
                    servico.Acrescimo = formValores.Acrescimo;
                    servico.AtualizarTotal();
                }
            }
        }
        private void AtualizarTextBoxes(decimal valorOriginal, decimal desconto, decimal acrescimo)
        {
            txt_total.Text = valorOriginal.ToString("C2");
            txt_desconto.Text = desconto.ToString("C2");
            txt_acrescimo.Text = acrescimo.ToString("C2");
            AtualizarTotalComDescontoOuAcrescimo();
        }
        private void CalcularTotaisListView()
        {
            decimal totalGeral = 0;

            foreach (ListViewItem item in lv_servicos.Items)
            {
                decimal total;

                if (decimal.TryParse(item.SubItems[5].Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out total))
                {
                    totalGeral += total;
                }
            }
            txt_total.Text = totalGeral.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
        }
        private void AtualizarTotais()
        {
            CalcularTotaisListView();
        }
    }
}
