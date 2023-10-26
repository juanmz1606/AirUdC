using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Mappers;
using AirUdC.GUI.Models;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Mappers.Parameters
{
    public class CountryMapperGUI : MapperBaseGUI<CountryDTO,CountryModel>
    {
        public override CountryModel MapperT1toT2(CountryDTO input)
        {
            return new CountryModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryModel> MapperT1toT2(IEnumerable<CountryDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CountryDTO MapperT2toT1(CountryModel input)
        {
            return new CountryDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDTO> MapperT2toT1(IEnumerable<CountryModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
