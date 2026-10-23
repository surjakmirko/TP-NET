using API;
using DTOs;
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
    public partial class AltaHorario : Form
    {
        private readonly int _idComplejoSeleccionado;
        public AltaHorario(int idComplejoSeleccionado)
        {

            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }

        public enum DiaSemana
        {
            Lunes = 1,
            Martes = 2,
            Miercoles = 3,
            Jueves = 4,
            Viernes = 5,
            Sabado = 6,
            Domingo = 7
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un día de la semana.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DiaSemana diaSeleccionado = (DiaSemana)Enum.Parse(typeof(DiaSemana), comboBox1.SelectedItem.ToString());
            int diaNumero = (int)diaSeleccionado;

            HorarioCrearDTO horario = new HorarioCrearDTO
            {
                NroDia = diaNumero,
                HoraApertura = TimeOnly.FromDateTime(dateTimePicker1.Value),
                HoraCierre = TimeOnly.FromDateTime(dateTimePicker2.Value)
            };

            var resultado = await ComplejoApiClient.CrearHorarioAsync(_idComplejoSeleccionado, horario);
            if (resultado != null)
            {
                MessageBox.Show("Horario creado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear el horario");
            }

        }

        private void AltaHorario_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(DiaSemana));
        }
    }
}
