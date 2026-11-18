using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_4_parcial.Presentacion
{
    public partial class ucCliente : UserControl
    {
        public ucCliente() { InitializeComponent(); }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Telefono
        {
            get { return txtTelefono.Text; }
            set { txtTelefono.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Correo
        {
            get { return txtCorreo.Text; }
            set { txtCorreo.Text = value; }
        }

        // Valida la captura antes de crear el objeto Cliente.
        public bool ValidarCampos()
        {
            bool correcto = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio.");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text.Length != 10)
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener 10 dígitos.");
                correcto = false;
            }
            else
            {
                foreach (char caracter in txtTelefono.Text)
                {
                    if (!char.IsDigit(caracter))
                    {
                        errorProvider1.SetError(txtTelefono, "El teléfono solo puede contener números.");
                        correcto = false;
                        break;
                    }
                }
            }
            if (txtCorreo.Text != "" && (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains(".")))
            {
                errorProvider1.SetError(txtCorreo, "El correo no es válido.");
                correcto = false;
            }
            return correcto;
        }

        public void Limpiar()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            errorProvider1.Clear();
        }
    }
}
