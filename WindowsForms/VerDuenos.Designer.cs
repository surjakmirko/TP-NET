namespace WindowsForms
{
    partial class VerDuenos
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
            dgvDuenos = new DataGridView();
            colEliminar = new DataGridViewButtonColumn();
            btnVolver = new Button();
            btnAgregarDueno = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDuenos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Dueños";
            // 
            // dgvDuenos
            // 
            dgvDuenos.AllowUserToAddRows = false;
            dgvDuenos.AllowUserToDeleteRows = false;
            dgvDuenos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDuenos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDuenos.Columns.AddRange(new DataGridViewColumn[] { colEliminar });
            dgvDuenos.Location = new Point(20, 50);
            dgvDuenos.MultiSelect = false;
            dgvDuenos.Name = "dgvDuenos";
            dgvDuenos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDuenos.Size = new Size(600, 280);
            dgvDuenos.TabIndex = 1;
            dgvDuenos.CellClick += dgvDuenos_CellClick;
            // 
            // colEliminar
            // 
            colEliminar.HeaderText = "Acción";
            colEliminar.Name = "colEliminar";
            colEliminar.ReadOnly = true;
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(20, 340);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(90, 28);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "← Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnAgregarDueno
            // 
            btnAgregarDueno.Location = new Point(505, 340);
            btnAgregarDueno.Name = "btnAgregarDueno";
            btnAgregarDueno.Size = new Size(115, 28);
            btnAgregarDueno.TabIndex = 3;
            btnAgregarDueno.Text = "Agregar Dueño";
            btnAgregarDueno.UseVisualStyleBackColor = true;
            btnAgregarDueno.Click += btnAgregarDueno_Click;
            // 
            // VerDuenos
            // 
            ClientSize = new Size(640, 380);
            Controls.Add(btnAgregarDueno);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dgvDuenos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "VerDuenos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TurnoLibre - Listado de Dueños";
            Load += VerDuenos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDuenos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDuenos;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Button btnVolver;
        private Button btnAgregarDueno;
    }
}