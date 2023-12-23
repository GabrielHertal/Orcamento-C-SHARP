namespace Orçamento
{
    partial class Form_Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_clientes = new Button();
            btn_orçamentos = new Button();
            btn_servicos = new Button();
            btn_fazorcamento = new Button();
            SuspendLayout();
            // 
            // btn_clientes
            // 
            btn_clientes.Location = new Point(2, 300);
            btn_clientes.Name = "btn_clientes";
            btn_clientes.Size = new Size(220, 84);
            btn_clientes.TabIndex = 0;
            btn_clientes.Text = "Clientes";
            btn_clientes.UseVisualStyleBackColor = true;
            // 
            // btn_orçamentos
            // 
            btn_orçamentos.Location = new Point(2, 204);
            btn_orçamentos.Name = "btn_orçamentos";
            btn_orçamentos.Size = new Size(220, 84);
            btn_orçamentos.TabIndex = 1;
            btn_orçamentos.Text = "Orçamentos";
            btn_orçamentos.UseVisualStyleBackColor = true;
            // 
            // btn_servicos
            // 
            btn_servicos.Location = new Point(2, 390);
            btn_servicos.Name = "btn_servicos";
            btn_servicos.Size = new Size(220, 84);
            btn_servicos.TabIndex = 2;
            btn_servicos.Text = "Serviços";
            btn_servicos.UseVisualStyleBackColor = true;
            // 
            // btn_fazorcamento
            // 
            btn_fazorcamento.Location = new Point(2, 105);
            btn_fazorcamento.Name = "btn_fazorcamento";
            btn_fazorcamento.Size = new Size(220, 93);
            btn_fazorcamento.TabIndex = 3;
            btn_fazorcamento.Text = "Fazer orçamento";
            btn_fazorcamento.UseVisualStyleBackColor = true;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 621);
            Controls.Add(btn_fazorcamento);
            Controls.Add(btn_servicos);
            Controls.Add(btn_orçamentos);
            Controls.Add(btn_clientes);
            Name = "Form_Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_clientes;
        private Button btn_orçamentos;
        private Button btn_servicos;
        private Button btn_fazorcamento;
    }
}
