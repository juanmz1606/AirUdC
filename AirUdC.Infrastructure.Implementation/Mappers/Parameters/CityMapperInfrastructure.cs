using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System;
using System.Collections.Generic;

namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class CityMapperInfrastructure : BaseMapperInfrastructure<City, CityDbModel>
    {
        public override CityDbModel MapperT1toT2(City input)
        {
            CountryMapperInfrastructure countryMapper = new CountryMapperInfrastructure();
            return new CityDbModel
            {
                Id = input.Id,
                Name = input.CityName,
                Country = countryMapper.MapperT1toT2(input.Country)
            };
        }

        public override IEnumerable<CityDbModel> MapperT1toT2(IEnumerable<City> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override City MapperT2toT1(CityDbModel input)
        {
            return new City
            {
                Id = input.Id,
                CityName = input.Name,
                Country = new CountryMapperInfrastructure().MapperT2toT1(input.Country)
            };
        }

        public override IEnumerable<City> MapperT2toT1(IEnumerable<CityDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
