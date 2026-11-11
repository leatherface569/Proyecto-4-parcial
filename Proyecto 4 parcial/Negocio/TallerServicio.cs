using Proyecto_4_parcial.Datos;
using Proyecto_4_parcial.Modelos;
using System.Text.RegularExpressions;

namespace Proyecto_4_parcial.Negocio
{
    public class TallerServicio
    {
        public Almacen Datos { get; } = new Almacen();

        public void Guardar<T>(T entidad, IRepositorio<T> repositorio) where T : Entidad
        {
            if (entidad is Cliente cliente)
            {
                Obligatorio(cliente.Nombre, "Nombre");
                if (!Regex.IsMatch(cliente.Telefono, @"^\d{10}$"))
                    throw new ValidacionException("Telefono", "Escribe un teléfono de 10 dígitos.");
                if (cliente.Correo != "" && !System.Net.Mail.MailAddress.TryCreate(cliente.Correo, out _))
                    throw new ValidacionException("Correo", "El correo no es válido.");
                if (Datos.Clientes.Todos().Any(c => c.Id != cliente.Id && c.Telefono == cliente.Telefono))
                    throw new ValidacionException("Telefono", "El teléfono ya está registrado.");
            }
            if (entidad is Mecanico mecanico)
            {
                Obligatorio(mecanico.Nombre, "Nombre");
                Obligatorio(mecanico.Especialidad, "Especialidad");
            }
            if (entidad is Categoria categoria)
            {
                Obligatorio(categoria.Nombre, "Nombre");
                if (Datos.Categorias.Todos().Any(c => c.Id != categoria.Id && c.Nombre.Equals(categoria.Nombre, StringComparison.OrdinalIgnoreCase)))
                    throw new ValidacionException("Nombre", "La categoría ya existe.");
            }
            if (entidad is Vehiculo vehiculo)
            {
                if (!Datos.Clientes.Todos().Any(c => c.Id == vehiculo.ClienteId))
                    throw new ValidacionException("ClienteId", "Selecciona un cliente.");
                Obligatorio(vehiculo.Marca, "Marca");
                Obligatorio(vehiculo.Modelo, "Modelo");
                if (!Regex.IsMatch(vehiculo.Placa, @"^[A-Za-z0-9-]{5,10}$"))
                    throw new ValidacionException("Placa", "Escribe una placa de 5 a 10 letras, números o guiones.");
                if (!Regex.IsMatch(vehiculo.NumeroSerie, @"^[A-HJ-NPR-Z0-9]{17}$", RegexOptions.IgnoreCase))
                    throw new ValidacionException("NumeroSerie", "La serie debe contener 17 caracteres VIN, sin I, O ni Q.");
                if (vehiculo.Anio < 1900 || vehiculo.Anio > DateTime.Today.Year + 1)
                    throw new ValidacionException("Anio", "El año está fuera de rango.");
                if (vehiculo.Kilometraje < 0) throw new ValidacionException("Kilometraje", "El kilometraje no puede ser negativo.");
                if (Datos.Vehiculos.Todos().Any(v => v.Id != vehiculo.Id && (v.Placa.Equals(vehiculo.Placa, StringComparison.OrdinalIgnoreCase) || v.NumeroSerie.Equals(vehiculo.NumeroSerie, StringComparison.OrdinalIgnoreCase))))
                    throw new ValidacionException("Placa", "La placa o la serie ya está registrada.");
                if (Datos.Ordenes.Todos().Any(o => o.VehiculoId == vehiculo.Id && o.ClienteId != vehiculo.ClienteId))
                    throw new ValidacionException("ClienteId", "No se puede cambiar el propietario de un vehículo con órdenes.");
                vehiculo.ValidarInformacion();
            }
            if (entidad is Servicio servicio)
            {
                Obligatorio(servicio.Nombre, "Nombre");
                Obligatorio(servicio.Descripcion, "Descripcion");
                if (servicio.Precio <= 0) throw new ValidacionException("Precio", "El precio debe ser mayor a cero.");
                if (servicio.DuracionMinutos <= 0) throw new ValidacionException("DuracionMinutos", "La duración debe ser mayor a cero.");
            }
            if (entidad is Refaccion refaccion)
            {
                Obligatorio(refaccion.Nombre, "Nombre");
                if (!Datos.Categorias.Todos().Any(c => c.Id == refaccion.CategoriaId))
                    throw new ValidacionException("CategoriaId", "Selecciona una categoría.");
                if (refaccion.Precio <= 0) throw new ValidacionException("Precio", "El precio debe ser mayor a cero.");
                if (refaccion.Stock < 0 || refaccion.StockMinimo < 0)
                    throw new ValidacionException("Stock", "Las existencias no pueden ser negativas.");
                Refaccion? anterior = Datos.Refacciones.Todos().FirstOrDefault(r => r.Id == refaccion.Id);
                if (anterior != null && anterior.Stock != refaccion.Stock)
                    throw new ValidacionException("Stock", "Usa el módulo Inventario para registrar entradas o salidas.");
            }
            repositorio.Guardar(entidad);
        }

