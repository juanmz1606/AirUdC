using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;

namespace AirUdC.GUI.Mappers.Parameters
{
    public class PropertyMapperGUI : MapperBaseGUI<PropertyDTO, Property_Model>
    {
        public override Property_Model MapperT1toT2(PropertyDTO input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new Property_Model()
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

        public override IEnumerable<Property_Model> MapperT1toT2(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyDTO MapperT2toT1(Property_Model input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new PropertyDTO()
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
                City = cityMapper.MapperT2toT1(input.City),
                PropertyOwner = propertyOwnerMapper.MapperT2toT1(input.PropertyOwner)
            };
        }

        public override IEnumerable<PropertyDTO> MapperT2toT1(IEnumerable<Property_Model> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}