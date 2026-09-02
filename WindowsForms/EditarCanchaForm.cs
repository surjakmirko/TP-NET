using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API;

namespace WindowsForms
{
    public partial class EditarCanchaForm : Form
    {
        private readonly int _idComplejo;
        private readonly int _nroCancha;
        private CanchaDTO _canchaActual;

        public EditarCanchaForm(int idComplejo, int nroCancha)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
            _nroCancha = nroCancha;
        }

        private async void EditarCanchaForm_Load(object sender, EventArgs e)
        {
            await CargarTiposDeCanchaAsync();
            await CargarDatosCanchaAsync();
        }

        private async Task CargarTiposDeCanchaAsync()
        {
            try
            {
                var tipos = await TipoCanchaApiClient.ObtenerTodosAsync();

                if (tipos != null)
                {
                    cmbTipoCancha.DataSource = tipos;
                    cmbTipoCancha.DisplayMember = "Deporte";
                    cmbTipoCancha.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tipos de cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosCanchaAsync()
        {
            try
            {
                _canchaActual = await CanchaApiClient.ObtenerCanchaAsync(_idComplejo, _nroCancha);

                if (_canchaActual != null)
                {
                    txtNumeroCancha.Text = _canchaActual.Nro.ToString();
                    cmbTipoCancha.SelectedValue = _canchaActual.TipoCanchaId;
                }
                else
                {
                    MessageBox.Show("No se encontró la cancha seleccionada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNumeroCancha.Text, out int nuevoNroCancha) || nuevoNroCancha <= 0)
                {
                    MessageBox.Show("Ingresá un número de cancha válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTipoCancha.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un tipo de cancha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _canchaActual.TipoCanchaId = Convert.ToInt32(cmbTipoCancha.SelectedValue);
                _canchaActual.Nro = nuevoNroCancha;
                await CanchaApiClient.ActualizarCanchaAsync(_canchaActual);
                MessageBox.Show("Cancha actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicado") || ex.Message.Contains("ya existe"))
                {
                    MessageBox.Show($"Ya existe una cancha con ese número", "Número duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}