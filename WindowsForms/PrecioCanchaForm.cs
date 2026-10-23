using API;
using Modelo.Dominio;
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
    public partial class PrecioCanchaForm : Form
    {
        private readonly int _idComplejo;
        private readonly int _nroCancha;
        public PrecioCanchaForm(int idComplejo, int nroCancha)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
            _nroCancha = nroCancha;
        }

        private async void PrecioCanchaForm_Load(object sender, EventArgs e)
        {
            await CargarDatosPrecio();
        }

        private async Task CargarDatosPrecio()
        {
            try
            {
                var precio = await ComplejoApiClient.ObtenerUltimoPrecioAsync(_idComplejo, _nroCancha);

                if (precio != null)
                {
                    textBox1.Text = precio.PrecioBase.ToString();
                    textBox2.Text = precio.PrecioAdicional.ToString();
                    textBox3.Text = precio.PrecioSena.ToString();
                    textBox4.Text = precio.FechaDesde.ToString("dd-MM-yyyy");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el precio de la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            
            using (var formCrearPrecio = new PrecioCanchaCrearForm(_idComplejo, _nroCancha))
            {
                var result = formCrearPrecio.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await CargarDatosPrecio();
                }
            }
            
        }
    }
}
