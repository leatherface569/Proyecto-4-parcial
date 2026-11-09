namespace Proyecto_4_parcial.Entidades;
public abstract class Entidad { public int Id { get; set; } }
public class Cliente : Entidad { public string Nombre { get; set; } = ""; public string Telefono { get; set; } = ""; public string Correo { get; set; } = ""; public override string ToString() => Nombre; }
public class Mecanico : Entidad { public string Nombre { get; set; } = ""; public string Especialidad { get; set; } = ""; public override string ToString() => Nombre; }
public abstract class Vehiculo : Entidad {
 public int ClienteId { get; set; } public string Placa { get; set; } = ""; public string Marca { get; set; } = ""; public int Anio { get; set; } = DateTime.Today.Year;
 public abstract string Tipo { get; } public abstract string Describir();
 public override string ToString() => $"{Placa} - {Marca} ({Tipo})";
}
public class Automovil : Vehiculo { public override string Tipo => "Automóvil"; public override string Describir() => $"Automóvil {Marca}, placa {Placa}"; }
public class Motocicleta : Vehiculo { public override string Tipo => "Motocicleta"; public override string Describir() => $"Motocicleta {Marca}, placa {Placa}"; }
public class Camioneta : Vehiculo { public override string Tipo => "Camioneta"; public override string Describir() => $"Camioneta {Marca}, placa {Placa}"; }
public class Servicio : Entidad { public string Nombre { get; set; } = ""; public decimal Precio { get; set; } public override string ToString() => $"{Nombre} (${Precio:N2})"; }
public class Refaccion : Entidad { public string Nombre { get; set; } = ""; public decimal Precio { get; set; } public override string ToString() => $"{Nombre} (${Precio:N2})"; }
public enum EstadoOrden { Abierta, EnProceso, Terminada, Cancelada }
public class DetalleServicio { public int ServicioId { get; set; } public decimal Precio { get; set; } }
public class DetalleRefaccion { public int RefaccionId { get; set; } public int Cantidad { get; set; } public decimal Precio { get; set; } public decimal Subtotal => Cantidad * Precio; }
public class OrdenServicio : Entidad {
 public int ClienteId { get; set; } public int VehiculoId { get; set; } public int MecanicoId { get; set; }
 public DateTime Fecha { get; set; } = DateTime.Now; public string Observaciones { get; set; } = "";
 public EstadoOrden Estado { get; set; } = EstadoOrden.Abierta;
 public List<DetalleServicio> Servicios { get; set; } = new(); public List<DetalleRefaccion> Refacciones { get; set; } = new();
 public decimal Total => Servicios.Sum(x => x.Precio) + Refacciones.Sum(x => x.Subtotal);
}