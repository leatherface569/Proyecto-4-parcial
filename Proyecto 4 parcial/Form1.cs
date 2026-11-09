using Proyecto_4_parcial.Negocio;
using Proyecto_4_parcial.Presentacion;
namespace Proyecto_4_parcial;
public partial class Form1 : Form
{
    private readonly TallerServicio negocio = new();
    private bool abriendoVentana;

    public Form1() { InitializeComponent(); }

    // Solo puede existir un módulo MDI abierto. La fábrica también queda dentro del try.
    private void Abrir(Func<Form> crearFormulario)
    {
        Form? formulario = null;
        try
        {
            var abierto = MdiChildren.FirstOrDefault();
            if (abierto != null)
            {
                abierto.Activate();
                return;
            }
            if (abriendoVentana) return;

            abriendoVentana = true;
            menuPrincipal.Enabled = false;
            formulario = crearFormulario();
            formulario.MdiParent = this;
            formulario.FormClosed += Formulario_FormClosed;
            formulario.Show();
        }
        catch (Exception ex)
        {
            formulario?.Dispose();
            MessageBox.Show(this, "No se pudo abrir la ventana. " + ex.Message,
                "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            abriendoVentana = false;
            ActualizarBloqueo();
        }
    }

    private void Formulario_FormClosed(object? sender, FormClosedEventArgs e)
    {
        // Al cerrarse el módulo se habilita de nuevo la navegación.
        if (sender is Form formulario) formulario.FormClosed -= Formulario_FormClosed;
        if (!IsDisposed && !Disposing)
            menuPrincipal.Enabled = !MdiChildren.Any(f => !ReferenceEquals(f, sender) && !f.IsDisposed);
    }

    private void ActualizarBloqueo()
    {
        menuPrincipal.Enabled = !MdiChildren.Any(f => !f.IsDisposed);
    }

    private void clientesMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmClientes(negocio));
    private void vehiculosMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmVehiculos(negocio));
    private void mecanicosMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmMecanicos(negocio));
    private void serviciosMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmServicios(negocio));
    private void refaccionesMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmRefacciones(negocio));
    private void ordenesMenu_Click(object? sender, EventArgs e) => Abrir(() => new FrmOrdenes(negocio));
}
