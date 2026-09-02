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
                var listaComplejos = await ComplejoRepositorioProvider.Instance.GetComplejosByIdDueno(_idDueno);
                foreach (var complejo in listaComplejos)
                {
                    Button btn = new Button();
                    btn.Text = complejo.Nombre;
                    btn.Tag = complejo.Id;
                    btn.Size = new Size(180, 80);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Click += BotonComplejo_Click;
                    flowLayoutPanelComplejos.Controls.Add(btn);
                }
                if (listaComplejos.Count() == 0)
                {
                    MessageBox.Show("No se encontraron complejos asociados a este dueño.");
                    this.Close();
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


            this.Hide();

            using (MenuPrincipal menu = new MenuPrincipal(idComplejoSeleccionado,nombreComplejo))
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

