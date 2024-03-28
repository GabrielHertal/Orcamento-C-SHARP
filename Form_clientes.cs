using Orçamento.Data;
using Orçamento.Function;
using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

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
        }
        VerificaCPF verificacpfdoc = new VerificaCPF();
        private void btn_novo_Click(object sender, EventArgs e)
        {
            Form_editacliente formEditaCliente = new Form_editacliente(null);
            formEditaCliente.ShowDialog();
        }
        private void btn_alterar_Click(object sender, EventArgs e)
        {
            //não é mais utilizado foi substituido pela função private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
        }
        private async void btn_consultacep_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um Cliente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int linha = dataGridView1.SelectedRows[0].Index;
            verificacpfdoc.idlinha = Convert.ToInt32(dataGridView1.Rows[linha].Cells[0].Value);
            string nome = null;
            string documento = null;
            string contato = null;
            string rua = null;
            string bairro = null;
            string cidade = null;
            string uf = null;
            string cep = null;
            using (var context = new DbConnect())
            {
                var clienteselec = new DbConnect().clientes
                                .Where(c => c.id_cliente == verificacpfdoc.idlinha)
                                .FirstOrDefault();
                if (clienteselec != null)
                {
                    verificacpfdoc.idlinha = clienteselec.id_cliente;
                    nome = clienteselec.nome;
                    documento = clienteselec.documento;
                    contato = clienteselec.contato;
                    rua = clienteselec.rua;
                    bairro = clienteselec.bairro;
                    cidade = clienteselec.cidade;
                    uf = clienteselec.uf;
                    cep = clienteselec.cep;
                }
                Cliente cliente = new Cliente(verificacpfdoc.idlinha, nome, documento, contato, rua, bairro, cidade, uf, cep);
                Form_editacliente fo_editacliente = new Form_editacliente(cliente);
                fo_editacliente.ShowDialog();
            }
        }
    }
}