using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmRefacciones : FrmCatalogo<Refaccion> {
 public FrmRefacciones(TallerServicio n) : base("Refacciones",n,n.Datos.Refacciones,()=>new Refaccion()) { }
}