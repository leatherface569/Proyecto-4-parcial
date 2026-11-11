using Proyecto_4_parcial.Negocio;
using Proyecto_4_parcial.Presentacion;
namespace Proyecto_4_parcial;

public partial class Form1 : Form
{
    private readonly TallerServicio negocio = new();
    private bool abriendoVentana;

    public Form1()
    {
        InitializeComponent();
        var categorias = new ToolStripMenuItem("Categorías");
        categorias.Click += (_, _) => Abrir(() => new FrmCategorias(negocio));
        var inventario = new ToolStripMenuItem("Inventario");
        inventario.Click += (_, _) => Abrir(() => new FrmInventario(negocio));
        var consultas = new ToolStripMenuItem("Consultas");
        consultas.Click += (_, _) => Abrir(() => new FrmConsultas(negocio));
        var cambiar = new ToolStripMenuItem("Cambiar usuario");
        cambiar.Click += (_, _) => IniciarSesion();
        menuPrincipal.Items.AddRange(new ToolStripItem[] { categorias, inventario, consultas, cambiar });
        Shown += (_, _) => IniciarSesion();
    }

    private void IniciarSesion()
    {
        using var login = new FrmLogin();
        if (login.ShowDialog(this) != DialogResult.OK)
        {
            if (perfil == "") Close();
            return;
        }
        perfil = login.Perfil;
        foreach (Form formulario in MdiChildren) formulario.Close();
        foreach (ToolStripMenuItem opcion in menuPrincipal.Items)
            opcion.Visible = perfil == "Administrador" || opcion.Text == "Consultas" || opcion.Text == "Cambiar usuario";
        estadoLabel.Text = "Perfil: " + perfil + " | Datos temporales en memoria";
    }
    private string perfil = "";

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
