using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using DTOs;

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
            _ = CargarDetallesDelComplejoAsync();
        }

        private async Task CargarDetallesDelComplejoAsync()
        {
            try
            {
                // 1. Obtenemos el complejo a través de la WebAPI
                var complejo = await ComplejoApiClient.ObtenerPorIdAsync(_idComplejoSeleccionado);

                if (complejo != null)
                {
                    lblNombre.Text = $"Nombre: {complejo.Nombre}";
                    lblDireccion.Text = $"Dirección: {complejo.Direccion}";

                    // 2. Obtenemos la localidad mediante su API Client
                    var localidad = await LocalidadApiClient.ObtenerPorIdAsync(complejo.LocalidadId);
                    lblLocalidad.Text = $"Localidad: {localidad?.Nombre ?? "Desconocida"}";

                    var horarios = await ComplejoApiClient.ObtenerHorariosAsync(complejo.Id);
                    // 3. Respetando tu estructura original de horarios y días
                    StringBuilder sbHorarios = new StringBuilder();
                    if(horarios != null && horarios.Count > 0)
                    {
                        foreach (var h in horarios)
                        {
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