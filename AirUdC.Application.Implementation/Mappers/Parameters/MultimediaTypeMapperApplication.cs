﻿using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Mappers.Parameters
{
    public class MultimediaTypeMapperApplication : MapperBaseApplication<MultimediaTypeDbModel, MultimediaTypeDTO>
    {
        public override MultimediaTypeDTO MapperT1toT2(MultimediaTypeDbModel input)
        {
            return new MultimediaTypeDTO()
            {
                Id = input.Id,
                MultimediaTypeName = input.MultimediaTypeName
            };
        }

        public override IEnumerable<MultimediaTypeDTO> MapperT1toT2(IEnumerable<MultimediaTypeDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override MultimediaTypeDbModel MapperT2toT1(MultimediaTypeDTO input)
        {
            return new MultimediaTypeDbModel()
            {
                Id = input.Id,
                MultimediaTypeName = input.MultimediaTypeName
            };
        }

        public override IEnumerable<MultimediaTypeDbModel> MapperT2toT1(IEnumerable<MultimediaTypeDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
