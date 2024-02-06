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

                if (ServicoJaAdicionado(servico))
                {
                    MessageBox.Show("Este serviço já foi adicionado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
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
                            listaServicos.Add(novoServico);
                            ListViewItem novoItem = new ListViewItem(novoServico.Id.ToString());
                            novoItem.SubItems.Add(novoServico.Nome);
                            novoItem.SubItems.Add(novoServico.Tamanho.ToString());
                            novoItem.SubItems.Add(novoServico.Desconto.ToString("C2"));
                            novoItem.SubItems.Add(novoServico.Acrescimo.ToString("C2"));
                            novoItem.SubItems.Add(novoServico.Total.ToString("C2"));
                            lv_servicos.Items.Add(novoItem);
                            cbx_serviço.Text = "";
                            txt_tamanho.Text = "";
                            CalcularTotaisListView();
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
                lv_servicos.Items.RemoveAt(linha);
                CalcularTotaisListView();
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
        private void btn_finalizaorcamento_Click(object sender, EventArgs e)
        {
            string nomeorcamento = txt_nomeorcamento.Text;
            string cliente = cbx_cliente.Text;
            string i_data = dtp_inicio.Text;
            string f_data = dtp_conclusao.Text;
            string localizacao = txt_localização.Text;
            string observacao = txt_observações.Text;
            if (decimal.TryParse(txt_total.Text, NumberStyles.Currency, CultureInfo.CurrentUICulture, out decimal total_servicos));
            if (decimal.TryParse(txt_acrescimo.Text, NumberStyles.Currency, CultureInfo.CurrentUICulture, out decimal acrescimototal));
            if (decimal.TryParse(txt_desconto.Text, NumberStyles.Currency, CultureInfo.CurrentUICulture, out decimal descontototal));
            int id_cliente = -1;
                if (cbx_cliente.SelectedIndex == -1 || lv_servicos.Items.Count == 0)
                {
                    MessageBox.Show("Selecione um cliente ou adicione um serviço!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            bancodedados.conectar();
            string sql = $"SELECT id_cliente FROM clientes WHERE nome = '{cliente}' ORDER BY id_cliente";
            bancodedados.Consultar(sql);
                if (bancodedados.dados.Read())
                {
                    id_cliente = bancodedados.dados.GetInt32(0);
                }
            bancodedados.desconectar();

            bancodedados.conectar();
            string sqlinsertorcamento = $"INSERT INTO orcamentos (nome_orcamento, localizacao, observacao ,data_inicio, data_conclusao, fkid_cliente) " +
                               $"VALUES ('{nomeorcamento}', '{localizacao}', '{observacao}' ,'{i_data}', '{f_data}', '{id_cliente}')";

            bancodedados.executar(sqlinsertorcamento);
            bancodedados.desconectar();

            bancodedados.conectar();
            string sqlObterIdorcamento = "SELECT GEN_ID(GEN_ORCAMENTO, 0) AS id_orcamento FROM RDB$DATABASE";
            bancodedados.Consultar(sqlObterIdorcamento);
            int id_orcamento;
            if (bancodedados.dados.Read())
            {
                id_orcamento = Convert.ToInt32(bancodedados.dados["id_orcamento"].ToString());
            }
            bancodedados.desconectar();
            
            foreach (ListViewItem item in lv_servicos.Items)
            {
                id_orcamento = Convert.ToInt32(bancodedados.dados["id_orcamento"].ToString());
                int id_servico = Convert.ToInt32(item.SubItems[0].Text);
                decimal tamanho = Convert.ToInt32(item.SubItems[2].Text);
                decimal desconto_unit = Convert.ToDecimal(item.SubItems[3].Text.Replace("R$", "").Replace(".", ","), CultureInfo.GetCultureInfo("pt-BR"));
                decimal acrescimo_unit = Convert.ToDecimal(item.SubItems[4].Text.Replace("R$", "").Replace(".", ","), CultureInfo.GetCultureInfo("pt-BR"));
                decimal total_unit = Convert.ToDecimal(item.SubItems[5].Text.Replace("R$", "").Replace(".", ","), CultureInfo.GetCultureInfo("pt-BR"));
                bancodedados.conectar();
                string sqlinsertitemorcamento = $"INSERT INTO itens_orcamento(id_item_orcamento, fk_id_orcamento, descricao, tamanho, total_servicos, desconto_total, acrescimo_total, desconto_unit, acrescimo_unit, total_unit) " +
                    $"VALUES ('{id_servico}', '{id_orcamento}', '{observacao}', '{tamanho}', '{total_unit}', '{descontototal}', '{acrescimototal}', '{desconto_unit}', '{acrescimo_unit}', '{total_unit}')";
                bancodedados.executar(sqlinsertitemorcamento);
                bancodedados.desconectar();
                bancodedados.conectar();
                string sqlinsertdetalheorcamento = $"INSERT INTO detalhes_orcamento ()";

            }
        }
        private void CalcularTotaisListView()
        {
            decimal totalGeral = 0;
            decimal descontototal = 0;
            decimal acrescimototal = 0;
            foreach (ListViewItem item in lv_servicos.Items)
            {
                decimal total;
                decimal desconto;
                decimal acrescimo;
                if ((decimal.TryParse(item.SubItems[5].Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out total))&& 
                   (decimal.TryParse(item.SubItems[4].Text.Replace("R$", "").Replace(".",","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-br"), out acrescimo)&& 
                   (decimal.TryParse(item.SubItems[3].Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-br"), out desconto)))) 
                {
                    descontototal += desconto;
                    acrescimototal += acrescimo;
                    totalGeral += total;
                }
            }
            txt_acrescimo.Text = acrescimototal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            txt_desconto.Text = descontototal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            txt_total.Text = totalGeral.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
        }
        private bool ServicoJaAdicionado(string nomeServico)
        {
            return lv_servicos.Items.Cast<ListViewItem>().Any(item => item.SubItems[1].Text == nomeServico);
        }
    }
}