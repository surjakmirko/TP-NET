namespace WindowsForms
{
    partial class EditarCanchaForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNumeroCancha;
        private Label lblTipoDeporte;
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
            lblTipoDeporte = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbTipoCancha = new ComboBox();
            nroCanchaUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nroCanchaUpDown).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(142, 28);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Editar Cancha";
            // 
            // lblNumeroCancha
            // 
            lblNumeroCancha.AutoSize = true;
            lblNumeroCancha.Location = new Point(46, 55);
            lblNumeroCancha.Name = "lblNumeroCancha";
            lblNumeroCancha.Size = new Size(81, 20);
            lblNumeroCancha.TabIndex = 5;
            lblNumeroCancha.Text = "N° Cancha:";
            // 
            // lblTipoDeporte
            // 
            lblTipoDeporte.AutoSize = true;
            lblTipoDeporte.Location = new Point(20, 90);
            lblTipoDeporte.Name = "lblTipoDeporte";
            lblTipoDeporte.Size = new Size(101, 20);
            lblTipoDeporte.TabIndex = 3;
            lblTipoDeporte.Text = "Tipo Deporte:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(104, 135);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 25);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(185, 135);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 25);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbTipoCancha
            // 
            cmbTipoCancha.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCancha.FormattingEnabled = true;
            cmbTipoCancha.Location = new Point(127, 87);
            cmbTipoCancha.Name = "cmbTipoCancha";
            cmbTipoCancha.Size = new Size(141, 28);
            cmbTipoCancha.TabIndex = 1;
            // 
            // nroCanchaUpDown
            // 
            nroCanchaUpDown.Location = new Point(133, 54);
            nroCanchaUpDown.Name = "nroCanchaUpDown";
            nroCanchaUpDown.Size = new Size(46, 27);
            nroCanchaUpDown.TabIndex = 7;
            // 
            // EditarCanchaForm
            // 
            ClientSize = new Size(284, 181);
            Controls.Add(nroCanchaUpDown);
            Controls.Add(cmbTipoCancha);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTipoDeporte);
            Controls.Add(lblNumeroCancha);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditarCanchaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Cancha";
            Load += EditarCanchaForm_Load;
            ((System.ComponentModel.ISupportInitialize)nroCanchaUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ComboBox cmbTipoCancha;
        private NumericUpDown nroCanchaUpDown;
    }
}