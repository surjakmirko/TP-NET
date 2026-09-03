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
                _canchaActual = await ComplejoApiClient.ObtenerCanchaPorNroAsync(_idComplejo, _nroCancha);

                if (_canchaActual != null)
                {
                    nroCanchaUpDown.Text = _canchaActual.Nro.ToString();
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
                if (!int.TryParse(nroCanchaUpDown.Text, out int nuevoNroCancha) || nuevoNroCancha <= 0)
                {
                    MessageBox.Show("Ingresá un número de cancha válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTipoCancha.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un tipo de cancha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int nroCanchaOriginal = _canchaActual.Nro;

                var canchas = await ComplejoApiClient.ObtenerCanchasAsync(_idComplejo);
                if (canchas != null)
                {
                    bool existeOtraConMismoNro = canchas.Any(c => c.Nro == nuevoNroCancha && c.Nro != nroCanchaOriginal);
                    if (existeOtraConMismoNro)
                    {
                        MessageBox.Show("Ya existe una cancha con ese número en el complejo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                CanchaCrearDTO nuevaCancha = new CanchaCrearDTO
                {
                    Nro = nuevoNroCancha,
                    TipoCanchaId = Convert.ToInt32(cmbTipoCancha.SelectedValue)
                };


                await ComplejoApiClient.ActualizarCanchaAsync(_idComplejo, nroCanchaOriginal, nuevaCancha);

                MessageBox.Show("Cancha actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}