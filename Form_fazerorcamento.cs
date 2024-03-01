using Microsoft.EntityFrameworkCore;
using Orçamento.Data;
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
        CarregarDados carregarDados = new CarregarDados();
        FormatarValor formatavalor = new FormatarValor();
        public decimal valortotaloriginal;
        public decimal descontototal;
        public decimal acrescimototal;
        private List<Servico> listaServicos = new List<Servico>();
        private void Form_fazerorcamento_Load(object sender, EventArgs e)
        {
            carregarDados.PreencheComboBoxServicos(cbx_serviço);
            carregarDados.PreencheComboBoxClientes(cbx_cliente);
            carregarDados.PreencheListViewOrcamentos(lv_orcamentos);
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
            using (var dbContext = new DbConnect())
            {
                var servicoSelecionado = dbContext.servicos.FirstOrDefault(s => s.nome_servico == servico);
                if (servicoSelecionado != null)
                {
                    if (ServicoJaAdicionado(servico))
                    {
                        MessageBox.Show("Este serviço já foi adicionado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    decimal precoPadrao = servicoSelecionado.preco_padrao;
                    Servico novoServico = new Servico(servicoSelecionado.id_servicos, servicoSelecionado.nome_servico, tamanho, precoPadrao);
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
                            carregarDados.PreencheListViewOrcamentos(lv_orcamentos);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O serviço selecionado não existe no banco de dados!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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
            if (editar == true)
            {
                MessageBox.Show("Orçamento já criado, para Salvar as alteração clique em Atualizar Orçamento!", "AVISO", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                return;
            }
            string nomeorcamento = txt_nomeorcamento.Text;
            string cliente = cbx_cliente.Text;
            DateTime i_data = dtp_inicio.Value.ToUniversalTime();
            DateTime f_data = dtp_conclusao.Value.ToUniversalTime();
            string localizacao = txt_localização.Text;
            string observacao = txt_observações.Text;
            if (string.IsNullOrEmpty(nomeorcamento) || string.IsNullOrEmpty(cliente) || lv_servicos.Items.Count == 0)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                using (var dbContext = new DbConnect())
                {
                    var clienteSelecionado = dbContext.clientes.FirstOrDefault(c => c.nome == cliente);
                    if (clienteSelecionado == null)
                    {
                        MessageBox.Show("Cliente selecionado não existe no banco de dados!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int id_cliente = clienteSelecionado.id_cliente;
                    var novoOrcamento = new orcamentos
                    {
                        nome_orcamento = nomeorcamento,
                        localizacao = localizacao,
                        observacao = observacao,
                        data_inicio = i_data,
                        data_conclusao = f_data,
                        fkid_cliente = id_cliente
                    };
                    dbContext.orcamentos.Add(novoOrcamento);
                    dbContext.SaveChanges();
                    int id_orcamento = novoOrcamento.id_orcamento;
                    foreach (ListViewItem item in lv_servicos.Items)
                    {
                        int id_servico = Convert.ToInt32(item.SubItems[0].Text);
                        var servico = dbContext.servicos.FirstOrDefault(s => s.id_servicos == id_servico);
                        string descricaoServico = servico != null ? servico.descricao : "Descrição do serviço não encontrada";

                        int _id_servico = Convert.ToInt32(item.SubItems[0].Text);
                        decimal tamanho = Convert.ToDecimal(item.SubItems[2].Text, CultureInfo.GetCultureInfo("pt-BR"));
                        decimal desconto_unit = Convert.ToDecimal(item.SubItems[3].Text.Replace("R$", ""), CultureInfo.GetCultureInfo("pt-BR"));
                        decimal acrescimo_unit = Convert.ToDecimal(item.SubItems[4].Text.Replace("R$", ""), CultureInfo.GetCultureInfo("pt-BR"));
                        decimal total_unit = Convert.ToDecimal(item.SubItems[5].Text.Replace("R$", ""), CultureInfo.GetCultureInfo("pt-BR"));
                        var novoItemOrcamento = new itens_orcamento
                        {
                            descricao = descricaoServico, 
                            tamanho = tamanho,
                            total_servicos = total_unit,
                            desconto_total = Convert.ToDecimal(txt_desconto.Text.Replace("R$", ""), CultureInfo.GetCultureInfo("pt-BR")),
                            acrescimo_total = Convert.ToDecimal(txt_acrescimo.Text.Replace("R$", ""), CultureInfo.GetCultureInfo("pt-BR")),
                            desconto_unit = desconto_unit,
                            acrescimo_unit = acrescimo_unit,
                            total_unit = total_unit,
                            fk_id_servico = _id_servico,
                            fk_id_orcamento = id_orcamento
                        };
                        dbContext.itens_Orcamentos.Add(novoItemOrcamento);
                        dbContext.SaveChanges();
                        var _detalhesOrcamento = new detalhes_orcamento
                        {
                            fk_id_cliente = id_cliente,
                            fk_orcamento = id_orcamento,
                            fk_id_servico = _id_servico,
                            fk_id_item_orcamento = novoItemOrcamento.id_item_orcamento
                        };
                        dbContext.detalhesOrcamento.Add(_detalhesOrcamento);
                        dbContext.SaveChanges();
                    }
                    MessageBox.Show("Orçamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_nomeorcamento.Text = "";
                    txt_localização.Text = "";
                    txt_observações.Text = "";
                    lv_servicos.Items.Clear();
                    cbx_cliente.Text = "";
                    txt_desconto.Text = "R$ 0,00";
                    txt_acrescimo.Text = "R$ 0,00";
                    txt_total.Text = "R$ 0,00";
                    carregarDados.PreencheListViewOrcamentos(lv_orcamentos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar orçamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public int id_orcamento;
        private void btn_editaorcamento_Click(object sender, EventArgs e)
        {
            editar = true;
            if (lv_orcamentos.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecione um orcamento!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            id_orcamento = Convert.ToInt32(lv_orcamentos.Items[lv_orcamentos.SelectedIndices[0]].SubItems[0].Text);
            lv_servicos.Items.Clear();
            using (var dbContext = new DbConnect())
            {
                var itensOrcamento = dbContext.itens_Orcamentos
                    .Where(io => io.fk_id_orcamento == id_orcamento)
                    .Include(io => io.servicos)
                    .ToList();
                foreach (var itemOrcamento in itensOrcamento)
                {
                    int id_servico = itemOrcamento.fk_id_servico;
                    string nomeServico = itemOrcamento.servicos.nome_servico;
                    decimal tamanhoServico = itemOrcamento.tamanho;
                    decimal desconto_unit = itemOrcamento.desconto_unit;
                    decimal acrescimo_unit = itemOrcamento.acrescimo_unit;
                    decimal total_unit = itemOrcamento.total_unit;
                    ListViewItem item = new ListViewItem(id_servico.ToString());
                    item.SubItems.Add(nomeServico);
                    item.SubItems.Add(tamanhoServico.ToString());
                    item.SubItems.Add(desconto_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                    item.SubItems.Add(acrescimo_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                    item.SubItems.Add(total_unit.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
                    lv_servicos.Items.Add(item);
                    CalcularTotaisListView();
                }
                var orcamento = dbContext.orcamentos
                    .Where(o => o.id_orcamento == id_orcamento)
                    .Include(o => o.clientes)
                    .FirstOrDefault();
                if (orcamento != null)
                {
                    txt_nomeorcamento.Text = orcamento.nome_orcamento;
                    dtp_inicio.Value = orcamento.data_inicio;
                    dtp_conclusao.Value = orcamento.data_conclusao;
                    txt_observações.Text = orcamento.observacao;
                    txt_localização.Text = orcamento.localizacao;
                    cbx_cliente.SelectedItem = orcamento.clientes.nome;
                }
            }
        }
        public bool editar = false;
        private void btn_atualizaorcamento_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                MessageBox.Show("Selecione um orcamento e clique em Editar Orçamento!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string nomeorcamento = txt_nomeorcamento.Text;
            string cliente = cbx_cliente.Text;
            DateTime i_data = dtp_inicio.Value.ToUniversalTime();
            DateTime f_data = dtp_conclusao.Value.ToUniversalTime(); ;
            string localizacao = txt_localização.Text;
            string observacao = txt_observações.Text;
            int id_cliente = -1;
            using (var dbContext = new DbConnect())
            {
                var clienteSelecionado = dbContext.clientes.FirstOrDefault(c => c.nome == cliente);
                if (clienteSelecionado != null)
                {
                    id_cliente = clienteSelecionado.id_cliente;
                }
                var orcamento = dbContext.orcamentos.FirstOrDefault(o => o.id_orcamento == id_orcamento);
                if (orcamento != null)
                {
                    orcamento.nome_orcamento = nomeorcamento;
                    orcamento.localizacao = localizacao;
                    orcamento.observacao = observacao;
                    orcamento.data_inicio = i_data;
                    orcamento.data_conclusao = f_data;
                }
                dbContext.SaveChanges();
                foreach (ListViewItem item in lv_servicos.Items)
                {
                    int id_servico = Convert.ToInt32(item.SubItems[0].Text);
                    decimal tamanho = Convert.ToDecimal(item.SubItems[2].Text, CultureInfo.GetCultureInfo("pt-BR"));
                    decimal desconto_unit = Convert.ToDecimal(item.SubItems[3].Text.Replace("R$", ""));
                    decimal acrescimo_unit = Convert.ToDecimal(item.SubItems[4].Text.Replace("R$", ""));
                    decimal total_unit = Convert.ToDecimal(item.SubItems[5].Text.Replace("R$", ""));                    
                    var itemOrcamento = dbContext.itens_Orcamentos.FirstOrDefault(io => io.fk_id_orcamento == id_orcamento && io.fk_id_servico == id_servico);
                    if (itemOrcamento != null)
                    {
                        itemOrcamento.descricao = observacao;
                        itemOrcamento.tamanho = tamanho;
                        itemOrcamento.total_servicos = total_unit;
                        itemOrcamento.desconto_total = desconto_unit;
                        itemOrcamento.acrescimo_total = acrescimo_unit;
                        itemOrcamento.desconto_unit = desconto_unit;
                        itemOrcamento.acrescimo_unit = acrescimo_unit;
                        itemOrcamento.total_unit = total_unit;
                    }
                    dbContext.SaveChanges();
                }
            }
            txt_nomeorcamento.Text = "";
            txt_localização.Text = "";
            txt_observações.Text = "";
            lv_servicos.Items.Clear();
            cbx_cliente.Text = "";
            txt_desconto.Text = "R$ 0,00";
            txt_acrescimo.Text = "R$ 0,00";
            txt_total.Text = "R$ 0,00";
            carregarDados.PreencheListViewOrcamentos(lv_orcamentos);
            editar = false;
        }
    }
}