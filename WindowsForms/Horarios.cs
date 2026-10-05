using API;
using DTOs;
using Modelo.Dominio;
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

    public partial class Horarios : Form
    {
        private readonly int _idComplejoSeleccionado;
        public Horarios(int idComplejoSeleccionado)
        {

            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Horarios_Load(object sender, EventArgs e)
        {
            await CargarHorarios();
        }

        private async Task CargarHorarios()
        {
            var horarios = await ComplejoApiClient.ObtenerHorariosAsync(_idComplejoSeleccionado);
            dataGridView1.DataSource = horarios;
            if (dataGridView1.Columns["ComplejoId"] != null)
                dataGridView1.Columns["ComplejoId"].Visible = false;


            if (dataGridView1.Columns["NroDia"] != null)
                dataGridView1.Columns["NroDia"].HeaderText = "Día";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaHorario formAltaHorario = new AltaHorario(_idComplejoSeleccionado);
            formAltaHorario.ShowDialog();
            await CargarHorarios();
            this.Show();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "NroDia" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int nroDia))
                {

                    e.Value = ((AltaHorario.DiaSemana)nroDia).ToString();
                    e.FormattingApplied = true;
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un horario para eliminar.");
                return;
            }
            HorarioDTO h = (HorarioDTO)dataGridView1.CurrentRow.DataBoundItem;
            var confirmResult = MessageBox.Show($"¿Está seguro de eliminar el horario del día {((AltaHorario.DiaSemana)h.NroDia).ToString()}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                await ComplejoApiClient.EliminarHorarioAsync(h.ComplejoId, h.NroDia);
                MessageBox.Show("Horario eliminado correctamente.");
                await CargarHorarios();


            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un horario de la grilla para editar.");
                return;
            }
            var horarioSeleccionado = (HorarioDTO)dataGridView1.CurrentRow.DataBoundItem;
            this.Hide();
            EditarHorario formEditar = new EditarHorario(_idComplejoSeleccionado, horarioSeleccionado);
            formEditar.ShowDialog();
            await CargarHorarios();
            this.Show();
            
        }
    }
}
