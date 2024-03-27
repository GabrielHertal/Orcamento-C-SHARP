using Orçamento.Data;
using Orçamento.Function;
using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

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
        VerificaCPF verificacpf = new VerificaCPF();
        private void btn_novo_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text;
            string rua = txt_rua.Text;
            string bairro = txt_bairro.Text;
            string cidade = txt_cidade.Text;
            string uf = txt_uf.Text;
            string CEP = txt_cep.Text;

            if (editar == true)
            {
                MessageBox.Show("Cliente já adicionado, clique em Salvar para fazer as alterações!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (documento.Length == 11)
            {
                if (!CPF.IsValidCpf(documento))
                {
                    MessageBox.Show("CPF inválido, insira um CPF válido!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (!CNPJ.IsValidCnpj(documento))
                {
                    MessageBox.Show("CNPJ inválido, insira um CNPJ válido!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (verificacpf.VerificaCpfDB(documento))
            {
                MessageBox.Show("Documento já cadastrado no sistema, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(contato))
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (var context = new DbConnect())
            {
                    var novocliente = new clientes 
                    { 
                        nome = nome, 
                        contato = contato, 
                        documento = documento, 
                        rua = rua, 
                        bairro = bairro, 
                        cidade = cidade, uf = uf, 
                        cep = CEP 
                    };
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
            int id = Convert.ToInt32(dataGridView1.Rows[linha].Cells[0].Value);
            using (var context = new DbConnect())
            {
                var clienteselec = new DbConnect().clientes
                                .Where(c => c.id_cliente == id)
                                .FirstOrDefault();
                if (clienteselec != null)
                {
                    string nome = clienteselec.nome;
                    string documento = clienteselec.documento;
                    string contato = clienteselec.contato;
                    string rua = clienteselec.rua;
                    string bairro = clienteselec.bairro;
                    string cidade = clienteselec.cidade;
                    string uf = clienteselec.uf;
                    string cep = clienteselec.cep;
                }
            }
            Form_editacliente fo_editacliente = new Form_editacliente();
            fo_editacliente.ShowDialog();
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
            string rua = txt_rua.Text;
            string bairro = txt_bairro.Text;
            string cidade = txt_cidade.Text;
            string uf = txt_uf.Text;
            string cep = txt_cep.Text;
            using (var context = new DbConnect())
            {
                var cliente = context.clientes.FirstOrDefault(c => c.id_cliente == idCliente);
                if (cliente != null)
                {
                    cliente.nome = nome;
                    cliente.documento = documento;
                    cliente.contato = contato;
                    cliente.rua = rua;
                    cliente.bairro = bairro;
                    cliente.cidade = cidade;
                    cliente.uf = uf;
                    cliente.cep = cep;
                    context.SaveChanges();
                }
                preencherDataGridView.Preencher(dataGridView1);
            }
            MessageBox.Show("Cliente alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
            editar = false;
        }
        private void LimparCampos()
        {
            txt_nome.Text = "";
            txt_documento.Text = "";
            masked_txt_contato.Text = "";
            txt_rua.Text = "";
            txt_bairro.Text = "";
            txt_cidade.Text = "";
            txt_uf.Text = "";
            txt_cep.Text = "";
        }

        private async void btn_consultacep_Click(object sender, EventArgs e)
        {
            string CEP = txt_cep.Text;
            string url = "https://viacep.com.br/ws/" + CEP + "/json/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responsebody = await response.Content.ReadAsStringAsync();

                        dynamic jsonData = JsonConvert.DeserializeObject(responsebody);
                        txt_rua.Text = jsonData.logradouro;
                        txt_bairro.Text = jsonData.bairro;
                        txt_cidade.Text = jsonData.localidade;
                        txt_uf.Text = jsonData.uf;
                    }
                    else
                    {
                        MessageBox.Show("Erro na requisição", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro!" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}