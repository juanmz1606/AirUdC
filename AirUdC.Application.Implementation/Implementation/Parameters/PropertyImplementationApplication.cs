using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class PropertyImplementationApplication : IPropertyApplication
    {
        IPropertyInfrastructure _propertyInfrastructure;
        public PropertyImplementationApplication(IPropertyInfrastructure propertyInfrastructure)
        {
            this._propertyInfrastructure = propertyInfrastructure;
        }
        public PropertyDTO CreateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            PropertyDbModel created = this._propertyInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(long recordId)
        {
            int deleted = this._propertyInfrastructure.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyDTO> GetAllRecords(string filter)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._propertyInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records =
                    this._propertyInfrastructure.GetAllRecordsByCityId(cityId);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(long propertyOwnerId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records =
                    this._propertyInfrastructure.GetAllRecordsByPropertyOwnerId(propertyOwnerId);
            return mapper.MapperT1toT2(records);
        }

        public PropertyDTO GetRecord(long recordId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel record = this._propertyInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._propertyInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }
}
