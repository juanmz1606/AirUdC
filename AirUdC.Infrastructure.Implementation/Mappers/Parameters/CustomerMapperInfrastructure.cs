﻿using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System.Collections.Generic;


namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class CustomerMapperInfrastructure : BaseMapperInfrastructure<Customer, CustomerDbModel>
    {
        public override CustomerDbModel MapperT1toT2(Customer input)
        {
            return new CustomerDbModel()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT1toT2(IEnumerable<Customer> input)
        {
            IList<CustomerDbModel> list = new List<CustomerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Customer MapperT2toT1(CustomerDbModel input)
        {
            return new Customer
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo
            };
        }


        public override IEnumerable<Customer> MapperT2toT1(IEnumerable<CustomerDbModel> input)
        {
            IList<Customer> list = new List<Customer>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }

    }
}

