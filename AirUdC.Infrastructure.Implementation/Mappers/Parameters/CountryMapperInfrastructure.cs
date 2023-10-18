using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System;
using System.Collections.Generic;

namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class CountryMapperInfrastructure : BaseMapperInfrastructure<Country, CountryDbModel>
    {
        public override CountryDbModel MapperT1toT2(Country input)
        {
            return new CountryDbModel()
            {
                Id = input.Id,
                Name = input.CountryName
            };
        }

        public override IEnumerable<CountryDbModel> MapperT1toT2(IEnumerable<Country> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override Country MapperT2toT1(CountryDbModel input)
        {
                return new Country
                {
                    Id = input.Id, 
                    CountryName = input.Name 
                };
        }

        public override IEnumerable<Country> MapperT2toT1(IEnumerable<CountryDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
