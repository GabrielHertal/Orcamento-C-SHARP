namespace Orçamento
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }
        private Form currentForm = null;
        private void OpenChildForm(Form oldForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = oldForm;
            oldForm.TopLevel = false;
            oldForm.FormBorderStyle = FormBorderStyle.None;
            oldForm.Dock = DockStyle.Fill;
            panel_principal.Controls.Add(currentForm);
            panel_principal.Tag = currentForm;
            currentForm.BringToFront();
            currentForm.Show();
        }
        private void btn_fazorcamento_Click(object sender, EventArgs e)
        {

        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
        }


        private void btn_clientes_Click(object sender, EventArgs e)
        {
            // Form_clientes formcliente = new Form_clientes();
            OpenChildForm(new Form_clientes());
        }

        private void btn_servicos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Servicos());
        }

        private void btn_fazer_orcamentos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_fazerorcamento());
        }
    }
}
