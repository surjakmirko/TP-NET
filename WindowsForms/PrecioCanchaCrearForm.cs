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
    public partial class PrecioCanchaCrearForm : Form
    {
        private readonly int _idComplejo;
        private readonly int _nroCancha;
        public PrecioCanchaCrearForm(int idComplejo, int nroCancha)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
            _nroCancha = nroCancha;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Now);

            // 1. Validar primero si ya existe un precio cargado hoy
            bool yaExistePrecioHoy = await ComplejoApiClient.FechaDesdeExistsAsync(_idComplejo, _nroCancha, hoy);

            if (yaExistePrecioHoy)
            {
                MessageBox.Show(
                    "Ya existe un precio registrado para la fecha de hoy. No se puede crear más de un precio por día para esta cancha.",
                    "Precio ya existente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            PrecioCrearDTO nuevoPrecio = new PrecioCrearDTO
            {
                PrecioBase = precioBase.Value,
                PrecioAdicional = precioAdicional.Value,
                PrecioSena = precioSeña.Value,
                FechaDesde = hoy
            };

            try
            {
                await ComplejoApiClient.CrearPrecioAsync(_idComplejo, _nroCancha, nuevoPrecio);

                MessageBox.Show($"¡El precio para la cancha número {_nroCancha} se creó con éxito!", "Precio Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el precio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
