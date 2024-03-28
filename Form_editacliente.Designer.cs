namespace Orçamento
{
    partial class Form_editacliente
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
            label1 = new Label();
            txt_nome = new TextBox();
            txt_documento = new TextBox();
            label2 = new Label();
            label3 = new Label();
            masked_txt_contato = new MaskedTextBox();
            btn_consultacep = new Button();
            txt_cep = new TextBox();
            label8 = new Label();
            txt_uf = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txt_cidade = new TextBox();
            txt_bairro = new TextBox();
            txt_rua = new TextBox();
            paneldadospessoais = new Panel();
            btn_cancelar = new Button();
            btn_confirmar = new Button();
            comboBox2 = new ComboBox();
            label11 = new Label();
            comboBox1 = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            dateTimePicker1 = new DateTimePicker();
            paneldadospessoais.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(11, 3);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // txt_nome
            // 
            txt_nome.Font = new Font("Segoe UI", 10F);
            txt_nome.Location = new Point(11, 25);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(479, 25);
            txt_nome.TabIndex = 1;
            // 
            // txt_documento
            // 
            txt_documento.Font = new Font("Segoe UI", 10F);
            txt_documento.Location = new Point(11, 74);
            txt_documento.Name = "txt_documento";
            txt_documento.Size = new Size(165, 25);
            txt_documento.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(10, 55);
            label2.Name = "label2";
            label2.Size = new Size(165, 19);
            label2.TabIndex = 2;
            label2.Text = "Documento(CPF/CNPJ):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(11, 105);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 4;
            label3.Text = "Contato:";
            // 
            // masked_txt_contato
            // 
            masked_txt_contato.Font = new Font("Segoe UI", 10F);
            masked_txt_contato.Location = new Point(11, 125);
            masked_txt_contato.Mask = "(99) 00000-0000";
            masked_txt_contato.Name = "masked_txt_contato";
            masked_txt_contato.Size = new Size(105, 25);
            masked_txt_contato.TabIndex = 8;
            // 
            // btn_consultacep
            // 
            btn_consultacep.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_consultacep.Location = new Point(402, 231);
            btn_consultacep.Name = "btn_consultacep";
            btn_consultacep.Size = new Size(88, 25);
            btn_consultacep.TabIndex = 33;
            btn_consultacep.Text = "Consultar";
            btn_consultacep.UseVisualStyleBackColor = true;
            btn_consultacep.Click += btn_consultacep_Click;
            // 
            // txt_cep
            // 
            txt_cep.Font = new Font("Segoe UI", 10F);
            txt_cep.Location = new Point(229, 232);
            txt_cep.Name = "txt_cep";
            txt_cep.Size = new Size(167, 25);
            txt_cep.TabIndex = 32;
            txt_cep.TextChanged += txt_cep_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(229, 210);
            label8.Name = "label8";
            label8.Size = new Size(38, 19);
            label8.TabIndex = 31;
            label8.Text = "CEP:";
            // 
            // txt_uf
            // 
            txt_uf.Font = new Font("Segoe UI", 10F);
            txt_uf.Location = new Point(179, 232);
            txt_uf.Name = "txt_uf";
            txt_uf.Size = new Size(35, 25);
            txt_uf.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(10, 210);
            label6.Name = "label6";
            label6.Size = new Size(60, 19);
            label6.TabIndex = 29;
            label6.Text = "Cidade:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(229, 160);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 28;
            label5.Text = "Bairro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(11, 160);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 27;
            label4.Text = "Rua:";
            // 
            // txt_cidade
            // 
            txt_cidade.Font = new Font("Segoe UI", 10F);
            txt_cidade.Location = new Point(11, 232);
            txt_cidade.Name = "txt_cidade";
            txt_cidade.Size = new Size(167, 25);
            txt_cidade.TabIndex = 26;
            // 
            // txt_bairro
            // 
            txt_bairro.Font = new Font("Segoe UI", 10F);
            txt_bairro.Location = new Point(229, 182);
            txt_bairro.Name = "txt_bairro";
            txt_bairro.Size = new Size(167, 25);
            txt_bairro.TabIndex = 25;
            // 
            // txt_rua
            // 
            txt_rua.Font = new Font("Segoe UI", 10F);
            txt_rua.Location = new Point(11, 182);
            txt_rua.Name = "txt_rua";
            txt_rua.Size = new Size(203, 25);
            txt_rua.TabIndex = 24;
            // 
            // paneldadospessoais
            // 
            paneldadospessoais.Controls.Add(btn_cancelar);
            paneldadospessoais.Controls.Add(btn_confirmar);
            paneldadospessoais.Controls.Add(comboBox2);
            paneldadospessoais.Controls.Add(label11);
            paneldadospessoais.Controls.Add(comboBox1);
            paneldadospessoais.Controls.Add(label10);
            paneldadospessoais.Controls.Add(btn_consultacep);
            paneldadospessoais.Controls.Add(label9);
            paneldadospessoais.Controls.Add(txt_cep);
            paneldadospessoais.Controls.Add(dateTimePicker1);
            paneldadospessoais.Controls.Add(label8);
            paneldadospessoais.Controls.Add(txt_documento);
            paneldadospessoais.Controls.Add(txt_uf);
            paneldadospessoais.Controls.Add(label1);
            paneldadospessoais.Controls.Add(label6);
            paneldadospessoais.Controls.Add(txt_nome);
            paneldadospessoais.Controls.Add(label5);
            paneldadospessoais.Controls.Add(label2);
            paneldadospessoais.Controls.Add(label4);
            paneldadospessoais.Controls.Add(label3);
            paneldadospessoais.Controls.Add(txt_cidade);
            paneldadospessoais.Controls.Add(txt_bairro);
            paneldadospessoais.Controls.Add(masked_txt_contato);
            paneldadospessoais.Controls.Add(txt_rua);
            paneldadospessoais.Location = new Point(1, 2);
            paneldadospessoais.Name = "paneldadospessoais";
            paneldadospessoais.Size = new Size(505, 316);
            paneldadospessoais.TabIndex = 34;
            paneldadospessoais.Tag = "";
            paneldadospessoais.Paint += paneldadospessoais_Paint_1;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_cancelar.Location = new Point(10, 266);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(236, 40);
            btn_cancelar.TabIndex = 39;
            btn_cancelar.Text = "CANCELAR";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_confirmar
            // 
            btn_confirmar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_confirmar.Location = new Point(254, 266);
            btn_confirmar.Name = "btn_confirmar";
            btn_confirmar.Size = new Size(236, 40);
            btn_confirmar.TabIndex = 38;
            btn_confirmar.Text = "CONFIRMAR";
            btn_confirmar.UseVisualStyleBackColor = true;
            btn_confirmar.Click += btn_confirmar_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Branco", "Negro", "Simpsons" });
            comboBox2.Location = new Point(370, 74);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(120, 23);
            comboBox2.TabIndex = 35;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(370, 55);
            label11.Name = "label11";
            label11.Size = new Size(38, 19);
            label11.TabIndex = 34;
            label11.Text = "Cor:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Masculino", "Feminino" });
            comboBox1.Location = new Point(370, 125);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 23);
            comboBox1.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(370, 105);
            label10.Name = "label10";
            label10.Size = new Size(62, 19);
            label10.TabIndex = 11;
            label10.Text = "Gênero:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(217, 55);
            label9.Name = "label9";
            label9.Size = new Size(92, 19);
            label9.TabIndex = 10;
            label9.Text = "Nascimento:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 10F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(217, 74);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(104, 25);
            dateTimePicker1.TabIndex = 9;
            // 
            // Form_editacliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 325);
            Controls.Add(paneldadospessoais);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_editacliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Cliente";
            Load += Form_editacliente_Load;
            paneldadospessoais.ResumeLayout(false);
            paneldadospessoais.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txt_nome;
        private TextBox txt_documento;
        private Label label2;
        private Label label3;
        private MaskedTextBox masked_txt_contato;
        private Button btn_consultacep;
        private TextBox txt_cep;
        private Label label8;
        private TextBox txt_uf;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txt_cidade;
        private TextBox txt_bairro;
        private TextBox txt_rua;
        private Panel paneldadospessoais;
        private Label label9;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Label label10;
        private ComboBox comboBox2;
        private Label label11;
        private Button btn_novo;
        private Button btn_excluir;
        private Button btn_confirmar;
        private Button btn_cancelar;
    }
}