using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using DTOs;

namespace WindowsForms
{
    public partial class ModificarComplejo : Form
    {
        private int _idComplejoSeleccionado;
        private ComplejoDTO _complejoActual;
        private string? _imagenPath = null;

        public ModificarComplejo(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
            this.AcceptButton = btnAceptar;
        }

        private async Task MostrarDatosComplejoAsync()
        {
            try
            {
                _complejoActual = await ComplejoApiClient.ObtenerPorIdAsync(_idComplejoSeleccionado);

                if (_complejoActual != null)
                {
                    nombreActual.Text = $"Nombre actual: {_complejoActual.Nombre}";
                    direccionActual.Text = $"Dirección actual: {_complejoActual.Direccion}";
                    
                    // Cargar imagen actual si existe
                    if (!string.IsNullOrEmpty(_complejoActual.ImagenUrl))
                    {
                        try
                        {
                            picImagen.LoadAsync(_complejoActual.ImagenUrl);
                        }
                        catch
                        {
                            // Ignorar errores de carga de imagen
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el complejo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ModificarComplejo_Load(object sender, EventArgs e)
        {
            await MostrarDatosComplejoAsync();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.webp";
                openFileDialog.Title = "Seleccionar imagen del complejo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _imagenPath = openFileDialog.FileName;
                    try
                    {
                        picImagen.Image = Image.FromFile(_imagenPath);
                        lblImagen.Text = Path.GetFileName(_imagenPath);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo cargar la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _imagenPath = null;
                    }
                }
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_complejoActual == null) return;

                bool huboCambios = false;
                string nombreIngresado = nuevoNombre.Text.Trim();
                string direccionIngresada = nuevaDireccion.Text.Trim();

                if (!string.IsNullOrWhiteSpace(nombreIngresado))
                {
                    _complejoActual.Nombre = nombreIngresado;
                    huboCambios = true;
                }

                if (!string.IsNullOrWhiteSpace(direccionIngresada))
                {
                    _complejoActual.Direccion = direccionIngresada;
                    huboCambios = true;
                }

                // Verificar si hay imagen nueva
                bool hayImagenNueva = !string.IsNullOrEmpty(_imagenPath) && File.Exists(_imagenPath);

                if (!huboCambios && !hayImagenNueva)
                {
                    MessageBox.Show("No se realizaron cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Actualizar datos básicos
                await ComplejoApiClient.ActualizarComplejoAsync(_complejoActual);

                // Si hay imagen nueva, subirla
                if (hayImagenNueva)
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        var fileBytes = File.ReadAllBytes(_imagenPath);
                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                        formData.Add(fileContent, "imagen", Path.GetFileName(_imagenPath));

                        await ComplejoApiClient.SubirImagenComplejoAsync(_complejoActual.Id, formData);
                    }
                }

                MessageBox.Show("Complejo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
