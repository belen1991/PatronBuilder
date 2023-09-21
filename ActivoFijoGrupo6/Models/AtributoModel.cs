using ActivoFijoGrupo6.Interfaces;

namespace ActivoFijoGrupo6.Models
{
    public class AtributoModel
    {
      public string Nombre { get; private set; }
      public string Valor { get; private set; }

      public AtributoModel() { }

      public class Builder : IAtributoBuilder
      {
        private AtributoModel atributo = new AtributoModel();

        public IAtributoBuilder SetNombre(string nombre)
        {
          atributo.Nombre = nombre;
          return this;
        }

        public IAtributoBuilder SetValor(string valor)
        {
          atributo.Valor = valor;
          return this;
        }
        
        public AtributoModel Build()
        {
          return atributo;
        }
      }
    }
}
