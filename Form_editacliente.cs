using Newtonsoft.Json;
using Orçamento.Data;
using Orçamento.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_editacliente : Form
    {
        Form_clientes fo_cliente = new Form_clientes();
        private readonly PreencheGridView preencherDataGridView = new PreencheGridView();
        VerificaCPF verificacpf = new VerificaCPF();
        private Cliente _cliente;
        public Form_editacliente(Cliente cliente)
        {
            InitializeComponent();
            if (cliente != null)
            {
                _cliente = cliente;
                PreencherCamposCliente(cliente);
            }
        }
        private void paneldadospessoais_Paint(object sender, PaintEventArgs e)
        {

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
        private void paneldadospessoais_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void Form_editacliente_Load(object sender, EventArgs e)
        {

        }
        private void PreencherCamposCliente(Cliente cliente)
        {
            txt_nome.Text = cliente.Nome;
            txt_documento.Text = cliente.Documento;
            masked_txt_contato.Text = cliente.Contato;
            txt_rua.Text = cliente.Rua;
            txt_bairro.Text = cliente.Bairro;
            txt_cidade.Text = cliente.Cidade;
            txt_uf.Text = cliente.Uf;
            txt_cep.Text = cliente.Cep;
        }
        private void txt_cep_TextChanged(object sender, EventArgs e)
        {
        }
        public string Nome
        {
            get { return _cliente.Nome; }
            set { _cliente.Nome = value; }
        }
        public string Documento
        {
            get { return _cliente.Documento; }
            set { _cliente.Documento = value; }
        }
        public string Contato
        {
            get { return _cliente.Contato; }
            set { _cliente.Contato = value; }
        }
        public string Rua
        {
            get { return _cliente.Rua; }
            set { _cliente.Rua = value; }
        }
        public string Bairro
        {
            get { return _cliente.Bairro; }
            set { _cliente.Bairro = value; }
        }
        public string Cidade
        {
            get { return _cliente.Cidade; }
            set { _cliente.Cidade = value; }
        }
        public string Uf
        {
            get { return _cliente.Uf; }
            set { _cliente.Uf = value; }
        }
        public string Cep
        {
            get { return _cliente.Cep; }
            set { _cliente.Cep = value; }
        }
        public void PreencherDadosCliente(Cliente cliente)
        {
            txt_nome.Text = cliente.Nome;
            txt_documento.Text = cliente.Documento;
            masked_txt_contato.Text = cliente.Contato;
            txt_rua.Text = cliente.Rua;
            txt_bairro.Text = cliente.Bairro;
            txt_cidade.Text = cliente.Cidade;
            txt_uf.Text = cliente.Uf;
            txt_cep.Text = cliente.Cep;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string documento = txt_documento.Text;
            string contato = masked_txt_contato.Text;
            string rua = txt_rua.Text;
            string bairro = txt_bairro.Text;
            string cidade = txt_cidade.Text;
            string uf = txt_uf.Text;
            string CEP = txt_cep.Text;
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
                    cidade = cidade,
                    uf = uf,
                    cep = CEP
                };
                context.clientes.Add(novocliente);
                context.SaveChanges();
            }
        }
    }
}
