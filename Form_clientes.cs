using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_clientes : Form
    {
        public Form_clientes()
        {
            InitializeComponent();
        }
        //variaveis db, preenchelv, e formatar
        BancodeDados bancodedados = new BancodeDados();
        CarregarDados carregarDados = new CarregarDados();
        private void Form_clientes_Load(object sender, EventArgs e)
        {
            carregarDados.PreencheListViewClientes(lv_clientes);
            bancodedados.desconectar();
            WindowState = FormWindowState.Maximized;
        }
        private void btn_novo_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text.ToString();
            if (bancodedados.VerificaCPF(documento))
            {
                MessageBox.Show("Documento já cadastrado no sistema, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_documento.Text = "";
                txt_nome.Text = "";
                masked_txt_contato.Text = "";
                return;
            }
            else
            {
                if (nome == "" || documento == "" || contato == "")
                {
                    MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bancodedados.conectar();
                    string sql = $"INSERT INTO clientes (nome, documento, contato) VALUES ('{nome}', '{documento}', '{contato}')";
                    bancodedados.executar(sql);
                    bancodedados.desconectar();
                    carregarDados.PreencheListViewClientes(lv_clientes);
                }
            }
        }
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (lv_clientes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um Cliente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linha = lv_clientes.SelectedIndices[0];
            txt_nome.Text = lv_clientes.Items[linha].SubItems[1].Text;
            txt_documento.Text = lv_clientes.Items[linha].SubItems[2].Text;
            masked_txt_contato.Text = lv_clientes.Items[linha].SubItems[3].Text;
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este usuário?!", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                return;
            }
            else if (lv_clientes.SelectedItems.Count > 0)
            {
                int itemselecionado = lv_clientes.SelectedItems[0].Index;
                int indiceselecionado = Convert.ToInt32(lv_clientes.Items[itemselecionado].Text);
                bancodedados.conectar();
                string sql = "UPDATE clientes SET ativo = 2 WHERE id_cliente = @ID";
                FbCommand comando = new FbCommand(sql, bancodedados.conexao);
                comando.Parameters.AddWithValue("@ID", indiceselecionado);
                comando.ExecuteNonQuery();
                bancodedados.desconectar();
                lv_clientes.Items.RemoveAt(itemselecionado);
            }
            else
            {
                MessageBox.Show("Selecione um cliente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text.ToString();
            bancodedados.conectar();
            if(nome == "" || documento == "" || contato == "")
            {
                MessageBox.Show("Existem campos vazioz", "verifique!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string sql = $"UPDATE clientes SET nome = '{nome}', documento = '{documento}', contato = '{contato}'";
                MessageBox.Show("Cliente alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bancodedados.executar(sql);
                bancodedados.desconectar();
                txt_nome.Text = "";
                txt_documento.Text = "";
                masked_txt_contato.Text = "";
                carregarDados.PreencheListViewClientes(lv_clientes);
            }
        }
    }
}
