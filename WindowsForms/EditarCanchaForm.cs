using Data;
using Modelo.Dominio;

namespace WindowsForms
{
    public partial class EditarCanchaForm : Form
    {
        private readonly int _idComplejo;
        private readonly int _nroCancha;
        private Cancha _canchaActual;

        public EditarCanchaForm(int idComplejo, int nroCancha)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
            _nroCancha = nroCancha;
        }

        private async void EditarCanchaForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Si tenés un método GetByIdAsync en tu repositorio:
                _canchaActual = await CanchaRepositorioProvider.Instance.GetAsync(_idComplejo, _nroCancha);

                // Mostrás el número y cargás el tipo de cancha actual en el control correspondiente
                txtNumeroCancha.Text = _canchaActual.Nro.ToString();
                txtTipoDeporteId.Text = _canchaActual.TipoCanchaId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

                if (!int.TryParse(txtTipoDeporteId.Text, out int nuevoTipoCanchaId) || nuevoTipoCanchaId <= 0)
                {
                    MessageBox.Show("Ingresá un ID de tipo de deporte válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Aplicás las funciones set de tu entidad
                _canchaActual.SetTipoCanchaId(nuevoTipoCanchaId); // Usá el nombre exacto de tu método set
                _canchaActual.SetNro(nuevoNroCancha); 


                // Guardás los cambios
                await CanchaRepositorioProvider.Instance.UpdateAsync(_canchaActual);

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