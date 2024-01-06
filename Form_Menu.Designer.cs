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
            btn_servicos = new Button();
            panel_lateral = new Panel();
            btn_orcamentos = new Button();
            btn_fazer_orcamentos = new Button();
            panel_logo = new Panel();
            panel_principal = new Panel();
            panel_lateral.SuspendLayout();
            SuspendLayout();
            // 
            // btn_clientes
            // 
            btn_clientes.Dock = DockStyle.Top;
            btn_clientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_clientes.Location = new Point(0, 86);
            btn_clientes.Name = "btn_clientes";
            btn_clientes.Size = new Size(250, 84);
            btn_clientes.TabIndex = 0;
            btn_clientes.Text = "Clientes";
            btn_clientes.UseVisualStyleBackColor = true;
            btn_clientes.Click += btn_clientes_Click;
            // 
            // btn_servicos
            // 
            btn_servicos.Dock = DockStyle.Top;
            btn_servicos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_servicos.Location = new Point(0, 254);
            btn_servicos.Name = "btn_servicos";
            btn_servicos.Size = new Size(250, 84);
            btn_servicos.TabIndex = 2;
            btn_servicos.Text = "Serviços";
            btn_servicos.UseVisualStyleBackColor = true;
            btn_servicos.Click += btn_servicos_Click;
            // 
            // panel_lateral
            // 
            panel_lateral.BackColor = SystemColors.ActiveCaptionText;
            panel_lateral.Controls.Add(btn_orcamentos);
            panel_lateral.Controls.Add(btn_servicos);
            panel_lateral.Controls.Add(btn_fazer_orcamentos);
            panel_lateral.Controls.Add(btn_clientes);
            panel_lateral.Controls.Add(panel_logo);
            panel_lateral.Dock = DockStyle.Left;
            panel_lateral.Location = new Point(0, 0);
            panel_lateral.Name = "panel_lateral";
            panel_lateral.Size = new Size(250, 736);
            panel_lateral.TabIndex = 4;
            // 
            // btn_orcamentos
            // 
            btn_orcamentos.Dock = DockStyle.Top;
            btn_orcamentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_orcamentos.Location = new Point(0, 338);
            btn_orcamentos.Name = "btn_orcamentos";
            btn_orcamentos.Size = new Size(250, 84);
            btn_orcamentos.TabIndex = 5;
            btn_orcamentos.Text = "Orçamentos";
            btn_orcamentos.UseVisualStyleBackColor = true;
            // 
            // btn_fazer_orcamentos
            // 
            btn_fazer_orcamentos.Dock = DockStyle.Top;
            btn_fazer_orcamentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_fazer_orcamentos.Location = new Point(0, 170);
            btn_fazer_orcamentos.Name = "btn_fazer_orcamentos";
            btn_fazer_orcamentos.Size = new Size(250, 84);
            btn_fazer_orcamentos.TabIndex = 6;
            btn_fazer_orcamentos.Text = "Fazer Orçamentos";
            btn_fazer_orcamentos.UseVisualStyleBackColor = true;
            btn_fazer_orcamentos.Click += btn_fazer_orcamentos_Click;
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 86);
            panel_logo.TabIndex = 0;
            // 
            // panel_principal
            // 
            panel_principal.AutoSize = true;
            panel_principal.Dock = DockStyle.Fill;
            panel_principal.Location = new Point(250, 0);
            panel_principal.Name = "panel_principal";
            panel_principal.Size = new Size(964, 736);
            panel_principal.TabIndex = 5;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 736);
            Controls.Add(panel_principal);
            Controls.Add(panel_lateral);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form_Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += Form_Menu_Load;
            panel_lateral.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_clientes;
        private Button btn_servicos;
        private Panel panel_lateral;
        private Panel panel_logo;
        private Button btn_fazer_orcamentos;
        private Button btn_orcamentos;
        private Panel panel_principal;
    }
}
