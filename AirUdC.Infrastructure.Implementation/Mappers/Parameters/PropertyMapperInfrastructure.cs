using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System.Collections.Generic;

namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class PropertyMapperInfrastructure: BaseMapperInfrastructure<Property, PropertyDbModel>
    {
        public override PropertyDbModel MapperT1toT2(Property input)
        {
            CityMapperInfrastructure cityMapper = new CityMapperInfrastructure();
            PropertyOwnerMapperInfrastructure propertyOwnerMapper = new PropertyOwnerMapperInfrastructure();
            return new PropertyDbModel
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                CustomerAmount = input.CustomerAmount,
                Price = input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService,
                City = cityMapper.MapperT1toT2(input.City),
                PropertyOwner = propertyOwnerMapper.MapperT1toT2(input.PropertyOwner)
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT1toT2(IEnumerable<Property> input)
        {
            IList<PropertyDbModel> list = new List<PropertyDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Property MapperT2toT1(PropertyDbModel input)
        {
            return new Property
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                CustomerAmount = input.CustomerAmount,
                Price = input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService,
                CityId = input.City.Id,
                OwnerId = input.PropertyOwner.Id
            };
        }

        public override IEnumerable<Property> MapperT2toT1(IEnumerable<PropertyDbModel> input)
        {
            IList<Property> list = new List<Property>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
