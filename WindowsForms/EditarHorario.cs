using API;
using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class EditarHorario : Form
    {
        private readonly int _idComplejo;
        private readonly HorarioDTO _horarioOriginal;

        public EditarHorario(int idComplejo, HorarioDTO horario)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
            _horarioOriginal = horario;
        }

        private void EditarHorario_Load(object sender, EventArgs e)
        {
            lblDia.Text = $"Editando día: {((AltaHorario.DiaSemana)_horarioOriginal.NroDia)}";
            dateTimePicker1.Value = DateTime.Today.Add(_horarioOriginal.HoraApertura.ToTimeSpan());
            dateTimePicker2.Value = DateTime.Today.Add(_horarioOriginal.HoraCierre.ToTimeSpan());
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            TimeOnly nuevaApertura = TimeOnly.FromDateTime(dateTimePicker1.Value);
            TimeOnly nuevaCierre = TimeOnly.FromDateTime(dateTimePicker2.Value);

            // 2. Validar que la apertura sea menor al cierre
            if (nuevaApertura >= nuevaCierre)
            {
                MessageBox.Show("La hora de apertura debe ser menor a la hora de cierre.", "Horario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Armar DTO de actualización
                HorarioEditarDTO dto = new HorarioEditarDTO
                {
                    HoraApertura = nuevaApertura,
                    HoraCierre = nuevaCierre
                };

                // 4. Llamar a la API
                await ComplejoApiClient.ActualizarHorarioAsync(_idComplejo, _horarioOriginal.NroDia, dto);

                MessageBox.Show("Horario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}