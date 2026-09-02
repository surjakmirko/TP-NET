using DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API;

namespace WindowsForms
{
    public partial class AltaCancha : Form
    {
        private int _idComplejoSeleccionado;

        public AltaCancha(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }
        private async void AltaCancha_Load(object sender, EventArgs e)
        {
            try
            {
                var tiposCancha = await TipoCanchaApiClient.ObtenerTodosAsync();

                if (tiposCancha != null)
                {
                    cmbTipoCancha.DataSource = tiposCancha;
                    cmbTipoCancha.DisplayMember = "Deporte";
                    cmbTipoCancha.ValueMember = "Id";
                    cmbTipoCancha.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tipos de cancha: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoCancha.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de cancha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            var nuevaCancha = new CanchaCrearDTO
            {
                Nro = Convert.ToInt32(nroCancha.Value),
                ComplejoId = _idComplejoSeleccionado,
                TipoCanchaId = (int)cmbTipoCancha.SelectedValue
            };

            try
            {
                await ComplejoApiClient.CrearCanchaAsync(_idComplejoSeleccionado, nuevaCancha);

                MessageBox.Show($"¡La cancha número {nuevaCancha.Nro} se creó con éxito!", "Cancha Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
