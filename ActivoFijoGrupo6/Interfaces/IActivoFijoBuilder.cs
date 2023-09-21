using ActivoFijoGrupo6.Models;

namespace ActivoFijoGrupo6.Interfaces
{
  public interface IActivoFijoBuilder
  {
    IActivoFijoBuilder SetCodigo(string codigo);
    IActivoFijoBuilder SetNombres(string nombres);
    IActivoFijoBuilder SetPrecio(double precio);
    IActivoFijoBuilder SetAtributoOpcional(string nombre, string valor);
    ActivoFijoModel Build();
  }
}
