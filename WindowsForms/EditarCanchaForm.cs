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
            await CargarTiposDeCanchaAsync();
            await CargarDatosCanchaAsync();
            //try
            //{
            //    // Si tenés un método GetByIdAsync en tu repositorio:
            //    _canchaActual = await CanchaRepositorioProvider.Instance.GetAsync(_idComplejo, _nroCancha);

            //    // Mostrás el número y cargás el tipo de cancha actual en el control correspondiente
            //    txtNumeroCancha.Text = _canchaActual.Nro.ToString();
            //    txtTipoDeporteId.Text = _canchaActual.TipoCanchaId.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al cargar la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

        private async Task CargarTiposDeCanchaAsync()
        {
            try
            {
                // 1. Obtenemos la lista completa de tipos
                var tipos = await TipoCanchaRepositorioProvider.Instance.GetAllAsync();

                // 2. Configuramos qué se muestra y qué valor devuelve el ComboBox
                cmbTipoCancha.DataSource = tipos;
                cmbTipoCancha.DisplayMember = "Deporte"; // Propiedad que ve el usuario (ej: "Fútbol", "Tenis")
                cmbTipoCancha.ValueMember = "Id";       // Propiedad que se usa como clave primaria/ID
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
                // Obtenemos los datos actuales de la cancha
                _canchaActual = await CanchaRepositorioProvider.Instance.GetAsync(_idComplejo, _nroCancha);

                if (_canchaActual != null)
                {
                    txtNumeroCancha.Text = _canchaActual.Nro.ToString();
                    // Preseleccionamos en el combo el ID correspondiente
                    cmbTipoCancha.SelectedValue = _canchaActual.TipoCanchaId;
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

                // Aplicás las funciones set de tu entidad
                int nuevoTipoId = Convert.ToInt32(cmbTipoCancha.SelectedValue);

                _canchaActual.SetTipoCanchaId(nuevoTipoId);
                _canchaActual.SetNro(nuevoNroCancha);


                // Guardás los cambios
                await CanchaRepositorioProvider.Instance.UpdateAsync(_canchaActual);

                MessageBox.Show("Cancha actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                // Mensaje controlado cuando el número ya existe
                MessageBox.Show($"Ya existe una cancha con ese numero", "Número duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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