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
            colId = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            colTipoDeporte = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
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
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false; // Oculto si no necesitás mostrarlo en pantalla
            // 
            // colNumero
            // 
            colNumero.DataPropertyName = "Nro";
            colNumero.HeaderText = "N° Cancha";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colTipoDeporte
            // 
            colTipoDeporte.DataPropertyName = "TipoCanchaId"; // Nombre de la propiedad en CanchaDTO
            colTipoDeporte.HeaderText = "Tipo Deporte";
            colTipoDeporte.Name = "colTipoDeporte";
            colTipoDeporte.ReadOnly = true;
            // 
            // colEditar
            // 
            colEditar.HeaderText = "Acción";
            colEditar.Name = "colEditar";
            colEditar.ReadOnly = true;
            colEditar.Text = "Editar";
            colEditar.UseColumnTextForButtonValue = true;
            // 
            // colEliminar
            // 
            colEliminar.HeaderText = "";
            colEliminar.Name = "colEliminar";
            colEliminar.ReadOnly = true;
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true;
            // 
            // dgvCanchas
            // 
            dgvCanchas.AllowUserToAddRows = false;
            dgvCanchas.AllowUserToDeleteRows = false;
            dgvCanchas.AutoGenerateColumns = false; // Desactivado desde el inicio
            dgvCanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Columns.AddRange(new DataGridViewColumn[] {
                colId,
                colNumero,
                colTipoDeporte,
                colEditar,
                colEliminar
            });
            dgvCanchas.Location = new Point(20, 50);
            dgvCanchas.MultiSelect = false;
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanchas.Size = new Size(600, 280);
            dgvCanchas.TabIndex = 1;
            dgvCanchas.CellClick += dgvCanchas_CellClick;
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "VerCanchas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TurnoLibre - Listado de Canchas";
            Load += VerCanchas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}