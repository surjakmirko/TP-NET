namespace WindowsForms
{
    partial class SeleccionarComplejo
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
            flowLayoutPanelComplejos = new FlowLayoutPanel();
            seleccionarComplejoTitulo = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanelComplejos
            // 
            flowLayoutPanelComplejos.Dock = DockStyle.Bottom;
            flowLayoutPanelComplejos.Location = new Point(0, 79);
            flowLayoutPanelComplejos.Name = "flowLayoutPanelComplejos";
            flowLayoutPanelComplejos.Size = new Size(674, 371);
            flowLayoutPanelComplejos.TabIndex = 0;
            // 
            // seleccionarComplejoTitulo
            // 
            seleccionarComplejoTitulo.AutoSize = true;
            seleccionarComplejoTitulo.Font = new Font("Segoe UI", 18F);
            seleccionarComplejoTitulo.Location = new Point(215, 28);
            seleccionarComplejoTitulo.Name = "seleccionarComplejoTitulo";
            seleccionarComplejoTitulo.Size = new Size(245, 32);
            seleccionarComplejoTitulo.TabIndex = 1;
            seleccionarComplejoTitulo.Text = "Seleccionar Complejo";
            // 
            // SeleccionarComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 450);
            Controls.Add(seleccionarComplejoTitulo);
            Controls.Add(flowLayoutPanelComplejos);
            Name = "SeleccionarComplejo";
            Text = "Seleccionar Complejo";
            Load += SeleccionarComplejo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelComplejos;
        private Label seleccionarComplejoTitulo;
    }
}