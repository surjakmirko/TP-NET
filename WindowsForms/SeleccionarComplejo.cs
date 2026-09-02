using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using DTOs;

namespace WindowsForms
{
    public partial class SeleccionarComplejo : Form
    {
        private int _idDueno;

        public SeleccionarComplejo(int idDueno)
        {
            InitializeComponent();
            _idDueno = idDueno;
        }

        private void SeleccionarComplejo_Load(object sender, EventArgs e)
        {
            _ = CargarComplejosDelDuenoAsync();
        }

        private async Task CargarComplejosDelDuenoAsync()
        {
            try
            {
                var listaComplejos = await ComplejoApiClient.ObtenerPorDuenoAsync(_idDueno);

                flowLayoutPanelComplejos.Controls.Clear();

                if (listaComplejos != null && listaComplejos.Any())
                {
                    foreach (var complejo in listaComplejos)
                    {
                        Button btn = new Button
                        {
                            Text = complejo.Nombre,
                            Tag = complejo.Id,
                            Size = new Size(180, 80),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        btn.Click += BotonComplejo_Click;
                        flowLayoutPanelComplejos.Controls.Add(btn);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron complejos asociados a este dueño.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los complejos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotonComplejo_Click(object sender, EventArgs e)
        {
            Button botonPresionado = (Button)sender;
            int idComplejoSeleccionado = (int)botonPresionado.Tag;
            string nombreComplejo = botonPresionado.Text;

            this.Hide();

            using (MenuPrincipal menu = new MenuPrincipal(idComplejoSeleccionado, nombreComplejo))
            {
                DialogResult res = menu.ShowDialog();

                if (res == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}