        private void Obligatorio(string texto, string campo)
        {
            if (string.IsNullOrWhiteSpace(texto)) throw new ValidacionException(campo, "Campo obligatorio.");
        }

        public void Eliminar<T>(T entidad, IRepositorio<T> repositorio) where T : Entidad
        {
            bool relacionado = false;
            if (entidad is Cliente) relacionado = Datos.Vehiculos.Todos().Any(v => v.ClienteId == entidad.Id);
            if (entidad is Vehiculo) relacionado = Datos.Ordenes.Todos().Any(o => o.VehiculoId == entidad.Id);
            if (entidad is Mecanico) relacionado = Datos.Ordenes.Todos().Any(o => o.MecanicoId == entidad.Id);
            if (entidad is Categoria) relacionado = Datos.Refacciones.Todos().Any(r => r.CategoriaId == entidad.Id);
            if (entidad is Servicio) relacionado = Datos.Ordenes.Todos().Any(o => o.Servicios.Any(s => s.ServicioId == entidad.Id));
            if (entidad is Refaccion) relacionado = Datos.Ordenes.Todos().Any(o => o.Refacciones.Any(r => r.RefaccionId == entidad.Id)) || Datos.Movimientos.Todos().Any(m => m.RefaccionId == entidad.Id);
            if (relacionado) throw new InvalidOperationException("El registro tiene relaciones; no se puede dar de baja.");
            repositorio.Eliminar(entidad.Id);
        }

        public OrdenServicio AbrirOrden(int vehiculoId, int mecanicoId, int kilometraje, string falla)
        {
            Vehiculo vehiculo = Datos.Vehiculos.Todos().FirstOrDefault(v => v.Id == vehiculoId)
                ?? throw new ValidacionException("VehiculoId", "Selecciona un vehículo.");
            Mecanico mecanico = Datos.Mecanicos.Todos().FirstOrDefault(m => m.Id == mecanicoId)
                ?? throw new ValidacionException("MecanicoId", "Selecciona un mecánico.");
            if (!mecanico.Disponible) throw new ValidacionException("MecanicoId", "El mecánico no está disponible.");
            if (Datos.Ordenes.Todos().Any(o => o.VehiculoId == vehiculoId && o.Estado != EstadoOrden.Entregada && o.Estado != EstadoOrden.Cancelada))
                throw new ValidacionException("VehiculoId", "El vehículo ya tiene una orden activa.");
            Obligatorio(falla, "Observaciones");
            if (kilometraje < vehiculo.Kilometraje) throw new ValidacionException("Kilometraje", "El kilometraje no puede ser menor al registrado.");
            OrdenServicio orden = new OrdenServicio { ClienteId = vehiculo.ClienteId, VehiculoId = vehiculoId, MecanicoId = mecanicoId, Kilometraje = kilometraje, Observaciones = falla.Trim() };
            orden.RegistrarEstado(EstadoOrden.Abierta);
            Datos.Ordenes.Guardar(orden);
            vehiculo.Kilometraje = kilometraje;
            return orden;
        }

        public void AgregarServicio(OrdenServicio orden, int servicioId)
        {
            ValidarEdicion(orden);
            Servicio servicio = Datos.Servicios.Todos().First(s => s.Id == servicioId);
            if (orden.Servicios.Any(s => s.ServicioId == servicioId)) throw new InvalidOperationException("El servicio ya está en la orden.");
            orden.AgregarServicio(new DetalleServicio(servicio.Id, servicio.Precio));
        }

