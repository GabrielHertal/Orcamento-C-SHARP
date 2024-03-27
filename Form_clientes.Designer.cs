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
            clientesBindingSource = new BindingSource(components);
            txt_rua = new TextBox();
            txt_bairro = new TextBox();
            txt_cidade = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txt_uf = new TextBox();
            label8 = new Label();
            txt_cep = new TextBox();
            btn_consultacep = new Button();
            idclienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            documentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contatoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txt_nome
            // 
            txt_nome.Font = new Font("Segoe UI", 10F);
            txt_nome.Location = new Point(70, 13);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(256, 25);
            txt_nome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(10, 16);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 2;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(10, 56);
            label2.Name = "label2";
            label2.Size = new Size(165, 19);
            label2.TabIndex = 4;
            label2.Text = "Documento(CPF/CNPJ):";
            // 
            // txt_documento
            // 
            txt_documento.Font = new Font("Segoe UI", 10F);
            txt_documento.Location = new Point(181, 53);
            txt_documento.Name = "txt_documento";
            txt_documento.Size = new Size(145, 25);
            txt_documento.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(10, 99);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 6;
            label3.Text = "Contato:";
            // 
            // masked_txt_contato
            // 
            masked_txt_contato.Font = new Font("Segoe UI", 10F);
            masked_txt_contato.Location = new Point(82, 93);
            masked_txt_contato.Mask = "(99) 00000-0000";
            masked_txt_contato.Name = "masked_txt_contato";
            masked_txt_contato.Size = new Size(105, 25);
            masked_txt_contato.TabIndex = 7;
            // 
            // btn_novo
            // 
            btn_novo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_novo.Location = new Point(12, 158);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(185, 40);
            btn_novo.TabIndex = 8;
            btn_novo.Text = "CADASTRAR";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            // 
            // btn_alterar
            // 
            btn_alterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_alterar.Location = new Point(204, 158);
            btn_alterar.Name = "btn_alterar";
            btn_alterar.Size = new Size(185, 40);
            btn_alterar.TabIndex = 9;
            btn_alterar.Text = "ALTERAR";
            btn_alterar.UseVisualStyleBackColor = true;
            btn_alterar.Click += btn_alterar_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_excluir.Location = new Point(395, 158);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(185, 40);
            btn_excluir.TabIndex = 10;
            btn_excluir.Text = "EXCLUIR";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // btn_salvar
            // 
            btn_salvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_salvar.Location = new Point(586, 158);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(185, 40);
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
            dataGridView1.Size = new Size(760, 425);
            dataGridView1.TabIndex = 12;
            // 
            // clientesBindingSource
            // 
            clientesBindingSource.DataSource = typeof(Data.clientes);
            // 
            // txt_rua
            // 
            txt_rua.Font = new Font("Segoe UI", 10F);
            txt_rua.Location = new Point(480, 10);
            txt_rua.Name = "txt_rua";
            txt_rua.Size = new Size(167, 25);
            txt_rua.TabIndex = 13;
            // 
            // txt_bairro
            // 
            txt_bairro.Font = new Font("Segoe UI", 10F);
            txt_bairro.Location = new Point(480, 44);
            txt_bairro.Name = "txt_bairro";
            txt_bairro.Size = new Size(167, 25);
            txt_bairro.TabIndex = 14;
            // 
            // txt_cidade
            // 
            txt_cidade.Font = new Font("Segoe UI", 10F);
            txt_cidade.Location = new Point(480, 81);
            txt_cidade.Name = "txt_cidade";
            txt_cidade.Size = new Size(167, 25);
            txt_cidade.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(414, 16);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 16;
            label4.Text = "Rua:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(414, 50);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 17;
            label5.Text = "Bairro:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(414, 90);
            label6.Name = "label6";
            label6.Size = new Size(60, 19);
            label6.TabIndex = 18;
            label6.Text = "Cidade:";
            // 
            // txt_uf
            // 
            txt_uf.Font = new Font("Segoe UI", 10F);
            txt_uf.Location = new Point(646, 81);
            txt_uf.Name = "txt_uf";
            txt_uf.Size = new Size(35, 25);
            txt_uf.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(414, 125);
            label8.Name = "label8";
            label8.Size = new Size(38, 19);
            label8.TabIndex = 21;
            label8.Text = "CEP:";
            // 
            // txt_cep
            // 
            txt_cep.Font = new Font("Segoe UI", 10F);
            txt_cep.Location = new Point(478, 119);
            txt_cep.Name = "txt_cep";
            txt_cep.Size = new Size(167, 25);
            txt_cep.TabIndex = 22;
            // 
            // btn_consultacep
            // 
            btn_consultacep.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_consultacep.Location = new Point(653, 119);
            btn_consultacep.Name = "btn_consultacep";
            btn_consultacep.Size = new Size(88, 25);
            btn_consultacep.TabIndex = 23;
            btn_consultacep.Text = "Consultar";
            btn_consultacep.UseVisualStyleBackColor = true;
            btn_consultacep.Click += btn_consultacep_Click;
            // 
            // idclienteDataGridViewTextBoxColumn
            // 
            idclienteDataGridViewTextBoxColumn.DataPropertyName = "id_cliente";
            idclienteDataGridViewTextBoxColumn.HeaderText = "ID";
            idclienteDataGridViewTextBoxColumn.Name = "idclienteDataGridViewTextBoxColumn";
            idclienteDataGridViewTextBoxColumn.ReadOnly = true;
            idclienteDataGridViewTextBoxColumn.Width = 97;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "NOME";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 240;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            documentoDataGridViewTextBoxColumn.DataPropertyName = "documento";
            documentoDataGridViewTextBoxColumn.HeaderText = "DOCUMENTO";
            documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            documentoDataGridViewTextBoxColumn.ReadOnly = true;
            documentoDataGridViewTextBoxColumn.Width = 250;
            // 
            // contatoDataGridViewTextBoxColumn
            // 
            contatoDataGridViewTextBoxColumn.DataPropertyName = "contato";
            contatoDataGridViewTextBoxColumn.HeaderText = "CONTATO";
            contatoDataGridViewTextBoxColumn.Name = "contatoDataGridViewTextBoxColumn";
            contatoDataGridViewTextBoxColumn.ReadOnly = true;
            contatoDataGridViewTextBoxColumn.Width = 130;
            // 
            // Form_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 641);
            Controls.Add(btn_consultacep);
            Controls.Add(txt_cep);
            Controls.Add(label8);
            Controls.Add(txt_uf);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txt_cidade);
            Controls.Add(txt_bairro);
            Controls.Add(txt_rua);
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
        private BindingSource clientesBindingSource;
        private TextBox txt_rua;
        private TextBox txt_bairro;
        private TextBox txt_cidade;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txt_uf;
        private Label label8;
        private TextBox txt_cep;
        private Button btn_consultacep;
        private DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
    }
}