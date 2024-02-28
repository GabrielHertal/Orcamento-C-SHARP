using Orçamento.Data;
using Orçamento.Function;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_clientes : Form
    {
        private readonly PreencheGridView preencherDataGridView = new PreencheGridView();
        public Form_clientes()
        {
            InitializeComponent();
        }
        private void Form_clientes_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            preencherDataGridView.Preencher(dataGridView1);
            dataGridView1.SelectedRows[0].Selected = false;
        }
        VerificaCPF verificacpf = new VerificaCPF();
        private void btn_novo_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text;
            if (verificacpf.VerificaCpf(documento))
            {
                MessageBox.Show("Documento já cadastrado no sistema, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                return;
            }
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(contato))
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (var context = new DbConnect())
            {
                var novocliente = new clientes { nome = nome, contato = contato, documento = documento };
                context.clientes.Add(novocliente);
                context.SaveChanges();
            }
            preencherDataGridView.Preencher(dataGridView1);
            LimparCampos();
        }
        public bool editar = false;
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            editar = true;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um Cliente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int linha = dataGridView1.SelectedRows[0].Index;
            txt_nome.Text = dataGridView1.Rows[linha].Cells[1].Value.ToString();
            txt_documento.Text = dataGridView1.Rows[linha].Cells[2].Value.ToString();
            masked_txt_contato.Text = dataGridView1.Rows[linha].Cells[3].Value.ToString();
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linhaselecioada = dataGridView1.SelectedRows[0].Index;
            int idCliente = Convert.ToInt32(dataGridView1.Rows[linhaselecioada].Cells[0].Value);
            using (var context = new DbConnect())
            {
                var cliente = context.clientes.FirstOrDefault(c => c.id_cliente == idCliente);
                if (cliente != null)
                {
                    cliente.ativo = 2;
                    context.SaveChanges();
                }
                preencherDataGridView.Preencher(dataGridView1);
            }
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                MessageBox.Show("Selecione um orcamento e clique em Editar Orçamento!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text;
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(contato))
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para editar!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linhaSelecionada = dataGridView1.SelectedRows[0].Index;
            int idCliente = Convert.ToInt32(dataGridView1.Rows[linhaSelecionada].Cells[0].Value);
            using (var context = new DbConnect())
            {
                var cliente = context.clientes.FirstOrDefault(c => c.id_cliente == idCliente);
                if (cliente != null)
                {
                    cliente.nome = nome;
                    cliente.documento = documento;
                    cliente.contato = contato;
                    context.SaveChanges();
                }
                preencherDataGridView.Preencher(dataGridView1);
            }
            MessageBox.Show("Cliente alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
        }
        private void LimparCampos()
        {
            txt_nome.Text = "";
            txt_documento.Text = "";
            masked_txt_contato.Text = "";
        }
    }
}