# Referencias del estilo de programación

Se revisaron 18 repositorios públicos relacionados del perfil aldoo-ruizz.

- Ev-primer-parcial: btnMostrar_Click con Rows.Clear, foreach y Rows.Add; captura a través de ucActividad, ValidarCampos y Limpiar; clases Modelo/Datos/Negocio.
- Uso-de-UserControl: propiedades get/set para comunicar campos entre el formulario y el UserControl.
- excepciones: eventos con try, catch (Exception ex) y MessageBox.Show(ex.Message).
- productos-grid y datagridview: lista de objetos, altas, modificaciones, eliminación y navegación entre formularios.
- Ejecicio-dos-lista-objetos: búsquedas con ToLower().Contains().
- Sistema-de-Registro-de-Productos: lectura de campos con Trim().
- fechas: uso de DateTime.Today.

## Adaptaciones específicas del taller
Los nombres de las clases y campos, la relación cliente-vehículo, el VIN de 17 caracteres, las placas, los duplicados y la baja lógica son reglas del avance del taller. No son ejercicios copiados de esos repositorios. Se implementan con las mismas propiedades, listas, ciclos, condiciones y excepciones de los ejemplos.

La validación del correo es básica (Contains), como en Uso-de-UserControl; no se utiliza MailAddress.
Se conserva el proyecto de Windows Forms en .NET 10 que ya estaba abierto; los repositorios de ejemplo utilizan versiones anteriores.

## Comportamiento del botón Mostrar
Mostrar llena la tabla con Rows.Clear + foreach + Rows.Add. Guardar registra o modifica, confirma y limpia la captura. Buscar filtra la tabla con un botón separado. Seleccionar una fila carga sus datos en el UserControl para modificar o dar de baja.

## Adición de compatibilidad avisada al usuario
DesignerSerializationVisibility.Hidden en las propiedades de los UserControl: requerido por el diseñador moderno de .NET 10 (WFO1000). No se encontró en los repositorios antiguos revisados; no cambia las validaciones ni los eventos.
