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
    public partial class VerComplejo : Form
    {
        private readonly int _idComplejoSeleccionado;

        public VerComplejo(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
        }

        private void VerComplejo_Load(object sender, EventArgs e)
        {
            CargarDetallesDelComplejo();
        }

        private async void CargarDetallesDelComplejo()
        {
            try
            {
                var complejo = await ComplejoRepositorioProvider.Instance.GetAsync(_idComplejoSeleccionado);
                if (complejo != null)
                {
                    lblNombre.Text = $"Nombre: {complejo.Nombre}";
                    lblDireccion.Text = $"Dirección: {complejo.Direccion}";
                    var localidad = await LocalidadRepositorioProvider.Instance.GetAsync(complejo.LocalidadId);
                    lblLocalidad.Text = $"Localidad: {localidad.Nombre}";
                    StringBuilder sbHorarios = new StringBuilder();
                    if (complejo.Horarios != null && complejo.Horarios.Count > 0)
                    {
                        foreach (var h in complejo.Horarios)
                        {
                            // Ejemplo de lo que se agrega: "Lunes: 08:00 a 22:00 hs" o "Feriados: 10:00 a 20:00 hs"
                            string nombreDia = h.NroDia switch
                            {
                                1 => "Lunes",
                                2 => "Martes",
                                3 => "Miércoles",
                                4 => "Jueves",
                                5 => "Viernes",
                                6 => "Sábado",
                                7 => "Domingo",
                                8 => "Feriado",
                                _ => ""
                            };
                            sbHorarios.AppendLine($"{nombreDia}: {h.HoraApertura:hh\\:mm} a {h.HoraCierre:hh\\:mm} hs");
                        }
                    }
                    else
                    {
                        sbHorarios.AppendLine("No hay horarios registrados.");
                    }
                    lblHorarios.Text = sbHorarios.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró la información del complejo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
