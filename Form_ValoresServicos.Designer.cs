namespace Orçamento
{
    partial class Form_ValoresServicos
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
            label2 = new Label();
            label3 = new Label();
            txt_valororiginal = new TextBox();
            btn_confirmar = new Button();
            txt_desconto = new TextBox();
            txt_totalfinal = new TextBox();
            label4 = new Label();
            txt_acrescimo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(8, 63);
            label1.Name = "label1";
            label1.Size = new Size(83, 19);
            label1.TabIndex = 0;
            label1.Text = "Acrescimo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(8, 95);
            label2.Name = "label2";
            label2.Size = new Size(75, 19);
            label2.TabIndex = 1;
            label2.Text = "Desconto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(8, 127);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 2;
            label3.Text = "Total Final:";
            // 
            // txt_valororiginal
            // 
            txt_valororiginal.Font = new Font("Segoe UI", 10F);
            txt_valororiginal.Location = new Point(120, 29);
            txt_valororiginal.Name = "txt_valororiginal";
            txt_valororiginal.Size = new Size(168, 25);
            txt_valororiginal.TabIndex = 3;
            txt_valororiginal.Text = "R$ 0,00";
            // 
            // btn_confirmar
            // 
            btn_confirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_confirmar.Location = new Point(12, 155);
            btn_confirmar.Name = "btn_confirmar";
            btn_confirmar.Size = new Size(276, 46);
            btn_confirmar.TabIndex = 4;
            btn_confirmar.Text = "Confirmar";
            btn_confirmar.UseVisualStyleBackColor = true;
            btn_confirmar.Click += btn_confirmar_Click;
            // 
            // txt_desconto
            // 
            txt_desconto.Font = new Font("Segoe UI", 10F);
            txt_desconto.Location = new Point(120, 93);
            txt_desconto.Name = "txt_desconto";
            txt_desconto.Size = new Size(168, 25);
            txt_desconto.TabIndex = 5;
            txt_desconto.Text = "R$ 0,00";
            txt_desconto.TextChanged += txt_desconto_TextChanged;
            txt_desconto.KeyPress += txt_desconto_KeyPress;
            txt_desconto.KeyUp += txt_desconto_KeyUp;
            txt_desconto.Leave += txt_desconto_Leave;
            // 
            // txt_totalfinal
            // 
            txt_totalfinal.Font = new Font("Segoe UI", 10F);
            txt_totalfinal.Location = new Point(120, 124);
            txt_totalfinal.Name = "txt_totalfinal";
            txt_totalfinal.Size = new Size(168, 25);
            txt_totalfinal.TabIndex = 6;
            txt_totalfinal.Text = "R$ 0,00";
            txt_totalfinal.TextChanged += txt_totalfinal_TextChanged;
            txt_totalfinal.KeyPress += txt_totalfinal_KeyPress;
            txt_totalfinal.KeyUp += txt_totalfinal_KeyUp;
            txt_totalfinal.Leave += txt_totalfinal_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(8, 34);
            label4.Name = "label4";
            label4.Size = new Size(106, 19);
            label4.TabIndex = 7;
            label4.Text = "Valor Original:";
            // 
            // txt_acrescimo
            // 
            txt_acrescimo.Font = new Font("Segoe UI", 10F);
            txt_acrescimo.Location = new Point(120, 60);
            txt_acrescimo.Name = "txt_acrescimo";
            txt_acrescimo.Size = new Size(168, 25);
            txt_acrescimo.TabIndex = 8;
            txt_acrescimo.Text = "R$ 0,00";
            txt_acrescimo.TextChanged += txt_acrescimo_TextChanged;
            txt_acrescimo.KeyPress += txt_acrescimo_KeyPress;
            txt_acrescimo.KeyUp += txt_acrescimo_KeyUp;
            txt_acrescimo.Leave += txt_acrescimo_Leave;
            // 
            // Form_ValoresServicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 245);
            Controls.Add(txt_acrescimo);
            Controls.Add(label4);
            Controls.Add(txt_totalfinal);
            Controls.Add(txt_desconto);
            Controls.Add(btn_confirmar);
            Controls.Add(txt_valororiginal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form_ValoresServicos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajsutar Valor";
            Load += Form_ValoresServicos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_valororiginal;
        private Button btn_confirmar;
        private TextBox txt_desconto;
        private TextBox txt_totalfinal;
        private Label label4;
        private TextBox txt_acrescimo;
    }
}