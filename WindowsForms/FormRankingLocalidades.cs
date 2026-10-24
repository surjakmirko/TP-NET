using API;
using DTOs;
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
    public partial class FormRankingLocalidades : Form
    {
        public FormRankingLocalidades()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvRanking.AutoGenerateColumns = false;
            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.ReadOnly = true;
            dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRanking.RowHeadersVisible = false;
            dgvRanking.Columns.Clear();

            dgvRanking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Posicion",
                HeaderText = "# Ranking",
                FillWeight = 20
            });

            dgvRanking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreLocalidad",
                HeaderText = "Localidad",
                FillWeight = 50
            });

            dgvRanking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadComplejos",
                HeaderText = "Cantidad de Complejos",
                FillWeight = 30
            });
        }

        private async void FormRankingLocalidades_Load(object sender, EventArgs e)
        {
            await CargarRankingAsync();
        }

        private async Task CargarRankingAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<LocalidadRankingDTO>? ranking = await ComplejoApiClient.GetRankingLocalidadesAsync();
                dgvRanking.DataSource = ranking;
                dgvRanking.ClearSelection();
                dgvRanking.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ranking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
