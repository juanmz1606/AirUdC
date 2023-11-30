﻿using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Mappers.Parameters
{
    public class PropertyOwnerMapperApplication : MapperBaseApplication<PropertyOwnerDbModel, PropertyOwnerDTO>
    {
        public override PropertyOwnerDTO MapperT1toT2(PropertyOwnerDbModel input)
        {
            return new PropertyOwnerDTO()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<PropertyOwnerDTO> MapperT1toT2(IEnumerable<PropertyOwnerDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyOwnerDbModel MapperT2toT1(PropertyOwnerDTO input)
        {
            return new PropertyOwnerDbModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT2toT1(IEnumerable<PropertyOwnerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
