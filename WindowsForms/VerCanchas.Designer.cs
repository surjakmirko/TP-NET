namespace WindowsForms
{
    partial class VerCanchas
    {
        private System.ComponentModel.IContainer components = null;

        public DataGridView dgvCanchas;
        public Label lblTitulo;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colTipoDeporte;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colPrecio;
        private DataGridViewButtonColumn colEliminar;
        private Button btnVolver;

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
            dgvCanchas = new DataGridView();
            colEditar = new DataGridViewButtonColumn();
            colPrecio = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Canchas";
            // 
            // dgvCanchas
            // 
            dgvCanchas.AllowUserToAddRows = false;
            dgvCanchas.AllowUserToDeleteRows = false;
            dgvCanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Columns.AddRange(new DataGridViewColumn[] { colEditar, colPrecio, colEliminar });
            dgvCanchas.Location = new Point(20, 50);
            dgvCanchas.MultiSelect = false;
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanchas.Size = new Size(600, 280);
            dgvCanchas.TabIndex = 1;
            dgvCanchas.CellClick += dgvCanchas_CellClick;
            // 
            // colEditar
            // 
            colEditar.HeaderText = "Acción";
            colEditar.Name = "colEditar";
            colEditar.ReadOnly = true;
            colEditar.Text = "Editar";
            colEditar.UseColumnTextForButtonValue = true;
            // 
            // colPrecio
            // 
            colPrecio.HeaderText = "";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Text = "Precio";
            colPrecio.UseColumnTextForButtonValue = true;
            // 
            // colEliminar
            // 
            colEliminar.HeaderText = "";
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
            btnVolver.Click += botonVolver_Click;
            // 
            // VerCanchas
            // 
            ClientSize = new Size(640, 380);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dgvCanchas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "VerCanchas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Listado de Canchas";
            Load += VerCanchas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}