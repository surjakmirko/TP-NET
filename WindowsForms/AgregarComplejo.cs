using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using DTOs;
using API;

namespace WindowsForms
{
    public partial class AgregarComplejo : Form
    {
        private string? _imagenPath = null;

        public AgregarComplejo()
        {
            InitializeComponent();
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
                        using (var fs = new FileStream(_imagenPath, FileMode.Open, FileAccess.Read))
                        {
                            picImagen.Image = Image.FromStream(fs);
                        }
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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                nudIdEncargado.Value <= 0 ||
                nudIdLocalidad.Value <= 0 ||
                nudIdDueno.Value <= 0)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComplejoCrearDTO nuevoComplejo = new ComplejoCrearDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EncargadoId = (int)nudIdEncargado.Value,
                LocalidadId = (int)nudIdLocalidad.Value,
                DueñoId = (int)nudIdDueno.Value
            };

            try
            {
                // Primero crear el complejo
                var complejoCreado = await ComplejoApiClient.CrearComplejoAsync(nuevoComplejo);

                // Si hay imagen, subirla
                if (!string.IsNullOrEmpty(_imagenPath) && File.Exists(_imagenPath))
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        var fileBytes = File.ReadAllBytes(_imagenPath);
                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                        formData.Add(fileContent, "imagen", Path.GetFileName(_imagenPath));

                        await ComplejoApiClient.SubirImagenComplejoAsync((int)complejoCreado.Id, formData);
                    }
                }

                MessageBox.Show("¡Complejo registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el complejo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}