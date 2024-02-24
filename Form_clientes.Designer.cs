namespace Orçamento
{
    partial class Form_clientes
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
            txt_nome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_documento = new TextBox();
            label3 = new Label();
            masked_txt_contato = new MaskedTextBox();
            btn_novo = new Button();
            btn_alterar = new Button();
            btn_excluir = new Button();
            btn_salvar = new Button();
            dataGridView1 = new DataGridView();
            idclienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            documentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contatoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clientesBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txt_nome
            // 
            txt_nome.Font = new Font("Segoe UI", 10F);
            txt_nome.Location = new Point(72, 37);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(256, 25);
            txt_nome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 2;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(165, 19);
            label2.TabIndex = 4;
            label2.Text = "Documento(CPF/CNPJ):";
            // 
            // txt_documento
            // 
            txt_documento.Font = new Font("Segoe UI", 10F);
            txt_documento.Location = new Point(183, 77);
            txt_documento.Name = "txt_documento";
            txt_documento.Size = new Size(145, 25);
            txt_documento.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 6;
            label3.Text = "Contato:";
            // 
            // masked_txt_contato
            // 
            masked_txt_contato.Font = new Font("Segoe UI", 10F);
            masked_txt_contato.Location = new Point(84, 117);
            masked_txt_contato.Mask = "(99) 00000-0000";
            masked_txt_contato.Name = "masked_txt_contato";
            masked_txt_contato.Size = new Size(105, 25);
            masked_txt_contato.TabIndex = 7;
            // 
            // btn_novo
            // 
            btn_novo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_novo.Location = new Point(12, 161);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(165, 37);
            btn_novo.TabIndex = 8;
            btn_novo.Text = "CADASTRAR";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            // 
            // btn_alterar
            // 
            btn_alterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_alterar.Location = new Point(183, 161);
            btn_alterar.Name = "btn_alterar";
            btn_alterar.Size = new Size(165, 37);
            btn_alterar.TabIndex = 9;
            btn_alterar.Text = "ALTERAR";
            btn_alterar.UseVisualStyleBackColor = true;
            btn_alterar.Click += btn_alterar_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_excluir.Location = new Point(354, 161);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(165, 37);
            btn_excluir.TabIndex = 10;
            btn_excluir.Text = "EXCLUIR";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // btn_salvar
            // 
            btn_salvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_salvar.Location = new Point(525, 161);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(165, 37);
            btn_salvar.TabIndex = 11;
            btn_salvar.Text = "SALVAR";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idclienteDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, documentoDataGridViewTextBoxColumn, contatoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = clientesBindingSource;
            dataGridView1.Location = new Point(12, 204);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(678, 425);
            dataGridView1.TabIndex = 12;
            // 
            // idclienteDataGridViewTextBoxColumn
            // 
            idclienteDataGridViewTextBoxColumn.DataPropertyName = "id_cliente";
            idclienteDataGridViewTextBoxColumn.HeaderText = "ID";
            idclienteDataGridViewTextBoxColumn.Name = "idclienteDataGridViewTextBoxColumn";
            idclienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "NOME";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 200;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            documentoDataGridViewTextBoxColumn.DataPropertyName = "documento";
            documentoDataGridViewTextBoxColumn.HeaderText = "DOCUMENTO";
            documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            documentoDataGridViewTextBoxColumn.ReadOnly = true;
            documentoDataGridViewTextBoxColumn.Width = 200;
            // 
            // contatoDataGridViewTextBoxColumn
            // 
            contatoDataGridViewTextBoxColumn.DataPropertyName = "contato";
            contatoDataGridViewTextBoxColumn.HeaderText = "CONTATO";
            contatoDataGridViewTextBoxColumn.Name = "contatoDataGridViewTextBoxColumn";
            contatoDataGridViewTextBoxColumn.ReadOnly = true;
            contatoDataGridViewTextBoxColumn.Width = 135;
            // 
            // clientesBindingSource
            // 
            clientesBindingSource.DataSource = typeof(Data.clientes);
            // 
            // Form_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 641);
            Controls.Add(dataGridView1);
            Controls.Add(btn_salvar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_alterar);
            Controls.Add(btn_novo);
            Controls.Add(masked_txt_contato);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_documento);
            Controls.Add(label1);
            Controls.Add(txt_nome);
            Name = "Form_clientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += Form_clientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientesBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_nome;
        private Label label1;
        private Label label2;
        private TextBox txt_documento;
        private Label label3;
        private MaskedTextBox masked_txt_contato;
        private Button btn_novo;
        private Button btn_alterar;
        private Button btn_excluir;
        private Button btn_salvar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
        private BindingSource clientesBindingSource;
    }
}