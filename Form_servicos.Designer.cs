namespace Orçamento
{
    partial class Form_Servicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txt_servico = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_valor = new TextBox();
            label3 = new Label();
            txt_descricao = new TextBox();
            btn_novo = new Button();
            btn_alterar = new Button();
            btn_excluir = new Button();
            btn_salvar = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            idservicosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeservicoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precopadraoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            servicosBindingSource = new BindingSource(components);
            servicoBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)servicosBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)servicoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txt_servico
            // 
            txt_servico.Font = new Font("Segoe UI", 10F);
            txt_servico.Location = new Point(77, 36);
            txt_servico.Name = "txt_servico";
            txt_servico.Size = new Size(157, 25);
            txt_servico.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(7, 39);
            label1.Name = "label1";
            label1.Size = new Size(64, 19);
            label1.TabIndex = 1;
            label1.Text = "Serviço:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(7, 79);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 3;
            label2.Text = "Valor:";
            // 
            // txt_valor
            // 
            txt_valor.Font = new Font("Segoe UI", 10F);
            txt_valor.Location = new Point(62, 76);
            txt_valor.Name = "txt_valor";
            txt_valor.Size = new Size(152, 25);
            txt_valor.TabIndex = 2;
            txt_valor.Text = "R$ 0,00";
            txt_valor.TextChanged += txt_valor_TextChanged;
            txt_valor.KeyPress += txt_valor_KeyPress;
            txt_valor.KeyUp += txt_valor_KeyUp;
            txt_valor.Leave += txt_valor_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(7, 122);
            label3.Name = "label3";
            label3.Size = new Size(78, 19);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            // 
            // txt_descricao
            // 
            txt_descricao.Font = new Font("Segoe UI", 10F);
            txt_descricao.Location = new Point(91, 119);
            txt_descricao.Name = "txt_descricao";
            txt_descricao.Size = new Size(594, 25);
            txt_descricao.TabIndex = 4;
            // 
            // btn_novo
            // 
            btn_novo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_novo.Location = new Point(7, 160);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(165, 37);
            btn_novo.TabIndex = 9;
            btn_novo.Text = "CADASTRAR";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            // 
            // btn_alterar
            // 
            btn_alterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_alterar.Location = new Point(178, 160);
            btn_alterar.Name = "btn_alterar";
            btn_alterar.Size = new Size(165, 37);
            btn_alterar.TabIndex = 10;
            btn_alterar.Text = "ALTERAR";
            btn_alterar.UseVisualStyleBackColor = true;
            btn_alterar.Click += btn_alterar_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_excluir.Location = new Point(349, 160);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(165, 37);
            btn_excluir.TabIndex = 11;
            btn_excluir.Text = "EXCLUIR";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // btn_salvar
            // 
            btn_salvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_salvar.Location = new Point(520, 160);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(165, 37);
            btn_salvar.TabIndex = 12;
            btn_salvar.Text = "SALVAR";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btn_alterar);
            panel1.Controls.Add(txt_servico);
            panel1.Controls.Add(btn_salvar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_excluir);
            panel1.Controls.Add(txt_valor);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_novo);
            panel1.Controls.Add(txt_descricao);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(704, 641);
            panel1.TabIndex = 14;
            panel1.Paint += panel1_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idservicosDataGridViewTextBoxColumn, nomeservicoDataGridViewTextBoxColumn, precopadraoDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = servicosBindingSource;
            dataGridView1.Location = new Point(7, 203);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(678, 426);
            dataGridView1.TabIndex = 13;
            // 
            // idservicosDataGridViewTextBoxColumn
            // 
            idservicosDataGridViewTextBoxColumn.DataPropertyName = "id_servicos";
            idservicosDataGridViewTextBoxColumn.HeaderText = "ID";
            idservicosDataGridViewTextBoxColumn.Name = "idservicosDataGridViewTextBoxColumn";
            idservicosDataGridViewTextBoxColumn.ReadOnly = true;
            idservicosDataGridViewTextBoxColumn.Width = 30;
            // 
            // nomeservicoDataGridViewTextBoxColumn
            // 
            nomeservicoDataGridViewTextBoxColumn.DataPropertyName = "nome_servico";
            nomeservicoDataGridViewTextBoxColumn.HeaderText = "NOME SERVICO";
            nomeservicoDataGridViewTextBoxColumn.Name = "nomeservicoDataGridViewTextBoxColumn";
            nomeservicoDataGridViewTextBoxColumn.ReadOnly = true;
            nomeservicoDataGridViewTextBoxColumn.Width = 300;
            // 
            // precopadraoDataGridViewTextBoxColumn
            // 
            precopadraoDataGridViewTextBoxColumn.DataPropertyName = "preco_padrao";
            precopadraoDataGridViewTextBoxColumn.HeaderText = "VALOR";
            precopadraoDataGridViewTextBoxColumn.Name = "precopadraoDataGridViewTextBoxColumn";
            precopadraoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "DESCRICAO";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            descricaoDataGridViewTextBoxColumn.Width = 250;
            // 
            // servicosBindingSource
            // 
            servicosBindingSource.DataSource = typeof(Data.servicos);
            // 
            // servicoBindingSource
            // 
            servicoBindingSource.DataSource = typeof(Servico);
            // 
            // Form_Servicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 641);
            Controls.Add(panel1);
            Name = "Form_Servicos";
            Text = "Serviços";
            Load += Form_Servicos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)servicosBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)servicoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_servico;
        private Label label1;
        private Label label2;
        private TextBox txt_valor;
        private Label label3;
        private TextBox txt_descricao;
        private Button btn_novo;
        private Button btn_alterar;
        private Button btn_excluir;
        private Button btn_salvar;
        private ColumnHeader Nomeservico;
        private ColumnHeader valor;
        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idservicosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeservicoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precopadraoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private BindingSource servicosBindingSource;
        private BindingSource servicoBindingSource;
    }
}