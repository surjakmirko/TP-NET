namespace WindowsForms
{
    partial class AgregarDueno
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
            lblRazonSocial = new System.Windows.Forms.Label();
            txtRazonSocial = new System.Windows.Forms.TextBox();
            lblCuit = new System.Windows.Forms.Label();
            txtCuit = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblTelefono = new System.Windows.Forms.Label();
            txtTelefono = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(220, 25);
            lblTitulo.Text = "Agregar Dueño (P. Jurídica)";

            // Razon Social
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Location = new System.Drawing.Point(25, 60);
            lblRazonSocial.Text = "Razón Social:";
            txtRazonSocial.Location = new System.Drawing.Point(125, 57);
            txtRazonSocial.Size = new System.Drawing.Size(200, 23);

            // CUIT
            lblCuit.AutoSize = true;
            lblCuit.Location = new System.Drawing.Point(25, 95);
            lblCuit.Text = "CUIT:";
            txtCuit.Location = new System.Drawing.Point(125, 92);
            txtCuit.Size = new System.Drawing.Size(200, 23);

            // Email
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(25, 130);
            lblEmail.Text = "Email:";
            txtEmail.Location = new System.Drawing.Point(125, 127);
            txtEmail.Size = new System.Drawing.Size(200, 23);

            // Teléfono
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new System.Drawing.Point(25, 165);
            lblTelefono.Text = "Teléfono:";
            txtTelefono.Location = new System.Drawing.Point(125, 162);
            txtTelefono.Size = new System.Drawing.Size(200, 23);

            // Password
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(25, 200);
            lblPassword.Text = "Contraseña:";
            txtPassword.Location = new System.Drawing.Point(125, 197);
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(200, 23);

            // btnGuardar
            btnGuardar.Location = new System.Drawing.Point(125, 245);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(95, 30);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar.Location = new System.Drawing.Point(230, 245);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(95, 30);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;

            // Formulario AgregarDueno
            ClientSize = new System.Drawing.Size(360, 295);
            Controls.Add(lblTitulo);
            Controls.Add(lblRazonSocial);
            Controls.Add(txtRazonSocial);
            Controls.Add(lblCuit);
            Controls.Add(txtCuit);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AgregarDueno";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TurnoLibre - Nuevo Dueño";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Label lblRazonSocial;
        public System.Windows.Forms.TextBox txtRazonSocial;
        public System.Windows.Forms.Label lblCuit;
        public System.Windows.Forms.TextBox txtCuit;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.Label lblTelefono;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
    }
}