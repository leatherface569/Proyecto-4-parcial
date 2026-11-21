using Proyecto_4_parcial.Datos;
using Proyecto_4_parcial.Modelos;

namespace Proyecto_4_parcial.Negocio
{
    public class TallerServicio
    {
        private TallerDatos datos = new TallerDatos();

        public List<Cliente> ObtenerClientes()
        {
            return datos.MostrarClientes();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return datos.MostrarVehiculos();
        }

        // Cada validación lanza una excepción si la información es incorrecta.
        public void GuardarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("No se recibieron los datos del cliente.");
            }
            ValidarNombre(cliente.Nombre);
            ValidarTelefono(cliente.Telefono);
            ValidarCorreo(cliente.Correo);
            ValidarTelefonoDuplicado(cliente);
            datos.GuardarCliente(cliente);
        }

        public void GuardarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentException("No se recibieron los datos del vehículo.");
            }
            ValidarPropietario(vehiculo.ClienteId);
            ValidarTipo(vehiculo.Tipo);
            ValidarNumeroSerie(vehiculo.NumeroSerie);
            ValidarPlaca(vehiculo.Placa);
            ValidarMarca(vehiculo.Marca);
            ValidarModelo(vehiculo.Modelo);
            ValidarAnio(vehiculo.Anio);
            ValidarKilometraje(vehiculo.Kilometraje);
            ValidarPlacaDuplicada(vehiculo);
            ValidarSerieDuplicada(vehiculo);
            datos.GuardarVehiculo(vehiculo);
        }

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Escribe el nombre del cliente.");
            }
        }

        private void ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length != 10)
            {
                throw new ArgumentException("El teléfono debe tener 10 dígitos.");
            }
            foreach (char numero in telefono)
            {
                if (!char.IsDigit(numero))
                {
                    throw new ArgumentException("El teléfono solo puede contener números.");
                }
            }
        }

        private void ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException("El correo es obligatorio.");
            }
            if (!correo.Contains("@") || !correo.Contains("."))
            {
                throw new ArgumentException("El correo no es válido.");
            }
        }

        private void ValidarTelefonoDuplicado(Cliente cliente)
        {
            foreach (Cliente registrado in datos.MostrarClientes())
            {
                if (registrado.Id != cliente.Id && registrado.Telefono == cliente.Telefono)
                {
                    throw new ArgumentException("El teléfono ya está registrado.");
                }
            }
        }

        private void ValidarPropietario(int clienteId)
        {
            foreach (Cliente cliente in datos.MostrarClientes())
            {
                if (cliente.Id == clienteId)
                {
                    return;
                }
            }
            throw new ArgumentException("Selecciona un propietario registrado.");
        }

        private void ValidarTipo(string tipo)
        {
            if (tipo != "Automóvil" && tipo != "Motocicleta" && tipo != "Camioneta")
            {
                throw new ArgumentException("Selecciona el tipo de vehículo.");
            }
        }

        private void ValidarNumeroSerie(string serie)
        {
            if (string.IsNullOrWhiteSpace(serie) || serie.Length != 17)
            {
                throw new ArgumentException("El número de serie debe tener 17 caracteres.");
            }
        }

        private void ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa) || placa.Length < 5 || placa.Length > 10)
            {
                throw new ArgumentException("La placa debe tener entre 5 y 10 caracteres.");
            }
            string permitidos = "abcdefghijklmnopqrstuvwxyz0123456789-";
            foreach (char caracter in placa.ToLower())
            {
                if (!permitidos.Contains(caracter.ToString()))
                {
                    throw new ArgumentException("La placa solo admite letras, números o guiones.");
                }
            }
        }

        private void ValidarMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                throw new ArgumentException("Escribe la marca.");
            }
        }

        private void ValidarModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
            {
                throw new ArgumentException("Escribe el modelo.");
            }
        }

        private void ValidarAnio(int anio)
        {
            if (anio < 1900 || anio > DateTime.Today.Year + 1)
            {
                throw new ArgumentException("El año está fuera de rango.");
            }
        }

        private void ValidarKilometraje(int kilometraje)
        {
            if (kilometraje < 0)
            {
                throw new ArgumentException("El kilometraje no puede ser negativo.");
            }
        }

        private void ValidarPlacaDuplicada(Vehiculo vehiculo)
        {
            foreach (Vehiculo registrado in datos.MostrarVehiculos())
            {
                if (registrado.Id != vehiculo.Id && registrado.Placa.ToLower() == vehiculo.Placa.ToLower())
                {
                    throw new ArgumentException("La placa ya está registrada.");
                }
            }
        }

        private void ValidarSerieDuplicada(Vehiculo vehiculo)
        {
            foreach (Vehiculo registrado in datos.MostrarVehiculos())
            {
                if (registrado.Id != vehiculo.Id && registrado.NumeroSerie.ToLower() == vehiculo.NumeroSerie.ToLower())
                {
                    throw new ArgumentException("La serie ya está registrada.");
                }
            }
        }

        public void EliminarCliente(int id)
        {
            ValidarSeleccion(id, "cliente");
            ValidarClienteSinVehiculos(id);
            datos.EliminarCliente(id);
        }

        private void ValidarClienteSinVehiculos(int clienteId)
        {
            foreach (Vehiculo vehiculo in datos.MostrarVehiculos())
            {
                if (vehiculo.ClienteId == clienteId)
                {
                    throw new ArgumentException("Primero da de baja los vehículos de este cliente.");
                }
            }
        }

        public void EliminarVehiculo(int id)
        {
            ValidarSeleccion(id, "vehículo");
            datos.EliminarVehiculo(id);
        }
        private void ValidarSeleccion(int id, string registro)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Selecciona un " + registro + " en la tabla.");
            }
        }

        public Cliente ObtenerCliente(int id)
        {
            ValidarSeleccion(id, "cliente");
            return datos.ObtenerCliente(id);
        }

        public Vehiculo ObtenerVehiculo(int id)
        {
            ValidarSeleccion(id, "vehículo");
            return datos.ObtenerVehiculo(id);
        }

    }
}
