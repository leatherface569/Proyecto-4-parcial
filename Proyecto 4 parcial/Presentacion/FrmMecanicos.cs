using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmMecanicos : FrmCatalogo<Mecanico> {
 public FrmMecanicos(TallerServicio n) : base("Mecanicos",n,n.Datos.Mecanicos,()=>new Mecanico()) { }
}