        public void AgregarRefaccion(OrdenServicio orden, int refaccionId, int cantidad)
        {
            ValidarEdicion(orden);
            if (cantidad <= 0) throw new ValidacionException("Cantidad", "La cantidad debe ser mayor a cero.");
            Refaccion refaccion = Datos.Refacciones.Todos().First(r => r.Id == refaccionId);
            if (refaccion.Stock < cantidad) throw new StockInsuficienteException();
            orden.AgregarRefaccion(new DetalleRefaccion(refaccionId, cantidad, refaccion.Precio));
            MoverInventario(refaccionId, -cantidad, "Salida por orden " + orden.Id);
        }

        public void MoverInventario(int refaccionId, int cantidad, string motivo)
        {
            if (cantidad == 0) throw new ValidacionException("Cantidad", "La cantidad no puede ser cero.");
            Obligatorio(motivo, "Motivo");
            Refaccion refaccion = Datos.Refacciones.Todos().First(r => r.Id == refaccionId);
            if ((long)refaccion.Stock + cantidad < 0) throw new StockInsuficienteException();
            int nuevoStock = checked(refaccion.Stock + cantidad);
            Datos.Movimientos.Guardar(new MovimientoInventario { RefaccionId = refaccionId, Cantidad = cantidad, Motivo = motivo.Trim() });
            refaccion.Stock = nuevoStock;
        }

        public void CambiarEstado(OrdenServicio orden, EstadoOrden estado, string diagnostico)
        {
            bool permitido = (orden.Estado == EstadoOrden.Abierta && estado == EstadoOrden.Diagnosticada)
                || (orden.Estado == EstadoOrden.Diagnosticada && estado == EstadoOrden.Autorizada)
                || (orden.Estado == EstadoOrden.Autorizada && estado == EstadoOrden.EnProceso)
                || (orden.Estado == EstadoOrden.EnProceso && estado == EstadoOrden.Terminada)
                || (orden.Estado == EstadoOrden.Terminada && estado == EstadoOrden.Entregada);
            if (!permitido) throw new EstadoOrdenException();
            if (estado == EstadoOrden.Diagnosticada) Obligatorio(diagnostico, "Diagnostico");
            if (estado == EstadoOrden.Terminada && orden.Servicios.Count == 0) throw new InvalidOperationException("Agrega al menos un servicio antes de terminar.");
            if (estado == EstadoOrden.Entregada && orden.Saldo > 0) throw new InvalidOperationException("Liquida el saldo antes de entregar.");
            orden.Diagnostico = diagnostico.Trim();
            orden.RegistrarEstado(estado);
        }

        public void CancelarOrden(OrdenServicio orden)
        {
            if (orden.Estado == EstadoOrden.Cancelada || orden.Estado == EstadoOrden.Entregada || orden.Estado == EstadoOrden.Terminada)
                throw new EstadoOrdenException();
            if (orden.Pagado > 0) throw new InvalidOperationException("No se puede cancelar una orden con pagos registrados.");
            foreach (var grupo in orden.Refacciones.GroupBy(r => r.RefaccionId))
            {
                Refaccion refaccion = Datos.Refacciones.Todos().First(r => r.Id == grupo.Key);
                checked { _ = refaccion.Stock + grupo.Sum(r => r.Cantidad); }
            }
            foreach (DetalleRefaccion detalle in orden.Refacciones)
                MoverInventario(detalle.RefaccionId, detalle.Cantidad, "Devolución por cancelación de orden " + orden.Id);
            orden.RegistrarEstado(EstadoOrden.Cancelada);
        }

        public void RegistrarPago(OrdenServicio orden, decimal importe)
        {
            if (orden.Estado == EstadoOrden.Cancelada || orden.Estado == EstadoOrden.Entregada) throw new EstadoOrdenException();
            if (importe <= 0 || importe > orden.Saldo) throw new ValidacionException("Importe", "El importe debe ser mayor a cero y no superar el saldo.");
            orden.AgregarPago(importe);
        }

        private void ValidarEdicion(OrdenServicio orden)
        {
            if (orden.Estado != EstadoOrden.Autorizada && orden.Estado != EstadoOrden.EnProceso) throw new EstadoOrdenException();
        }
    }
}
