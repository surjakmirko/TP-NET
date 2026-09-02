using API;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VerDuenos : Form
    {
        public VerDuenos()
        {
            InitializeComponent();
        }

        private void VerDuenos_Load(object sender, EventArgs e)
        {
            dgvDuenos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDuenos.ReadOnly = false;

            CargarDuenos();
        }

        private void CargarDuenos()
        {
            try
            {
                // 1. Obtener los datos desde tu servicio o BD
                var listaDuenos = UsuarioApiClient.GetAllDueno();

                // 2. Asignar la lista al DataGridView
                dgvDuenos.DataSource = null; // Limpia si ya tenía datos
                dgvDuenos.DataSource = listaDuenos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los dueños: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuenos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDuenos.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                int idDueno = Convert.ToInt32(dgvDuenos.Rows[e.RowIndex].Cells["colId"].Value);

                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de eliminar este dueño?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // dueñoService.Eliminar(idDueño);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
