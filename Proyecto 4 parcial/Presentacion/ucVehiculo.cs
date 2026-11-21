using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using Proyecto_4_parcial.Modelos;

namespace Proyecto_4_parcial.Presentacion
{
    public partial class ucVehiculo : UserControl
    {
        public ucVehiculo()
        {
            InitializeComponent();
            cmbTipo.Items.Add("Automóvil");
            cmbTipo.Items.Add("Motocicleta");
            cmbTipo.Items.Add("Camioneta");
            Limpiar();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ClienteId
        {
            get
            {
                if (cmbCliente.SelectedItem == null) return 0;
                Cliente cliente = (Cliente)cmbCliente.SelectedItem;
                return cliente.Id;
            }
            set
            {
                cmbCliente.SelectedIndex = -1;
                foreach (Cliente cliente in cmbCliente.Items)
                {
                    if (cliente.Id == value) cmbCliente.SelectedItem = cliente;
                }
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Tipo
        {
            get { return cmbTipo.Text; }
            set { cmbTipo.SelectedItem = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NumeroSerie
        {
            get { return txtSerie.Text.Trim(); }
            set { txtSerie.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Placa
        {
            get { return txtPlaca.Text; }
            set { txtPlaca.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Marca
        {
            get { return txtMarca.Text; }
            set { txtMarca.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Modelo
        {
            get { return txtModelo.Text; }
            set { txtModelo.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Anio
        {
            get { return txtAnio.Text; }
            set { txtAnio.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Kilometraje
        {
            get { return txtKilometraje.Text; }
            set { txtKilometraje.Text = value; }
        }

        public void CargarClientes(List<Cliente> clientes)
        {
            cmbCliente.Items.Clear();
            foreach (Cliente cliente in clientes) cmbCliente.Items.Add(cliente);
        }

        public bool ValidarCampos()
        {
            bool correcto = true;
            errorProvider1.Clear();
            if (cmbCliente.SelectedItem == null)
            {
                errorProvider1.SetError(cmbCliente, "Selecciona un propietario.");
                correcto = false;
            }
            if (cmbTipo.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbTipo, "Selecciona un tipo de vehículo.");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                errorProvider1.SetError(txtSerie, "El número de serie es obligatorio.");
                correcto = false;
            }
            else if (txtSerie.Text.Trim().Length != 17)
            {
                errorProvider1.SetError(txtSerie, "La serie debe tener 17 caracteres. Escribiste " + txtSerie.Text.Trim().Length + ".");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                errorProvider1.SetError(txtPlaca, "La placa es obligatoria.");
                correcto = false;
            }
            else if (txtPlaca.Text.Trim().Length < 5 || txtPlaca.Text.Trim().Length > 10)
            {
                errorProvider1.SetError(txtPlaca, "La placa debe tener entre 5 y 10 caracteres.");
                correcto = false;
            }
            else
            {
                string permitidos = "abcdefghijklmnopqrstuvwxyz0123456789-";
                foreach (char caracter in txtPlaca.Text.Trim().ToLower())
                {
                    if (!permitidos.Contains(caracter.ToString()))
                    {
                        errorProvider1.SetError(txtPlaca, "La placa solo admite letras, números o guiones.");
                        correcto = false;
                        break;
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                errorProvider1.SetError(txtMarca, "La marca es obligatoria.");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "El modelo es obligatorio.");
                correcto = false;
            }
            int anio;
            if (txtAnio.Text.Length != 4 || !int.TryParse(txtAnio.Text, out anio))
            {
                errorProvider1.SetError(txtAnio, "El año debe tener 4 dígitos.");
                correcto = false;
            }
            else if (anio < 1900 || anio > DateTime.Today.Year + 1)
            {
                errorProvider1.SetError(txtAnio, "El año debe estar entre 1900 y " + (DateTime.Today.Year + 1) + ".");
                correcto = false;
            }
            int kilometraje;
            if (!int.TryParse(txtKilometraje.Text, out kilometraje))
            {
                errorProvider1.SetError(txtKilometraje, "El kilometraje debe ser un número entero.");
                correcto = false;
            }
            else if (kilometraje < 0)
            {
                errorProvider1.SetError(txtKilometraje, "El kilometraje no puede ser negativo.");
                correcto = false;
            }
            return correcto;
        }

        public bool ValidarDuplicados(List<Vehiculo> vehiculos, int idSeleccionado)
        {
            bool correcto = true;
            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (vehiculo.Id != idSeleccionado)
                {
                    if (vehiculo.NumeroSerie.ToLower() == txtSerie.Text.Trim().ToLower())
                    {
                        errorProvider1.SetError(txtSerie, "Este número de serie ya está registrado.");
                        correcto = false;
                    }
                    if (vehiculo.Placa.ToLower() == txtPlaca.Text.Trim().ToLower())
                    {
                        errorProvider1.SetError(txtPlaca, "Esta placa ya está registrada.");
                        correcto = false;
                    }
                }
            }
            return correcto;
        }

        public void Limpiar()
        {
            cmbCliente.SelectedIndex = -1;
            cmbTipo.SelectedIndex = 0;
            txtSerie.Clear();
            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtAnio.Text = DateTime.Today.Year.ToString();
            txtKilometraje.Text = "0";
            errorProvider1.Clear();
        }
    }
}
