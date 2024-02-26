using System;
using System.Windows.Forms;
using Orçamento.Data;

namespace Orçamento
{
    public class CarregarDados
    {
        public void PreencheListViewClientes(ListView listView)
        {
            try
            {
                using (var context = new DbConnect())
                {
                    listView.Items.Clear();
                    foreach (var cliente in context.clientes.Where(c => c.ativo == 1).OrderBy(c => c.id_cliente))
                    {
                        ListViewItem item = new ListViewItem(cliente.id_cliente.ToString());
                        item.SubItems.Add(cliente.nome);
                        item.SubItems.Add(cliente.documento);
                        item.SubItems.Add(cliente.contato);
                        listView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheListViewServicos(ListView listView)
        {
            try
            {
                using (var context = new DbConnect())
                {
                    listView.Items.Clear();
                    foreach (var servico in context.servicos.Where(s => s.ativo == 1).OrderBy(s => s.id_servicos))
                    {
                        ListViewItem item = new ListViewItem(servico.id_servicos.ToString());
                        item.SubItems.Add(servico.nome_servico);
                        item.SubItems.Add(servico.preco_padrao.ToString());
                        item.SubItems.Add(servico.descricao);
                        listView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheComboBoxServicos(ComboBox comboBox)
        {
            try
            {
                using (var context = new DbConnect())
                {
                    comboBox.Items.Clear();
                    foreach (var servico in context.servicos.Where(s => s.ativo == 1).OrderBy(s => s.id_servicos))
                    {
                        comboBox.Items.Add(servico.nome_servico);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheComboBoxClientes(ComboBox comboBox)
        {
            try
            {
                using (var context = new DbConnect())
                {
                    comboBox.Items.Clear();
                    foreach (var cliente in context.clientes.Where(c => c.ativo == 1).OrderBy(c => c.id_cliente))
                    {
                        comboBox.Items.Add(cliente.nome);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheListViewOrcamentos(ListView listView)
        {
            try
            {
                using (var context = new DbConnect())
                {
                    listView.Items.Clear();
                    foreach (var orcamento in context.orcamentos.OrderBy(o => o.id_orcamento))
                    {
                        ListViewItem item = new ListViewItem(orcamento.id_orcamento.ToString());
                        item.SubItems.Add(orcamento.nome_orcamento);
                        item.SubItems.Add(orcamento.data_inicio.ToString("dd/MM/yyyy"));
                        item.SubItems.Add(orcamento.data_conclusao.ToString("dd/MM/yyyy"));
                        listView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
