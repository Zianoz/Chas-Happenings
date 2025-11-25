using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    internal static class GenericDTOmapper
    {
        public static void Mapper<Tmodel, Tdto>(Tmodel model, Tdto dto) where Tmodel : class where Tdto : class
        {
            var modelFieldsList = typeof(Tmodel).GetProperties();
            var dtoFieldsList = typeof(Tdto).GetProperties();

            foreach (var fieldProperty in modelFieldsList)
            {
                var modelPropertyValue = fieldProperty.GetValue(model);

                if (modelPropertyValue == null)
                {
                    continue;
                }

                var dtoFieldproperty = dtoFieldsList.FirstOrDefault(f => f.Name == fieldProperty.Name);

                if (dtoFieldproperty == null)
                {
                    continue;
                }

                if (dtoFieldproperty.PropertyType.IsInstanceOfType(modelPropertyValue))
                {
                    dtoFieldproperty.SetValue(dto, modelPropertyValue);
                }
            }
        }
    }
}
