using ActivoFijoGrupo6.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ActivoFijoGrupo6.Models
{
    public class ActivoFijoModel
    {
      public string Codigo { get; private set; }
      public string Nombres { get; private set; }
      public double Precio { get; private set; }
      public List<AtributoModel> Atributos { get; private set;}

      
      private ActivoFijoModel()
      {
      }

      public class Builder : IActivoFijoBuilder
      {
        private ActivoFijoModel activoFijo = new ActivoFijoModel();

        public IActivoFijoBuilder SetCodigo(string codigo)
        {
          activoFijo.Codigo = codigo;
          return this;
        }

        public IActivoFijoBuilder SetNombres(string nombres)
        {
          activoFijo.Nombres = nombres;
          return this;
        }

        public IActivoFijoBuilder SetPrecio(double precio)
        {
          activoFijo.Precio = precio;
          return this;
        }

        public IActivoFijoBuilder SetAtributoOpcional(string nombre, string valor)
        {
          if(activoFijo.Atributos == null) 
            activoFijo.Atributos= new List<AtributoModel>();
          
          activoFijo.Atributos.Add(
              new AtributoModel.Builder()
                .SetNombre(nombre)
                .SetValor(valor)
                .Build());
          return this;
        }

        public ActivoFijoModel Build()
        {
          if(activoFijo.Atributos == null) 
            activoFijo.Atributos= new List<AtributoModel>();
          return activoFijo;
        }      

      }
    }
}
