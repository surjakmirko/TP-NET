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
            SuspendLayout();
            // 
            // nombreActual
            // 
            nombreActual.AutoSize = true;
            nombreActual.Font = new Font("Segoe UI", 17F);
            nombreActual.Location = new Point(30, 28);
            nombreActual.Name = "nombreActual";
            nombreActual.Size = new Size(177, 31);
            nombreActual.TabIndex = 0;
            nombreActual.Text = "Nombre actual: ";
            // 
            // direccionActual
            // 
            direccionActual.AutoSize = true;
            direccionActual.Font = new Font("Segoe UI", 17F);
            direccionActual.Location = new Point(30, 123);
            direccionActual.Name = "direccionActual";
            direccionActual.Size = new Size(189, 31);
            direccionActual.TabIndex = 1;
            direccionActual.Text = "Dirección actual: ";
            // 
            // nuevoNombre
            // 
            nuevoNombre.Font = new Font("Segoe UI", 15F);
            nuevoNombre.Location = new Point(30, 62);
            nuevoNombre.Name = "nuevoNombre";
            nuevoNombre.PlaceholderText = "Nuevo Nombre";
            nuevoNombre.Size = new Size(284, 34);
            nuevoNombre.TabIndex = 2;
            // 
            // nuevaDireccion
            // 
            nuevaDireccion.Font = new Font("Segoe UI", 15F);
            nuevaDireccion.Location = new Point(30, 157);
            nuevaDireccion.Name = "nuevaDireccion";
            nuevaDireccion.PlaceholderText = "Nueva Dirección";
            nuevaDireccion.Size = new Size(284, 34);
            nuevaDireccion.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAceptar.Location = new Point(399, 254);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(137, 29);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Confirmar Cambios";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(301, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ModificarComplejo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 295);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nuevaDireccion);
            Controls.Add(nuevoNombre);
            Controls.Add(direccionActual);
            Controls.Add(nombreActual);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ModificarComplejo";
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
    }
}