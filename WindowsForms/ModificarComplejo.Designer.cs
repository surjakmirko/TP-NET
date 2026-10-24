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
            nuevoNombre = new TextBox();
            nuevaDireccion = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // nombreActual
            // 
            nombreActual.AutoSize = true;
            nombreActual.Font = new Font("Segoe UI", 13F);
            nombreActual.Location = new Point(12, 49);
            nombreActual.Name = "nombreActual";
            nombreActual.Size = new Size(138, 25);
            nombreActual.TabIndex = 0;
            nombreActual.Text = "Nombre actual: ";
            // 
            // direccionActual
            // 
            direccionActual.AutoSize = true;
            direccionActual.Font = new Font("Segoe UI", 13F);
            direccionActual.Location = new Point(12, 129);
            direccionActual.Name = "direccionActual";
            direccionActual.Size = new Size(145, 25);
            direccionActual.TabIndex = 1;
            direccionActual.Text = "Dirección actual: ";
            // 
            // nuevoNombre
            // 
            nuevoNombre.Font = new Font("Segoe UI", 13F);
            nuevoNombre.Location = new Point(12, 83);
            nuevoNombre.Name = "nuevoNombre";
            nuevoNombre.PlaceholderText = "Nuevo Nombre";
            nuevoNombre.Size = new Size(367, 31);
            nuevoNombre.TabIndex = 2;
            // 
            // nuevaDireccion
            // 
            nuevaDireccion.Font = new Font("Segoe UI", 13F);
            nuevaDireccion.Location = new Point(12, 163);
            nuevaDireccion.Name = "nuevaDireccion";
            nuevaDireccion.PlaceholderText = "Nueva Dirección";
            nuevaDireccion.Size = new Size(367, 31);
            nuevaDireccion.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAceptar.Location = new Point(242, 227);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(137, 29);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Confirmar Cambios";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(144, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(185, 25);
            label1.TabIndex = 6;
            label1.Text = "Modificar complejo";
            // 
            // ModificarComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 268);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nuevaDireccion);
            Controls.Add(nuevoNombre);
            Controls.Add(direccionActual);
            Controls.Add(nombreActual);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ModificarComplejo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Complejo";
            Load += ModificarComplejo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreActual;
        private Label direccionActual;
        private TextBox nuevoNombre;
        private TextBox nuevaDireccion;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
    }
}