using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmServicios : FrmCatalogo<Servicio> {
 public FrmServicios(TallerServicio n) : base("Servicios",n,n.Datos.Servicios,()=>new Servicio()) { }
}