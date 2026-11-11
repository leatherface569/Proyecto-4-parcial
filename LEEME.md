# Avance del taller mecanico

Abrir Proyecto 4 parcial.slnx en Visual Studio con .NET 10 y Windows Forms.
Ejecutar con F5. Cuenta de demostracion: admin / demo123.

Carpetas:
- Modelos: clases con propiedades y constructores con parametros.
- Datos: listas en memoria para registrar y consultar.
- Negocio: validaciones, ordenes, servicios e inventario.
- Presentacion: formularios de Windows Forms.

Referencia de estilo: https://github.com/aldoo-ruizz/Ev-primer-parcial
Se adaptaron las clases con constructores, herencia y metodos de validacion.
Ejemplo: Cliente cliente = new Cliente(0, "Ana", "5512345678", "ana@example.com");
Automovil, Motocicleta y Camioneta heredan de Vehiculo y llaman su constructor base.
Los constructores vacios permiten crear y limpiar registros en los formularios.

Este avance permite administrar clientes, vehiculos, mecanicos, servicios,
categorias, refacciones, ordenes, pagos e inventario.

ALCANCE DE LOS DATOS
Los registros se guardan en memoria y se pierden al cerrar la aplicacion,
como en el repositorio de referencia. La aplicacion todavia no se conecta
con SQL Server. Los scripts SQL son un avance separado de base de datos;
los nombres y estados de la aplicacion deberan mapearse al integrar SQL.
Para revisar la base en SSMS: ejecutar BaseDatos/01_Tablas.sql y despues
BaseDatos/02_DatosPrueba.sql, una sola vez sobre tablas nuevas y vacias.

Validacion: compilacion con 0 errores y 0 advertencias.
27 pruebas existentes correctas de negocio y construccion de formularios.
No se ha realizado una revision visual de todas las pantallas en esta entrega.
