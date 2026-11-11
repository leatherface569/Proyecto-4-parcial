namespace Proyecto_4_parcial.Entidades
{
    public class OrdenServicio : Entidad
    {
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int MecanicoId { get; set; }
        public int Kilometraje { get; set; }
        public DateTime Fecha { get; private set; } = DateTime.Now;
        public string Observaciones { get; set; } = "";
        public string Diagnostico { get; internal set; } = "";
        public EstadoOrden Estado { get; internal set; } = EstadoOrden.Abierta;
        private readonly List<DetalleServicio> servicios = new List<DetalleServicio>();
        private readonly List<DetalleRefaccion> refacciones = new List<DetalleRefaccion>();
        private readonly List<CambioEstado> historial = new List<CambioEstado>();
        private readonly List<Pago> pagos = new List<Pago>();
        public IReadOnlyList<DetalleServicio> Servicios { get { return servicios.AsReadOnly(); } }
        public IReadOnlyList<DetalleRefaccion> Refacciones { get { return refacciones.AsReadOnly(); } }
        public IReadOnlyList<CambioEstado> Historial { get { return historial.AsReadOnly(); } }
        public IReadOnlyList<Pago> Pagos { get { return pagos.AsReadOnly(); } }
        public decimal Total { get { return servicios.Sum(s => s.Precio) + refacciones.Sum(r => r.Subtotal); } }
        public decimal Pagado { get { return pagos.Sum(p => p.Importe); } }
        public decimal Saldo { get { return Total - Pagado; } }
        internal void AgregarServicio(DetalleServicio detalle) { servicios.Add(detalle); }
        internal void AgregarRefaccion(DetalleRefaccion detalle) { refacciones.Add(detalle); }
        internal void AgregarPago(decimal importe) { pagos.Add(new Pago { Importe = importe }); }
        internal void RegistrarEstado(EstadoOrden estado)
        {
            Estado = estado;
            historial.Add(new CambioEstado { Estado = estado });
        }
    }
}
