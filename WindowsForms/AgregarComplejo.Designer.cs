namespace WindowsForms
{
    partial class AgregarComplejo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblEncargadoId = new Label();
            lblLocalidadId = new Label();
            lblDueñoId = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            nudIdEncargado = new NumericUpDown();
            nudIdLocalidad = new NumericUpDown();
            nudIdDueno = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudIdEncargado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudIdLocalidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudIdDueno).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(175, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Complejo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(12, 95);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 3;
            lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(120, 92);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 4;
            // 
            // lblEncargadoId
            // 
            lblEncargadoId.AutoSize = true;
            lblEncargadoId.Location = new Point(12, 130);
            lblEncargadoId.Name = "lblEncargadoId";
            lblEncargadoId.Size = new Size(80, 15);
            lblEncargadoId.TabIndex = 5;
            lblEncargadoId.Text = "ID Encargado:";
            // 
            // lblLocalidadId
            // 
            lblLocalidadId.AutoSize = true;
            lblLocalidadId.Location = new Point(12, 165);
            lblLocalidadId.Name = "lblLocalidadId";
            lblLocalidadId.Size = new Size(75, 15);
            lblLocalidadId.TabIndex = 7;
            lblLocalidadId.Text = "ID Localidad:";
            // 
            // lblDueñoId
            // 
            lblDueñoId.AutoSize = true;
            lblDueñoId.Location = new Point(12, 200);
            lblDueñoId.Name = "lblDueñoId";
            lblDueñoId.Size = new Size(59, 15);
            lblDueñoId.TabIndex = 9;
            lblDueñoId.Text = "ID Dueño:";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(243, 258);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(95, 30);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(142, 258);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 30);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // nudIdEncargado
            // 
            nudIdEncargado.Location = new Point(187, 128);
            nudIdEncargado.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudIdEncargado.Name = "nudIdEncargado";
            nudIdEncargado.Size = new Size(133, 23);
            nudIdEncargado.TabIndex = 13;
            // 
            // nudIdLocalidad
            // 
            nudIdLocalidad.Location = new Point(187, 163);
            nudIdLocalidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudIdLocalidad.Name = "nudIdLocalidad";
            nudIdLocalidad.Size = new Size(133, 23);
            nudIdLocalidad.TabIndex = 14;
            // 
            // nudIdDueno
            // 
            nudIdDueno.Location = new Point(187, 198);
            nudIdDueno.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudIdDueno.Name = "nudIdDueno";
            nudIdDueno.Size = new Size(133, 23);
            nudIdDueno.TabIndex = 15;
            // 
            // AgregarComplejo
            // 
            ClientSize = new Size(350, 300);
            Controls.Add(nudIdDueno);
            Controls.Add(nudIdLocalidad);
            Controls.Add(nudIdEncargado);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblEncargadoId);
            Controls.Add(lblLocalidadId);
            Controls.Add(lblDueñoId);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AgregarComplejo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TurnoLibre - Nuevo Complejo";
            ((System.ComponentModel.ISupportInitialize)nudIdEncargado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudIdLocalidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudIdDueno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.Label lblDireccion;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.Label lblEncargadoId;
        public System.Windows.Forms.Label lblLocalidadId;
        public System.Windows.Forms.Label lblDueñoId;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
        private NumericUpDown nudIdEncargado;
        private NumericUpDown nudIdLocalidad;
        private NumericUpDown nudIdDueno;
    }
}