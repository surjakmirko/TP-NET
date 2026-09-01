namespace WindowsForms
{
    partial class VerComplejo
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
            lblDireccion = new Label();
            lblLocalidad = new Label();
            lblHorarios = new Label();
            lblNombre = new Label();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 15F);
            lblDireccion.Location = new Point(12, 48);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(65, 28);
            lblDireccion.TabIndex = 1;
            lblDireccion.Text = "label1";
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Font = new Font("Segoe UI", 15F);
            lblLocalidad.Location = new Point(12, 109);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(65, 28);
            lblLocalidad.TabIndex = 2;
            lblLocalidad.Text = "label1";
            // 
            // lblHorarios
            // 
            lblHorarios.AutoSize = true;
            lblHorarios.Font = new Font("Segoe UI", 15F);
            lblHorarios.Location = new Point(12, 170);
            lblHorarios.Name = "lblHorarios";
            lblHorarios.Size = new Size(65, 28);
            lblHorarios.TabIndex = 3;
            lblHorarios.Text = "label1";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNombre.Font = new Font("Segoe UI", 15F);
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(534, 82);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "label1";
            lblNombre.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(471, 350);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click_1;
            // 
            // VerComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 385);
            Controls.Add(btnVolver);
            Controls.Add(lblHorarios);
            Controls.Add(lblLocalidad);
            Controls.Add(lblDireccion);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "VerComplejo";
            Text = "Ver Complejo";
            Load += VerComplejo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDireccion;
        private Label lblLocalidad;
        private Label lblHorarios;
        private Label lblNombre;
        private Button btnVolver;
    }
}