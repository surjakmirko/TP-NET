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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerComplejos_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (VerComplejos verComplejos = new VerComplejos())
            {
                verComplejos.ShowDialog();
            }
            this.Show();
        }

        private void btnVerDuenos_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (VerDuenos verDuenos = new VerDuenos())
            {
                verDuenos.ShowDialog();
            }
            this.Show();
        }
    }
}
