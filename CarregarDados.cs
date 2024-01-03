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
                while(bancodedados.dados.Read())
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
       public void PreencheListViewServicos(ListView listView) 
       {
            try
            {
                bancodedados.conectar();
                ListView listview2 = new ListView();
                string sql = "SELECT * FROM servicos WHERE ativo = 1 ORDER BY id_servicos";
                bancodedados.Consultar(sql);
                listView.Items.Clear();
                while(bancodedados.dados.Read())
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
                MessageBox.Show($"Erro ao carregarr dados: {ex.Message}", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                bancodedados.desconectar();
            }
       }
    }
}
