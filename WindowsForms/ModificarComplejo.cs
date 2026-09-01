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
    public partial class ModificarComplejo : Form
    {
        private int _idComplejoSeleccionado;
        private string _nombreComplejo;
        public ModificarComplejo(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }
        private async void MostrarDatosComplejo()
        {
            try
            {
                var complejo = await ComplejoRepositorioProvider.Instance.GetAsync(_idComplejoSeleccionado);
                if (complejo != null)
                {
                    nombreActual.Text = $"Nombre actual: {complejo.Nombre}";
                    direccionActual.Text = $"Dirección actual: {complejo.Direccion}";
                }
                else
                {
                    MessageBox.Show("No se encontró el complejo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void ModificarComplejo_Load(object sender, EventArgs e)
        {
            MostrarDatosComplejo();
        }
    }
}
