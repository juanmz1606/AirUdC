﻿using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Mappers.Parameters
{
    public class CountryMapperApplication : MapperBaseApplication<CountryDbModel, CountryDTO>
    {
        public override CountryDTO MapperT1toT2(CountryDbModel input)
        {
            return new CountryDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDTO> MapperT1toT2(IEnumerable<CountryDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CountryDbModel MapperT2toT1(CountryDTO input)
        {
            return new CountryDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDbModel> MapperT2toT1(IEnumerable<CountryDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
