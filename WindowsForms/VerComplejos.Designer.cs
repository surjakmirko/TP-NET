using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VerComplejos : Form
    {
        private System.ComponentModel.IContainer components = null;

        public DataGridView dgvComplejos;
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
            dgvComplejos = new DataGridView();
            colEditar = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
            colTipoDeporte = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            btnAgregarComplejo = new Button();
            ((ISupportInitialize)dgvComplejos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Complejos";
            // 
            // dgvComplejos
            // 
            dgvComplejos.AllowUserToAddRows = false;
            dgvComplejos.AllowUserToDeleteRows = false;
            dgvComplejos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComplejos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComplejos.Columns.AddRange(new DataGridViewColumn[] { colEditar, colEliminar });
            dgvComplejos.Location = new Point(20, 50);
            dgvComplejos.MultiSelect = false;
            dgvComplejos.Name = "dgvComplejos";
            dgvComplejos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComplejos.Size = new Size(600, 280);
            dgvComplejos.TabIndex = 1;
            dgvComplejos.CellClick += dgvComplejos_CellClick;
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
            // colTipoDeporte
            // 
            colTipoDeporte.Name = "colTipoDeporte";
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
            // btnAgregarComplejo
            // 
            btnAgregarComplejo.Location = new Point(495, 340);
            btnAgregarComplejo.Name = "btnAgregarComplejo";
            btnAgregarComplejo.Size = new Size(125, 28);
            btnAgregarComplejo.TabIndex = 3;
            btnAgregarComplejo.Text = "Agregar Complejo";
            btnAgregarComplejo.UseVisualStyleBackColor = true;
            btnAgregarComplejo.Click += btnAgregarComplejo_Click;
            // 
            // VerComplejos
            // 
            ClientSize = new Size(640, 380);
            Controls.Add(btnAgregarComplejo);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dgvComplejos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "VerComplejos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TurnoLibre - Listado de Complejos";
            Load += VerComplejos_Load;
            ((ISupportInitialize)dgvComplejos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnAgregarComplejo;
    }
}