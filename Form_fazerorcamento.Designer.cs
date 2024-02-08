namespace Orçamento
{
    partial class Form_fazerorcamento
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
            txt_nomeorcamento = new TextBox();
            dtp_inicio = new DateTimePicker();
            cbx_serviço = new ComboBox();
            txt_localização = new TextBox();
            txt_tamanho = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtp_conclusao = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            txt_observações = new TextBox();
            label8 = new Label();
            cbx_cliente = new ComboBox();
            lv_servicos = new ListView();
            id = new ColumnHeader();
            SERVIÇO = new ColumnHeader();
            tamanho = new ColumnHeader();
            desconto = new ColumnHeader();
            acrescimo = new ColumnHeader();
            Total = new ColumnHeader();
            btn_adicionar = new Button();
            btn_remover = new Button();
            label9 = new Label();
            txt_desconto = new TextBox();
            txt_acrescimo = new TextBox();
            label10 = new Label();
            txt_total = new TextBox();
            label11 = new Label();
            btn_editaorcamento = new Button();
            btn_finalizaorcamento = new Button();
            lv_orcamentos = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(133, 19);
            label1.TabIndex = 0;
            label1.Text = "Nome Orçamento:";
            // 
            // txt_nomeorcamento
            // 
            txt_nomeorcamento.Font = new Font("Segoe UI", 10F);
            txt_nomeorcamento.Location = new Point(149, 22);
            txt_nomeorcamento.Name = "txt_nomeorcamento";
            txt_nomeorcamento.Size = new Size(248, 25);
            txt_nomeorcamento.TabIndex = 1;
            // 
            // dtp_inicio
            // 
            dtp_inicio.Font = new Font("Segoe UI", 10F);
            dtp_inicio.Format = DateTimePickerFormat.Short;
            dtp_inicio.Location = new Point(648, 25);
            dtp_inicio.Name = "dtp_inicio";
            dtp_inicio.Size = new Size(105, 25);
            dtp_inicio.TabIndex = 2;
            // 
            // cbx_serviço
            // 
            cbx_serviço.Font = new Font("Segoe UI", 10F);
            cbx_serviço.FormattingEnabled = true;
            cbx_serviço.Location = new Point(149, 88);
            cbx_serviço.Name = "cbx_serviço";
            cbx_serviço.Size = new Size(248, 25);
            cbx_serviço.TabIndex = 3;
            cbx_serviço.SelectedIndexChanged += cbx_serviço_SelectedIndexChanged;
            // 
            // txt_localização
            // 
            txt_localização.Font = new Font("Segoe UI", 10F);
            txt_localização.Location = new Point(116, 119);
            txt_localização.Name = "txt_localização";
            txt_localização.Size = new Size(677, 25);
            txt_localização.TabIndex = 4;
            // 
            // txt_tamanho
            // 
            txt_tamanho.Font = new Font("Segoe UI", 10F);
            txt_tamanho.Location = new Point(648, 85);
            txt_tamanho.Name = "txt_tamanho";
            txt_tamanho.Size = new Size(105, 25);
            txt_tamanho.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(10, 122);
            label2.Name = "label2";
            label2.Size = new Size(91, 19);
            label2.TabIndex = 6;
            label2.Text = "Localização:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(526, 91);
            label3.Name = "label3";
            label3.Size = new Size(74, 19);
            label3.TabIndex = 7;
            label3.Text = "Tamanho:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(10, 91);
            label4.Name = "label4";
            label4.Size = new Size(64, 19);
            label4.TabIndex = 8;
            label4.Text = "Serviço:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(523, 31);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 9;
            label5.Text = "Data Inicio:";
            // 
            // dtp_conclusao
            // 
            dtp_conclusao.Font = new Font("Segoe UI", 10F);
            dtp_conclusao.Format = DateTimePickerFormat.Short;
            dtp_conclusao.Location = new Point(649, 56);
            dtp_conclusao.Name = "dtp_conclusao";
            dtp_conclusao.Size = new Size(104, 25);
            dtp_conclusao.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(523, 62);
            label6.Name = "label6";
            label6.Size = new Size(120, 19);
            label6.TabIndex = 11;
            label6.Text = "Data Conclusão: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(10, 153);
            label7.Name = "label7";
            label7.Size = new Size(100, 19);
            label7.TabIndex = 13;
            label7.Text = "Observações:";
            // 
            // txt_observações
            // 
            txt_observações.Font = new Font("Segoe UI", 10F);
            txt_observações.Location = new Point(116, 150);
            txt_observações.Name = "txt_observações";
            txt_observações.Size = new Size(677, 25);
            txt_observações.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(10, 56);
            label8.Name = "label8";
            label8.Size = new Size(59, 19);
            label8.TabIndex = 15;
            label8.Text = "Cliente:";
            // 
            // cbx_cliente
            // 
            cbx_cliente.Font = new Font("Segoe UI", 10F);
            cbx_cliente.FormattingEnabled = true;
            cbx_cliente.Location = new Point(149, 56);
            cbx_cliente.Name = "cbx_cliente";
            cbx_cliente.Size = new Size(248, 25);
            cbx_cliente.TabIndex = 14;
            cbx_cliente.TextChanged += cbx_cliente_TextChanged;
            // 
            // lv_servicos
            // 
            lv_servicos.Columns.AddRange(new ColumnHeader[] { id, SERVIÇO, tamanho, desconto, acrescimo, Total });
            lv_servicos.Font = new Font("Segoe UI", 10F);
            lv_servicos.FullRowSelect = true;
            lv_servicos.GridLines = true;
            lv_servicos.Location = new Point(12, 223);
            lv_servicos.Name = "lv_servicos";
            lv_servicos.Size = new Size(781, 112);
            lv_servicos.TabIndex = 16;
            lv_servicos.UseCompatibleStateImageBehavior = false;
            lv_servicos.View = View.Details;
            // 
            // id
            // 
            id.Text = "ID";
            id.Width = 40;
            // 
            // SERVIÇO
            // 
            SERVIÇO.Text = "SERVIÇO";
            SERVIÇO.TextAlign = HorizontalAlignment.Center;
            SERVIÇO.Width = 300;
            // 
            // tamanho
            // 
            tamanho.Text = "TAMANHO";
            tamanho.TextAlign = HorizontalAlignment.Center;
            tamanho.Width = 150;
            // 
            // desconto
            // 
            desconto.Text = "DESCONTO";
            desconto.TextAlign = HorizontalAlignment.Center;
            desconto.Width = 80;
            // 
            // acrescimo
            // 
            acrescimo.Text = "ACRESCIMO";
            acrescimo.TextAlign = HorizontalAlignment.Center;
            acrescimo.Width = 90;
            // 
            // Total
            // 
            Total.Text = "TOTAL";
            Total.TextAlign = HorizontalAlignment.Center;
            Total.Width = 117;
            // 
            // btn_adicionar
            // 
            btn_adicionar.Location = new Point(12, 181);
            btn_adicionar.Name = "btn_adicionar";
            btn_adicionar.Size = new Size(368, 36);
            btn_adicionar.TabIndex = 17;
            btn_adicionar.Text = "Adicionar Serviço";
            btn_adicionar.UseVisualStyleBackColor = true;
            btn_adicionar.Click += btn_adicionar_Click;
            // 
            // btn_remover
            // 
            btn_remover.Location = new Point(427, 181);
            btn_remover.Name = "btn_remover";
            btn_remover.Size = new Size(366, 36);
            btn_remover.TabIndex = 18;
            btn_remover.Text = "Remover Serviço";
            btn_remover.UseVisualStyleBackColor = true;
            btn_remover.Click += btn_remover_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(10, 347);
            label9.Name = "label9";
            label9.Size = new Size(112, 19);
            label9.TabIndex = 19;
            label9.Text = "Total Desconto:";
            // 
            // txt_desconto
            // 
            txt_desconto.Font = new Font("Segoe UI", 10F);
            txt_desconto.Location = new Point(127, 344);
            txt_desconto.Name = "txt_desconto";
            txt_desconto.Size = new Size(135, 25);
            txt_desconto.TabIndex = 20;
            txt_desconto.Text = "R$ 0,00";
            txt_desconto.TextChanged += txt_desconto_TextChanged;
            txt_desconto.KeyDown += txt_desconto_KeyDown;
            txt_desconto.KeyPress += txt_desconto_KeyPress;
            txt_desconto.KeyUp += txt_desconto_KeyUp;
            txt_desconto.Leave += txt_desconto_Leave;
            // 
            // txt_acrescimo
            // 
            txt_acrescimo.Font = new Font("Segoe UI", 10F);
            txt_acrescimo.Location = new Point(394, 344);
            txt_acrescimo.Name = "txt_acrescimo";
            txt_acrescimo.Size = new Size(135, 25);
            txt_acrescimo.TabIndex = 22;
            txt_acrescimo.Text = "R$ 0,00";
            txt_acrescimo.TextChanged += txt_acrescimo_TextChanged;
            txt_acrescimo.KeyPress += txt_acrescimo_KeyPress;
            txt_acrescimo.KeyUp += txt_acrescimo_KeyUp;
            txt_acrescimo.Leave += txt_acrescimo_Leave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(268, 347);
            label10.Name = "label10";
            label10.Size = new Size(120, 19);
            label10.TabIndex = 21;
            label10.Text = "Total Acrescimo:";
            // 
            // txt_total
            // 
            txt_total.Font = new Font("Segoe UI", 10F);
            txt_total.Location = new Point(648, 344);
            txt_total.Name = "txt_total";
            txt_total.Size = new Size(145, 25);
            txt_total.TabIndex = 24;
            txt_total.Text = "R$ 0,00";
            txt_total.TextChanged += txt_total_TextChanged;
            txt_total.KeyPress += txt_total_KeyPress;
            txt_total.KeyUp += txt_total_KeyUp;
            txt_total.Leave += txt_total_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(536, 347);
            label11.Name = "label11";
            label11.Size = new Size(107, 19);
            label11.TabIndex = 23;
            label11.Text = "Total Serviços:";
            // 
            // btn_editaorcamento
            // 
            btn_editaorcamento.Location = new Point(427, 535);
            btn_editaorcamento.Name = "btn_editaorcamento";
            btn_editaorcamento.Size = new Size(366, 36);
            btn_editaorcamento.TabIndex = 25;
            btn_editaorcamento.Text = "Editar Orçamento";
            btn_editaorcamento.UseVisualStyleBackColor = true;
            btn_editaorcamento.Click += btn_editaorcamento_Click;
            // 
            // btn_finalizaorcamento
            // 
            btn_finalizaorcamento.Location = new Point(14, 375);
            btn_finalizaorcamento.Name = "btn_finalizaorcamento";
            btn_finalizaorcamento.Size = new Size(779, 36);
            btn_finalizaorcamento.TabIndex = 26;
            btn_finalizaorcamento.Text = "Finalizar Orçamento";
            btn_finalizaorcamento.UseVisualStyleBackColor = true;
            btn_finalizaorcamento.Click += btn_finalizaorcamento_Click;
            // 
            // lv_orcamentos
            // 
            lv_orcamentos.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lv_orcamentos.Font = new Font("Segoe UI", 10F);
            lv_orcamentos.FullRowSelect = true;
            lv_orcamentos.GridLines = true;
            lv_orcamentos.Location = new Point(10, 417);
            lv_orcamentos.Name = "lv_orcamentos";
            lv_orcamentos.Size = new Size(781, 112);
            lv_orcamentos.TabIndex = 27;
            lv_orcamentos.UseCompatibleStateImageBehavior = false;
            lv_orcamentos.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "ORÇAMENTO";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 485;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "DATA INICIO";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "DATA CONCLUSÃO";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(10, 535);
            button1.Name = "button1";
            button1.Size = new Size(366, 36);
            button1.TabIndex = 28;
            button1.Text = "Atualizar Orçamento";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form_fazerorcamento
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 726);
            Controls.Add(button1);
            Controls.Add(lv_orcamentos);
            Controls.Add(btn_finalizaorcamento);
            Controls.Add(btn_editaorcamento);
            Controls.Add(txt_total);
            Controls.Add(label11);
            Controls.Add(txt_acrescimo);
            Controls.Add(label10);
            Controls.Add(txt_desconto);
            Controls.Add(label9);
            Controls.Add(btn_remover);
            Controls.Add(btn_adicionar);
            Controls.Add(lv_servicos);
            Controls.Add(label8);
            Controls.Add(cbx_cliente);
            Controls.Add(label7);
            Controls.Add(txt_observações);
            Controls.Add(label6);
            Controls.Add(dtp_conclusao);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_tamanho);
            Controls.Add(txt_localização);
            Controls.Add(cbx_serviço);
            Controls.Add(dtp_inicio);
            Controls.Add(txt_nomeorcamento);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Name = "Form_fazerorcamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fazer Orçamento";
            Load += Form_fazerorcamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_nomeorcamento;
        private DateTimePicker dtp_inicio;
        private ComboBox cbx_serviço;
        private TextBox txt_localização;
        private TextBox txt_tamanho;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtp_conclusao;
        private Label label6;
        private Label label7;
        private TextBox txt_observações;
        private Label label8;
        private ComboBox cbx_cliente;
        private ListView lv_servicos;
        private ColumnHeader id;
        private ColumnHeader SERVIÇO;
        private ColumnHeader tamanho;
        private Button btn_adicionar;
        private Button btn_remover;
        private Label label9;
        private TextBox txt_desconto;
        private TextBox txt_acrescimo;
        private Label label10;
        private TextBox txt_total;
        private Label label11;
        private Button btn_editaorcamento;
        private Button btn_finalizaorcamento;
        private ColumnHeader desconto;
        private ColumnHeader acrescimo;
        private ColumnHeader Total;
        private ListView lv_orcamentos;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button button1;
    }
}