using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmClientes : FrmCatalogo<Cliente> {
 public FrmClientes(TallerServicio n) : base("Clientes",n,n.Datos.Clientes,()=>new Cliente()) { }
}