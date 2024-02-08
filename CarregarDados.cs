using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Orçamento
{
    public class CarregarDados
    {
        BancodeDados bancodedados = new BancodeDados();
        //preenche listview dos clientes
        public void PreencheListViewClientes(ListView listView)
        {
            BancodeDados bancodedados = new BancodeDados();
            try
            {
                bancodedados.conectar();
                ListView listView1 = new ListView();
                string sql = "SELECT * FROM clientes WHERE ativo = 1 ORDER BY id_cliente";
                bancodedados.Consultar(sql);
                listView.Items.Clear();
                while (bancodedados.dados.Read())
                {
                    ListViewItem item = new ListViewItem(bancodedados.dados["id_cliente"].ToString());
                    item.SubItems.Add(bancodedados.dados["nome"].ToString());
                    item.SubItems.Add(bancodedados.dados["documento"].ToString());
                    item.SubItems.Add(bancodedados.dados["contato"].ToString());
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bancodedados.desconectar();
            }
        }
        //preenche o listview do servicos 
        public void PreencheListViewServicos(ListView listView)
        {
            try
            {
                bancodedados.conectar();
                ListView listview2 = new ListView();
                string sql = "SELECT * FROM servicos WHERE ativo = 1 ORDER BY id_servicos";
                bancodedados.Consultar(sql);
                listView.Items.Clear();
                while (bancodedados.dados.Read())
                {
                    ListViewItem item = new ListViewItem(bancodedados.dados["id_servicos"].ToString());
                    item.SubItems.Add(bancodedados.dados["nome_servico"].ToString());
                    item.SubItems.Add(bancodedados.dados["preco_padrao"].ToString());
                    item.SubItems.Add(bancodedados.dados["descricao"].ToString());
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregarr dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bancodedados.desconectar();
            }
        }
        public void PreencheComboBoxServicos(ComboBox comboBox)
        {
            try
            {
                bancodedados.conectar();
                string sql = "SELECT * FROM servicos WHERE ativo = 1 ORDER BY id_servicos";
                bancodedados.Consultar(sql);
                comboBox.Items.Clear();

                while (bancodedados.dados.Read())
                {
                    string item = bancodedados.dados["nome_servico"].ToString();
                    comboBox.Items.Add(item);
                }

                bancodedados.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PreencheComboboxClientes(ComboBox combobox)
        {
            try
            {
                bancodedados.conectar();
                string sql = "SELECT * FROM clientes WHERE ativo = 1 ORDER BY id_cliente";
                bancodedados.Consultar(sql);
                combobox.Items.Clear();
                while (bancodedados.dados.Read())
                {
                    string item = bancodedados.dados["nome"].ToString();
                    int id = Convert.ToInt32(bancodedados.dados["id_cliente"].ToString());
                    combobox.Items.Add(item);
                }
                bancodedados.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PreencheListVieOrcamentos(ListView listView)
        {
            BancodeDados bancodedados = new BancodeDados();
            try
            {
                bancodedados.conectar();
                ListView listView1 = new ListView();
                string sql = "SELECT * FROM orcamentos ORDER BY id_orcamento";
                bancodedados.Consultar(sql);
                listView.Items.Clear();
                while (bancodedados.dados.Read())
                {
                    ListViewItem item = new ListViewItem(bancodedados.dados["id_orcamento"].ToString());
                    item.SubItems.Add(bancodedados.dados["nome_orcamento"].ToString());
                    DateTime dataInicio = DateTime.Parse(bancodedados.dados["data_inicio"].ToString());
                    item.SubItems.Add(dataInicio.ToString("dd/MM/yyyy"));
                    DateTime dataConclusao = DateTime.Parse(bancodedados.dados["data_conclusao"].ToString());
                    item.SubItems.Add(dataConclusao.ToString("dd/MM/yyyy"));
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bancodedados.desconectar();
            }
        }
    }
}
