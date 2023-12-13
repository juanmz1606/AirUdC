﻿namespace AirUdC.Application.Contracts.DTO.Parameters
{
    public class PropertyDTO
    {
        public long Id { get; set; }
        public string PropertyAddress { get; set; }
        public int CustomerAmount { get; set; }
        public decimal Price { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CheckinData { get; set; }
        public string CheckoutData { get; set; }
        public string Details { get; set; }
        public bool Pets { get; set; }
        public bool Freezer { get; set; }
        public bool LaundryService { get; set; }
        public CityDTO City { get; set; }
        public PropertyOwnerDTO PropertyOwner { get; set; }

    }
}
