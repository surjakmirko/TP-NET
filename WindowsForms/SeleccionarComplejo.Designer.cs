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
            SuspendLayout();
            // 
            // flowLayoutPanelComplejos
            // 
            flowLayoutPanelComplejos.Dock = DockStyle.Fill;
            flowLayoutPanelComplejos.Location = new Point(0, 0);
            flowLayoutPanelComplejos.Name = "flowLayoutPanelComplejos";
            flowLayoutPanelComplejos.Size = new Size(674, 450);
            flowLayoutPanelComplejos.TabIndex = 0;
            // 
            // SeleccionarComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 450);
            Controls.Add(flowLayoutPanelComplejos);
            Name = "SeleccionarComplejo";
            Text = "Seleccionar Complejo";
            Load += SeleccionarComplejo_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelComplejos;
    }
}