﻿namespace AirUdC.Infastructure.Contracts.DbModel.Parameters
{
    public class PropertyDbModel
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
        public CityDbModel City { get; set; }
        public PropertyOwnerDbModel PropertyOwner { get; set; }
    }
}
