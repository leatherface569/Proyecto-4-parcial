# Avance: Sistema de Administración de Taller Mecánico

## Abrir y ejecutar
Abre Proyecto 4 parcial.slnx en Visual Studio con soporte para .NET 10 y desarrollo de escritorio de .NET. También puedes ejecutar `dotnet run --project "Proyecto 4 parcial.csproj"`.

## Incluido
- Formulario principal MDI y formularios Clientes, Vehículos, Mecánicos, Servicios, Refacciones y Órdenes.
- Captura, consulta en DataGridView, modificación y eliminación de catálogos; cancelación de órdenes.
- ErrorProvider para errores de captura y excepción personalizada ValidacionException.
- Relación cliente-vehículo y validación de las relaciones de las órdenes.
- Entidades, Datos, Negocio y Presentación separados en carpetas y namespaces dentro de un proyecto.
- Vehiculo abstracto con Automovil, Motocicleta y Camioneta; comportamiento polimórfico Describir().
- Detalles de servicios y refacciones con precios registrados y total calculado.
- Repositorio en memoria detrás de una interfaz reemplazable.

## Prueba manual
1. Registra un cliente, un mecánico, un servicio y una refacción.
2. Abre Vehículos y selecciona el tipo. Registra placa, marca, año y propietario.
3. Abre Órdenes, selecciona cliente, su vehículo, mecánico y al menos un servicio.
4. Guarda; selecciona la fila para modificarla o cancélala.
5. Prueba campos vacíos, placa repetida y un vehículo de otro propietario: se muestra ErrorProvider.
6. Intenta eliminar el cliente del vehículo: la regla de negocio impide romper la relación.

## Límites de este avance y siguientes pasos
Los datos viven únicamente mientras la aplicación está abierta. SQLite y Entity Framework Core aún NO están implementados. No se incluye una base de datos ni el documento técnico final. Este avance no es la entrega completa de la rúbrica.
Los formularios se crean por código: no incluyen archivos .Designer.cs ni diseño visual arrastrable. Las capas están en un mismo proyecto; se pueden extraer posteriormente a bibliotecas.
Las listas de selección se cargan al abrir cada formulario: cierra y vuelve a abrirlo después de modificar catálogos relacionados.
La selección de refacciones usa una unidad por refacción. Está pendiente agregar captura de cantidades y existencias, búsqueda/filtros, pruebas de interfaz y una edición de órdenes más detallada.
Se implementa la jerarquía de vehículos para el modelo; al editar un vehículo desde un catálogo de otro tipo se debe conservar su subtipo (la fábrica lo conserva al guardar).

## Clases principales
Entidades: Cliente, Mecanico, Vehiculo, Automovil, Motocicleta, Camioneta, Servicio, Refaccion, OrdenServicio, DetalleServicio y DetalleRefaccion.
Datos: IRepositorio<T>, RepositorioMemoria<T> y Almacen.
Negocio: TallerServicio y ValidacionException.
Presentación: Form1, FrmCatalogo<T>, FrmClientes, FrmVehiculos, FrmMecanicos, FrmServicios, FrmRefacciones y FrmOrdenes.

## Verificación realizada
Compilación con .NET SDK 10.0.402: 0 errores y 0 advertencias. Seis verificaciones de lógica aprobadas: campos obligatorios, placa duplicada, servicios obligatorios, total de orden, protección de relaciones y polimorfismo. La interfaz no se ha probado visualmente.


Integrado al proyecto existente. Form1 conserva su diseñador visual y funciona como contenedor MDI. Los módulos secundarios generan sus controles por código.
