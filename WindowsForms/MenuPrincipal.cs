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
    public partial class MenuPrincipal : Form
    {
        private int _idComplejoSeleccionado;
        private string _nombreComplejo;
        public MenuPrincipal(int idComplejoSeleccionado, string nombreComplejo)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
            _nombreComplejo = nombreComplejo;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            bienvenido.Text = $"¡Bienvenido a {_nombreComplejo}!";
        }

        private void btnModificarComplejo_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarComplejo formModificar = new ModificarComplejo(_idComplejoSeleccionado);
            formModificar.ShowDialog();
            this.Show();
        }
        private void btnVerComplejo_Click(object sender, EventArgs e)
        {
            this.Hide();
            VerComplejo formVerComplejo = new VerComplejo(_idComplejoSeleccionado);
            formVerComplejo.ShowDialog();
            this.Show();
        }

        private void btnVerCancha_Click(object sender, EventArgs e)

        {
            this.Hide();
            using (VerCanchas verCanchas = new VerCanchas(_idComplejoSeleccionado))
            {
                verCanchas.ShowDialog();
            }
            this.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cambiarComplejoBoton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}
