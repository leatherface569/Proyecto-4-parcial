using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmOrdenes : FrmCatalogo<OrdenServicio> {
 public FrmOrdenes(TallerServicio n) : base("Ordenes",n,n.Datos.Ordenes,()=>new OrdenServicio()) { }
}