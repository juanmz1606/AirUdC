﻿using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Parameters
{
    public class CustomerMapperGUI : MapperBaseGUI<CustomerDTO, CustomerModel>
    {
        public override CustomerModel MapperT1toT2(CustomerDTO input)
        {
            return new CustomerModel()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<CustomerModel> MapperT1toT2(IEnumerable<CustomerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CustomerDTO MapperT2toT1(CustomerModel input)
        {
            return new CustomerDTO()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };

        }

        public override IEnumerable<CustomerDTO> MapperT2toT1(IEnumerable<CustomerModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
