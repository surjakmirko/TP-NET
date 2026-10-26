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
        private DataGridViewButtonColumn colDesactivar;
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
            colNumero = new DataGridViewTextBoxColumn();
            colTipoDeporte = new DataGridViewTextBoxColumn();
            var colEstado = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            colPrecio = new DataGridViewButtonColumn();
            colDesactivar = new DataGridViewButtonColumn();
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
            dgvCanchas.Columns.AddRange(new DataGridViewColumn[] {
                colNumero,
                colTipoDeporte,
                colEstado,
                colEditar,
                colPrecio,
                colDesactivar
                 });
            dgvCanchas.Location = new Point(20, 50);
            dgvCanchas.MultiSelect = false;
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanchas.Size = new Size(600, 280);
            dgvCanchas.TabIndex = 1;
            dgvCanchas.CellClick += dgvCanchas_CellClick;
            // 
            // colNumero (Vinculado a 'Nro' del DTO)
            // 
            colNumero.HeaderText = "N° Cancha";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            colNumero.DataPropertyName = "Nro";

            // 
            // colTipoDeporte (Vinculado a 'NombreTipoCancha' del DTO)
            // 
            colTipoDeporte.HeaderText = "Deporte";
            colTipoDeporte.Name = "colTipoDeporte";
            colTipoDeporte.ReadOnly = true;
            colTipoDeporte.DataPropertyName = "Deporte";

            // 
            // colEstado (Vinculado a 'Estado' del DTO)
            // 
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.DataPropertyName = "Estado";
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
            colDesactivar.HeaderText = "";
            colDesactivar.Name = "colEliminar";
            colDesactivar.ReadOnly = true;
            colDesactivar.Text = "Desactivar";
            colDesactivar.UseColumnTextForButtonValue = true;
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