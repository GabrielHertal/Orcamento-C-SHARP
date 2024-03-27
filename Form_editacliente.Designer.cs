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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
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
            comboBox2 = new ComboBox();
            label11 = new Label();
            comboBox1 = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            btn_novo = new Button();
            btn_excluir = new Button();
            btn_salvar = new Button();
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
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(11, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 25);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(11, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(165, 25);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(11, 56);
            label2.Name = "label2";
            label2.Size = new Size(165, 19);
            label2.TabIndex = 2;
            label2.Text = "Documento(CPF/CNPJ):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(11, 106);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 4;
            label3.Text = "Contato:";
            // 
            // masked_txt_contato
            // 
            masked_txt_contato.Font = new Font("Segoe UI", 10F);
            masked_txt_contato.Location = new Point(11, 124);
            masked_txt_contato.Mask = "(99) 00000-0000";
            masked_txt_contato.Name = "masked_txt_contato";
            masked_txt_contato.Size = new Size(105, 25);
            masked_txt_contato.TabIndex = 8;
            // 
            // btn_consultacep
            // 
            btn_consultacep.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_consultacep.Location = new Point(607, 112);
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
            txt_cep.Location = new Point(432, 112);
            txt_cep.Name = "txt_cep";
            txt_cep.Size = new Size(167, 25);
            txt_cep.TabIndex = 32;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(368, 118);
            label8.Name = "label8";
            label8.Size = new Size(38, 19);
            label8.TabIndex = 31;
            label8.Text = "CEP:";
            // 
            // txt_uf
            // 
            txt_uf.Font = new Font("Segoe UI", 10F);
            txt_uf.Location = new Point(600, 74);
            txt_uf.Name = "txt_uf";
            txt_uf.Size = new Size(35, 25);
            txt_uf.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(368, 83);
            label6.Name = "label6";
            label6.Size = new Size(60, 19);
            label6.TabIndex = 29;
            label6.Text = "Cidade:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(368, 43);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 28;
            label5.Text = "Bairro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(368, 9);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 27;
            label4.Text = "Rua:";
            // 
            // txt_cidade
            // 
            txt_cidade.Font = new Font("Segoe UI", 10F);
            txt_cidade.Location = new Point(434, 74);
            txt_cidade.Name = "txt_cidade";
            txt_cidade.Size = new Size(167, 25);
            txt_cidade.TabIndex = 26;
            // 
            // txt_bairro
            // 
            txt_bairro.Font = new Font("Segoe UI", 10F);
            txt_bairro.Location = new Point(434, 37);
            txt_bairro.Name = "txt_bairro";
            txt_bairro.Size = new Size(167, 25);
            txt_bairro.TabIndex = 25;
            // 
            // txt_rua
            // 
            txt_rua.Font = new Font("Segoe UI", 10F);
            txt_rua.Location = new Point(434, 3);
            txt_rua.Name = "txt_rua";
            txt_rua.Size = new Size(167, 25);
            txt_rua.TabIndex = 24;
            // 
            // paneldadospessoais
            // 
            paneldadospessoais.Controls.Add(btn_salvar);
            paneldadospessoais.Controls.Add(btn_excluir);
            paneldadospessoais.Controls.Add(btn_novo);
            paneldadospessoais.Controls.Add(comboBox2);
            paneldadospessoais.Controls.Add(label11);
            paneldadospessoais.Controls.Add(comboBox1);
            paneldadospessoais.Controls.Add(label10);
            paneldadospessoais.Controls.Add(btn_consultacep);
            paneldadospessoais.Controls.Add(label9);
            paneldadospessoais.Controls.Add(txt_cep);
            paneldadospessoais.Controls.Add(dateTimePicker1);
            paneldadospessoais.Controls.Add(label8);
            paneldadospessoais.Controls.Add(textBox2);
            paneldadospessoais.Controls.Add(txt_uf);
            paneldadospessoais.Controls.Add(label1);
            paneldadospessoais.Controls.Add(label6);
            paneldadospessoais.Controls.Add(textBox1);
            paneldadospessoais.Controls.Add(label5);
            paneldadospessoais.Controls.Add(label2);
            paneldadospessoais.Controls.Add(label4);
            paneldadospessoais.Controls.Add(label3);
            paneldadospessoais.Controls.Add(txt_cidade);
            paneldadospessoais.Controls.Add(txt_bairro);
            paneldadospessoais.Controls.Add(masked_txt_contato);
            paneldadospessoais.Controls.Add(txt_rua);
            paneldadospessoais.Location = new Point(2, 24);
            paneldadospessoais.Name = "paneldadospessoais";
            paneldadospessoais.Size = new Size(728, 309);
            paneldadospessoais.TabIndex = 34;
            paneldadospessoais.Tag = "";
            paneldadospessoais.Paint += paneldadospessoais_Paint_1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Branco", "Negro", "Simpsons" });
            comboBox2.Location = new Point(222, 126);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(120, 23);
            comboBox2.TabIndex = 35;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(222, 108);
            label11.Name = "label11";
            label11.Size = new Size(38, 19);
            label11.TabIndex = 34;
            label11.Text = "Cor:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Masculino", "Feminino" });
            comboBox1.Location = new Point(222, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 23);
            comboBox1.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(222, 56);
            label10.Name = "label10";
            label10.Size = new Size(62, 19);
            label10.TabIndex = 11;
            label10.Text = "Gênero:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(222, 3);
            label9.Name = "label9";
            label9.Size = new Size(92, 19);
            label9.TabIndex = 10;
            label9.Text = "Nascimento:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 10F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(222, 27);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(92, 25);
            dateTimePicker1.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(2, 2);
            label7.Name = "label7";
            label7.Size = new Size(115, 19);
            label7.TabIndex = 9;
            label7.Text = "Dados Pessoais:";
            // 
            // btn_novo
            // 
            btn_novo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_novo.Location = new Point(3, 167);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(236, 40);
            btn_novo.TabIndex = 36;
            btn_novo.Text = "CADASTRAR";
            btn_novo.UseVisualStyleBackColor = true;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_excluir.Location = new Point(241, 167);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(236, 40);
            btn_excluir.TabIndex = 37;
            btn_excluir.Text = "EXCLUIR";
            btn_excluir.UseVisualStyleBackColor = true;
            // 
            // btn_salvar
            // 
            btn_salvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_salvar.Location = new Point(483, 167);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(236, 40);
            btn_salvar.TabIndex = 38;
            btn_salvar.Text = "SALVAR";
            btn_salvar.UseVisualStyleBackColor = true;
            // 
            // Form_editacliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 342);
            Controls.Add(label7);
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
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
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
        private Label label7;
        private Label label9;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Label label10;
        private ComboBox comboBox2;
        private Label label11;
        private Button btn_novo;
        private Button btn_excluir;
        private Button btn_salvar;
    }
}