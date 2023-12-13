using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface IPropertyInfrastructure
    {
        PropertyDbModel CreateRecord(PropertyDbModel record);
        int DeleteRecord(long recordId);
        int UpdateRecord(PropertyDbModel record);
        PropertyDbModel GetRecord(long recordId);
        IEnumerable<PropertyDbModel> GetAllRecords(string filter);
        IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(long propertyOwnerId);
    }
}
