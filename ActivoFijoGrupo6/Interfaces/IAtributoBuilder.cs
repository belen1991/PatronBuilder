using ActivoFijoGrupo6.Models;

namespace ActivoFijoGrupo6.Interfaces
{
    public interface IAtributoBuilder
    {
      IAtributoBuilder SetNombre(string nombre);
      IAtributoBuilder SetValor(string valor);
      AtributoModel Build();
    }
}
