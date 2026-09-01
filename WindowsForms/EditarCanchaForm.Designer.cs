namespace WindowsForms
{
    partial class EditarCanchaForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNumeroCancha;
        private TextBox txtNumeroCancha;
        private Label lblTipoDeporte;
        private TextBox txtTipoDeporteId;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNumeroCancha = new Label();
            txtNumeroCancha = new TextBox();
            lblTipoDeporte = new Label();
            txtTipoDeporteId = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(116, 21);
            lblTitulo.Text = "Editar Cancha";
            // 
            // lblNumeroCancha
            // 
            lblNumeroCancha.AutoSize = true;
            lblNumeroCancha.Location = new Point(20, 55);
            lblNumeroCancha.Name = "lblNumeroCancha";
            lblNumeroCancha.Size = new Size(77, 15);
            lblNumeroCancha.Text = "N° Cancha:";
            // 
            // txtNumeroCancha
            // 
            txtNumeroCancha.Location = new Point(120, 52);
            txtNumeroCancha.Name = "txtNumeroCancha";
            txtNumeroCancha.Size = new Size(140, 23);
            // 
            // lblTipoDeporte
            // 
            lblTipoDeporte.AutoSize = true;
            lblTipoDeporte.Location = new Point(20, 90);
            lblTipoDeporte.Name = "lblTipoDeporte";
            lblTipoDeporte.Size = new Size(94, 15);
            lblTipoDeporte.Text = "Tipo Deporte ID:";
            // 
            // txtTipoDeporteId
            // 
            txtTipoDeporteId.Location = new Point(120, 87);
            txtTipoDeporteId.Name = "txtTipoDeporteId";
            txtTipoDeporteId.Size = new Size(140, 23);
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(104, 135);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 25);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(185, 135);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 25);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EditarCanchaForm
            // 
            ClientSize = new Size(284, 181);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtTipoDeporteId);
            Controls.Add(lblTipoDeporte);
            Controls.Add(txtNumeroCancha);
            Controls.Add(lblNumeroCancha);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditarCanchaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Cancha";
            Load += EditarCanchaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}