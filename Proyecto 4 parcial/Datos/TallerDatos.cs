using Proyecto_4_parcial.Modelos;

namespace Proyecto_4_parcial.Datos
{
    public class TallerDatos
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Vehiculo> vehiculos = new List<Vehiculo>();
        private int siguienteCliente = 1;
        private int siguienteVehiculo = 1;

        public List<Cliente> MostrarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Activo) lista.Add(cliente);
            }
            return lista;
        }

        public List<Vehiculo> MostrarVehiculos()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (vehiculo.Activo) lista.Add(vehiculo);
            }
            return lista;
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("No se recibieron los datos del cliente.");
            }
            if (cliente.Id == 0)
            {
                cliente.Id = siguienteCliente++;
                clientes.Add(cliente);
            }
            else
            {
                int posicion = BuscarPosicionCliente(cliente.Id);
                clientes[posicion] = cliente;
            }
        }

        public void GuardarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentException("No se recibieron los datos del vehículo.");
            }
            if (vehiculo.Id == 0)
            {
                vehiculo.Id = siguienteVehiculo++;
                vehiculos.Add(vehiculo);
            }
            else
            {
                int posicion = BuscarPosicionVehiculo(vehiculo.Id);
                vehiculos[posicion] = vehiculo;
            }
        }

        private int BuscarPosicionCliente(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Id == id && clientes[i].Activo) return i;
            }
            throw new ArgumentException("El cliente no existe o ya fue dado de baja.");
        }

        private int BuscarPosicionVehiculo(int id)
        {
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].Id == id && vehiculos[i].Activo) return i;
            }
            throw new ArgumentException("El vehículo no existe o ya fue dado de baja.");
        }

        public Cliente ObtenerCliente(int id)
        {
            return clientes[BuscarPosicionCliente(id)];
        }

        public Vehiculo ObtenerVehiculo(int id)
        {
            return vehiculos[BuscarPosicionVehiculo(id)];
        }

        public void EliminarCliente(int id)
        {
            Cliente cliente = ObtenerCliente(id);
            cliente.Activo = false;
        }

        public void EliminarVehiculo(int id)
        {
            Vehiculo vehiculo = ObtenerVehiculo(id);
            vehiculo.Activo = false;
        }
    }
}
