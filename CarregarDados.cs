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

       public void PreencheListView(ListView listView)
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
    }
}
