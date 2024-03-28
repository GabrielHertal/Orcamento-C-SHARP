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
            btn_novo = new Button();
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
            // btn_novo
            // 
            btn_novo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_novo.Location = new Point(12, 12);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(185, 40);
            btn_novo.TabIndex = 8;
            btn_novo.Text = "CADASTRAR";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_excluir.Location = new Point(223, 12);
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
            btn_salvar.Location = new Point(587, 12);
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
            dataGridView1.Location = new Point(12, 58);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(760, 571);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
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
            // clientesBindingSource
            // 
            clientesBindingSource.DataSource = typeof(Data.clientes);
            // 
            // Form_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 641);
            Controls.Add(dataGridView1);
            Controls.Add(btn_salvar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_novo);
            Name = "Form_clientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += Form_clientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientesBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_novo;
        private Button btn_excluir;
        private Button btn_salvar;
        private BindingSource clientesBindingSource;
        private DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
        public DataGridView dataGridView1;
    }
}