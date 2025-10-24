using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    internal class GenericDTOmapper
    {
        public static void Mapper<Tmodel, Tdto>(Tmodel model, Tdto dto) where Tmodel : class where Tdto : class
        {
            var modelFeildsList = typeof(Tmodel).GetProperties();
            var dtoFeildsList = typeof(Tdto).GetProperties();

            foreach (var feildProperty in modelFeildsList)
            {
                var modelPropertyValue = feildProperty.GetValue(model);

                if (modelPropertyValue == null)
                {
                    continue;
                }

                var dtoFeildproperty = dtoFeildsList.FirstOrDefault(f => f.Name == feildProperty.Name);

                if (dtoFeildproperty == null)
                {
                    continue;
                }

                if (dtoFeildproperty.PropertyType.IsInstanceOfType(modelPropertyValue))
                {
                    dtoFeildproperty.SetValue(dto, modelPropertyValue);
                }
            }
        }
    }
}
