using DTOs;
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
    public partial class AltaCancha : Form
    {
        private int _idComplejoSeleccionado;
        public AltaCancha(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AltaCancha_Load(object sender, EventArgs e)
        {
            var tiposCancha = new List<TipoCancha>
            {
                new TipoCancha(1, "Futbol 11"),
                new TipoCancha(2, "Futbol 5"),
                new TipoCancha(3, "Futbol 7"),
                new TipoCancha(4, "Futsal"),
                new TipoCancha(5, "Padel"),
                new TipoCancha(6, "Tenis"),
                new TipoCancha(7, "Ping Pong"),
                new TipoCancha(8, "Hockey"),
                new TipoCancha(9, "Basket"),
                new TipoCancha(10, "Voley")
            };
            cmbTipoCancha.DataSource = tiposCancha;
            cmbTipoCancha.DisplayMember = "Deporte";
            cmbTipoCancha.ValueMember = "Id";
            cmbTipoCancha.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoCancha.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de cancha.", "Error");
                this.DialogResult = DialogResult.None;
                return;
            }
            var nuevaCancha = new CanchaCrearDTO
            {
                Nro = Convert.ToInt32(nroCancha.Value),
                ComplejoId = _idComplejoSeleccionado,
                TipoCanchaId = (int)cmbTipoCancha.SelectedValue
            };
            MessageBox.Show($"¡La cancha número {nuevaCancha.Nro} se creó con éxito!", "Cancha Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
