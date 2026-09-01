namespace WindowsForms
{
    partial class ModificarComplejo
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
            nombreActual = new Label();
            direccionActual = new Label();
            SuspendLayout();
            // 
            // nombreActual
            // 
            nombreActual.AutoSize = true;
            nombreActual.Font = new Font("Segoe UI", 15F);
            nombreActual.Location = new Point(31, 30);
            nombreActual.Name = "nombreActual";
            nombreActual.Size = new Size(151, 28);
            nombreActual.TabIndex = 0;
            nombreActual.Text = "Nombre actual: ";
            // 
            // direccionActual
            // 
            direccionActual.AutoSize = true;
            direccionActual.Font = new Font("Segoe UI", 15F);
            direccionActual.Location = new Point(31, 166);
            direccionActual.Name = "direccionActual";
            direccionActual.Size = new Size(160, 28);
            direccionActual.TabIndex = 1;
            direccionActual.Text = "Dirección actual: ";
            // 
            // ModificarComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 450);
            Controls.Add(direccionActual);
            Controls.Add(nombreActual);
            Name = "ModificarComplejo";
            Text = "Modificar Complejo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreActual;
        private Label direccionActual;
    }
}