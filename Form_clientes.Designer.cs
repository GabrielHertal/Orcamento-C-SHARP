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
            lv_clientes = new ListView();
            ID = new ColumnHeader();
            Nome = new ColumnHeader();
            Documento = new ColumnHeader();
            Contato = new ColumnHeader();
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
            SuspendLayout();
            // 
            // lv_clientes
            // 
            lv_clientes.Columns.AddRange(new ColumnHeader[] { ID, Nome, Documento, Contato });
            lv_clientes.Font = new Font("Segoe UI", 10F);
            lv_clientes.FullRowSelect = true;
            lv_clientes.GridLines = true;
            lv_clientes.Location = new Point(12, 213);
            lv_clientes.Name = "lv_clientes";
            lv_clientes.Size = new Size(678, 414);
            lv_clientes.TabIndex = 0;
            lv_clientes.UseCompatibleStateImageBehavior = false;
            lv_clientes.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 49;
            // 
            // Nome
            // 
            Nome.Text = "NOME";
            Nome.Width = 175;
            // 
            // Documento
            // 
            Documento.Text = "DOCUMENTO";
            Documento.Width = 300;
            // 
            // Contato
            // 
            Contato.Text = "CONTATO";
            Contato.Width = 150;
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
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(165, 19);
            label2.TabIndex = 4;
            label2.Text = "Documento(CPF/CNPJ):";
            // 
            // txt_documento
            // 
            txt_documento.Font = new Font("Segoe UI", 10F);
            txt_documento.Location = new Point(183, 75);
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
            // Form_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 639);
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
            Controls.Add(lv_clientes);
            Name = "Form_clientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += Form_clientes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lv_clientes;
        private TextBox txt_nome;
        private Label label1;
        private Label label2;
        private TextBox txt_documento;
        private Label label3;
        private MaskedTextBox masked_txt_contato;
        private ColumnHeader ID;
        private ColumnHeader Nome;
        private ColumnHeader Documento;
        private ColumnHeader Contato;
        private Button btn_novo;
        private Button btn_alterar;
        private Button btn_excluir;
        private Button btn_salvar;
    }
}