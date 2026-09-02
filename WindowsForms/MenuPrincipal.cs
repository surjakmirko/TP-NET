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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ModificarComplejo formModificar = new ModificarComplejo(_idComplejoSeleccionado);
            formModificar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnVerComplejo_Click(object sender, EventArgs e)
        {

        }

        private void btnDarDeAltaCancha_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaCancha formAltaCancha = new AltaCancha(_idComplejoSeleccionado);
            formAltaCancha.ShowDialog();
            this.Show();
        }
    }
}
