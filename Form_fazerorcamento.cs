using FastReport.Barcode;
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
            carregarDados.PreencheListVieOrcamentos(lv_orcamentos);
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
                            carregarDados.PreencheListVieOrcamentos(lv_orcamentos);
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
            DateTime i_data = dtp_inicio.Value;
            DateTime f_data = dtp_conclusao.Value;
            string localizacao = txt_localização.Text;
            string observacao = txt_observações.Text;
            string total_servicos = txt_total.Text.Replace("R$", "").Replace(",", ".");
            string acrescimototal = txt_acrescimo.Text.Replace("R$", "").Replace(",", ".");
            string descontototal = txt_desconto.Text.Replace("R$", "").Replace(",", ".");
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
            string i_data_formatada = i_data.ToString("yyyy-MM-dd");
            string f_data_formatada = f_data.ToString("yyyy-MM-dd"); //ver para fazer de uma forma melhor

            string sqlinsertorcamento = $"INSERT INTO orcamentos (nome_orcamento, localizacao, observacao ,data_inicio, data_conclusao, fkid_cliente) " +
                               $"VALUES ('{nomeorcamento}', '{localizacao}', '{observacao}' ,'{i_data_formatada}', '{f_data_formatada}', '{id_cliente}')";

            bancodedados.executar(sqlinsertorcamento);
            bancodedados.desconectar();
            bancodedados.conectar();
            string sqlidorcamento = $"SELECT GEN_ID(gen_orcamento, 0) FROM RDB$DATABASE";
            bancodedados.Consultar(sqlidorcamento);
            int id_orcamento = 0;
            if (bancodedados.dados.Read())
            {
                id_orcamento = Convert.ToInt32(bancodedados.dados[0].ToString());
                bancodedados.desconectar();
            }
            else
            {
                MessageBox.Show("Erro ao inserir orcamento!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bancodedados.desconectar();

            foreach (ListViewItem item in lv_servicos.Items)
            {
                int id_servico = Convert.ToInt32(item.SubItems[0].Text);
                decimal tamanho = Convert.ToDecimal(item.SubItems[2].Text, CultureInfo.GetCultureInfo("pt-BR"));
                string desconto_unit = item.SubItems[3].Text.Replace("R$", "").Replace(",", ".");
                string acrescimo_unit = item.SubItems[4].Text.Replace("R$", "").Replace(",", ".");
                string total_unit = item.SubItems[5].Text.Replace("R$", "").Replace(",", ".");
                try
                {
                    bancodedados.conectar();
                    string sqlinsertitemorcamento = $"INSERT INTO itens_orcamento(id_item_orcamento, fk_id_orcamento ,descricao, tamanho, total_servicos, desconto_total, acrescimo_total, desconto_unit, acrescimo_unit, total_unit, fk_id_servico) " +
                        $"VALUES (null, '{id_orcamento}','{observacao}', '{tamanho}', '{total_servicos}', '{descontototal}', '{acrescimototal}', '{desconto_unit}', '{acrescimo_unit}', '{total_unit}', '{id_servico}')";
                    bancodedados.executar(sqlinsertitemorcamento);
                    string sqlitemorcamento = $"SELECT GEN_ID(gen_item_orcamento, 0) FROM RDB$DATABASE";
                    bancodedados.Consultar(sqlitemorcamento);
                    int id_item_orcamento = 0;
                    if (bancodedados.dados.Read())
                    {
                        id_item_orcamento = Convert.ToInt32(bancodedados.dados[0].ToString());
                    }
                    bancodedados.desconectar();
                    bancodedados.conectar();
                    string sqlInsertDetalhesOrcamento = $"INSERT INTO detalhes_orcamento(fk_id_cliente, fk_orcamento, fk_id_servico, fk_id_item_orcamento) " +
                                  $"VALUES ('{id_cliente}', '{id_orcamento}', '{id_servico}', '{id_item_orcamento}')";
                    bancodedados.executar(sqlInsertDetalhesOrcamento);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inserir item orcamento: {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bancodedados.desconectar();
                    txt_nomeorcamento.Text = "";
                    txt_localização.Text = "";
                    txt_observações.Text = "";
                    lv_servicos.Items.Clear();
                    cbx_cliente.Text = "";
                    txt_desconto.Text = "R$ 0,00";
                    txt_acrescimo.Text = "R$ 0,00";
                    txt_total.Text = "R$ 0,00";
                    carregarDados.PreencheListVieOrcamentos(lv_orcamentos);
                }
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
                if ((decimal.TryParse(item.SubItems[5].Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out total)) &&
                   (decimal.TryParse(item.SubItems[4].Text.Replace("R$", "").Replace(".", ","), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-br"), out acrescimo) &&
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

        private void btn_editaorcamento_Click(object sender, EventArgs e)
        {
            if (lv_orcamentos.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecione um orcamento!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int id_orcamento = Convert.ToInt32(lv_orcamentos.Items[lv_orcamentos.SelectedIndices[0]].SubItems[0].Text);
            lv_servicos.Items.Clear();
            string sqlitens = $"SELECT itens_orcamento.* ,servicos.nome_servico FROM itens_orcamento JOIN servicos ON itens_orcamento.fk_id_servico = servicos.id_servicos WHERE itens_orcamento.fk_id_orcamento = {id_orcamento}";
            bancodedados.conectar();
            bancodedados.Consultar(sqlitens);
            while (bancodedados.dados.Read())
            {
                int id_servico = Convert.ToInt32(bancodedados.dados["fk_id_servico"]);
                string nomeServico = bancodedados.dados["nome_servico"].ToString();
                decimal tamanhoServico = Convert.ToDecimal(bancodedados.dados["tamanho"]);
                decimal desconto_unit = Convert.ToDecimal(bancodedados.dados["desconto_unit"]);
                decimal acrescimo_unit = Convert.ToDecimal(bancodedados.dados["acrescimo_unit"]);
                decimal total_unit = Convert.ToDecimal(bancodedados.dados["total_unit"]);
                ListViewItem item = new ListViewItem(id_servico.ToString());
                item.SubItems.Add(nomeServico);
                item.SubItems.Add(tamanhoServico.ToString());
                item.SubItems.Add(desconto_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                item.SubItems.Add(acrescimo_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                item.SubItems.Add(total_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                lv_servicos.Items.Add(item);
                CalcularTotaisListView();
            }
            bancodedados.desconectar();
            bancodedados.conectar();
            string sqlorcamento = $"SELECT orcamentos.*, clientes.nome FROM orcamentos JOIN clientes on clientes.id_cliente = orcamentos.fkid_cliente WHERE id_orcamento = {id_orcamento}";
            bancodedados.Consultar(sqlorcamento);
            if (bancodedados.dados.Read())
            {
                txt_nomeorcamento.Text = bancodedados.dados["nome_orcamento"].ToString();
                dtp_inicio.Text = bancodedados.dados["data_inicio"].ToString();
                dtp_conclusao.Text = bancodedados.dados["data_conclusao"].ToString();
                txt_observações.Text = bancodedados.dados["observacao"].ToString();
                txt_localização.Text = bancodedados.dados["localizacao"].ToString();
                cbx_cliente.SelectedItem = bancodedados.dados["nome"].ToString();
            }
            bancodedados.desconectar();
        }

        private void btn_atualizaorcamento_Click(object sender, EventArgs e)
        {

        }
    }
}