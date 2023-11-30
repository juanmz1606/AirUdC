using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class PropertyOwnerImplementationApplication : IPropertyOwnerApplication
    {
        IPropertyOwnerInfrastructure _propertyOwnerInfrastructure;
        public PropertyOwnerImplementationApplication(IPropertyOwnerInfrastructure propertyOwnerInfrastructure)
        {
            this._propertyOwnerInfrastructure = propertyOwnerInfrastructure;
        }
        public PropertyOwnerDTO CreateRecord(PropertyOwnerDTO record)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel mapped = mapper.MapperT2toT1(record);
            PropertyOwnerDbModel created = this._propertyOwnerInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(long recordId)
        {
            int deleted = this._propertyOwnerInfrastructure.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyOwnerDTO> GetAllRecords(string filter)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            IEnumerable<PropertyOwnerDbModel> records = this._propertyOwnerInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public PropertyOwnerDTO GetRecord(int recordId)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel record = this._propertyOwnerInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyOwnerDTO record)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._propertyOwnerInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }
}
