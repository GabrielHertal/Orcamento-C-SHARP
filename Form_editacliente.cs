using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orçamento
{
    public partial class Form_editacliente : Form
    {
        public Form_editacliente()
        {
            InitializeComponent();
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
    }
}
