using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System.Collections.Generic;

namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class PropertyOwnerMapperInfrastructure: BaseMapperInfrastructure<PropertyOwner, PropertyOwnerDbModel>
    {
        public override PropertyOwnerDbModel MapperT1toT2(PropertyOwner input)
        {
            return new PropertyOwnerDbModel()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT1toT2(IEnumerable<PropertyOwner> input)
        {
            IList<PropertyOwnerDbModel> list = new List<PropertyOwnerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override PropertyOwner MapperT2toT1(PropertyOwnerDbModel input)
        {
            return new PropertyOwner
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<PropertyOwner> MapperT2toT1(IEnumerable<PropertyOwnerDbModel> input)
        {
            IList<PropertyOwner> list = new List<PropertyOwner>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
