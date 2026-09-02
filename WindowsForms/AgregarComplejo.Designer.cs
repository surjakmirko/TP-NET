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
            lblTitulo = new System.Windows.Forms.Label();
            lblNombre = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblDireccion = new System.Windows.Forms.Label();
            txtDireccion = new System.Windows.Forms.TextBox();
            lblEncargadoId = new System.Windows.Forms.Label();
            txtEncargadoId = new System.Windows.Forms.TextBox();
            lblLocalidadId = new System.Windows.Forms.Label();
            txtLocalidadId = new System.Windows.Forms.TextBox();
            lblDueñoId = new System.Windows.Forms.Label();
            txtDueñoId = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(180, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Complejo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(25, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(120, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(200, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new System.Drawing.Point(25, 95);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new System.Drawing.Size(60, 15);
            lblDireccion.TabIndex = 3;
            lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new System.Drawing.Point(120, 92);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new System.Drawing.Size(200, 23);
            txtDireccion.TabIndex = 4;
            // 
            // lblEncargadoId
            // 
            lblEncargadoId.AutoSize = true;
            lblEncargadoId.Location = new System.Drawing.Point(25, 130);
            lblEncargadoId.Name = "lblEncargadoId";
            lblEncargadoId.Size = new System.Drawing.Size(80, 15);
            lblEncargadoId.TabIndex = 5;
            lblEncargadoId.Text = "ID Encargado:";
            // 
            // txtEncargadoId
            // 
            txtEncargadoId.Location = new System.Drawing.Point(120, 127);
            txtEncargadoId.Name = "txtEncargadoId";
            txtEncargadoId.Size = new System.Drawing.Size(200, 23);
            txtEncargadoId.TabIndex = 6;
            // 
            // lblLocalidadId
            // 
            lblLocalidadId.AutoSize = true;
            lblLocalidadId.Location = new System.Drawing.Point(25, 165);
            lblLocalidadId.Name = "lblLocalidadId";
            lblLocalidadId.Size = new System.Drawing.Size(75, 15);
            lblLocalidadId.TabIndex = 7;
            lblLocalidadId.Text = "ID Localidad:";
            // 
            // txtLocalidadId
            // 
            txtLocalidadId.Location = new System.Drawing.Point(120, 162);
            txtLocalidadId.Name = "txtLocalidadId";
            txtLocalidadId.Size = new System.Drawing.Size(200, 23);
            txtLocalidadId.TabIndex = 8;
            // 
            // lblDueñoId
            // 
            lblDueñoId.AutoSize = true;
            lblDueñoId.Location = new System.Drawing.Point(25, 200);
            lblDueñoId.Name = "lblDueñoId";
            lblDueñoId.Size = new System.Drawing.Size(59, 15);
            lblDueñoId.TabIndex = 9;
            lblDueñoId.Text = "ID Dueño:";
            // 
            // txtDueñoId
            // 
            txtDueñoId.Location = new System.Drawing.Point(120, 197);
            txtDueñoId.Name = "txtDueñoId";
            txtDueñoId.Size = new System.Drawing.Size(200, 23);
            txtDueñoId.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(120, 245);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(95, 30);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(225, 245);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(95, 30);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AgregarComplejo
            // 
            ClientSize = new System.Drawing.Size(350, 300);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblEncargadoId);
            Controls.Add(txtEncargadoId);
            Controls.Add(lblLocalidadId);
            Controls.Add(txtLocalidadId);
            Controls.Add(lblDueñoId);
            Controls.Add(txtDueñoId);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AgregarComplejo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TurnoLibre - Nuevo Complejo";
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
        public System.Windows.Forms.TextBox txtEncargadoId;
        public System.Windows.Forms.Label lblLocalidadId;
        public System.Windows.Forms.TextBox txtLocalidadId;
        public System.Windows.Forms.Label lblDueñoId;
        public System.Windows.Forms.TextBox txtDueñoId;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
    }
}