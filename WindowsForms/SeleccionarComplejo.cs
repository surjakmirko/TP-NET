using Data;
using Microsoft.Extensions.Configuration;
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
    public partial class SeleccionarComplejo : Form
    {
        private int _idDueno;
        private readonly ComplejoRepositorio complejoRepositorio;
        public SeleccionarComplejo(int idDueno)
        {
            InitializeComponent();
            _idDueno = idDueno;
        }

        private void SeleccionarComplejo_Load(object sender, EventArgs e)
        {
            CargarComplejosDelDueno();
        }
        private async void CargarComplejosDelDueno()
        {
            try
            {
                var listaComplejos = await complejoRepositorio.GetComplejosByIdDueno(_idDueno);
                foreach (var complejo in listaComplejos)
                {
                    Button btn = new Button();
                    btn.Text = complejo.Nombre;
                    btn.Tag = complejo.Id;
                    btn.Size = new Size(180, 80);
                    btn.Font = new Font("Arial", 11, FontStyle.Bold);
                    btn.BackColor = Color.LightSteelBlue;
                    btn.Click += BotonComplejo_Click;
                    flowLayoutPanelComplejos.Controls.Add(btn);
                }
                if (listaComplejos.Count() == 0)
                {
                    MessageBox.Show("No se encontraron complejos asociados a este dueño.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
        private void BotonComplejo_Click(object sender, EventArgs e)
        {
            Button botonPresionado = (Button)sender;
                int idComplejoSeleccionado = (int)botonPresionado.Tag;
                string nombreComplejo = botonPresionado.Text;

                MenuPrincipal formMenu = new MenuPrincipal(idComplejoSeleccionado, nombreComplejo);
                this.Hide();
                formMenu.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
        }
    }
}

