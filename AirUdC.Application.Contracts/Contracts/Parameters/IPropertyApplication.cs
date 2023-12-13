using AirUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyApplication
    {
        PropertyDTO CreateRecord(PropertyDTO record);
        int DeleteRecord(long recordId);
        int UpdateRecord(PropertyDTO record);
        PropertyDTO GetRecord(long recordId);
        IEnumerable<PropertyDTO> GetAllRecords(string filter);
        IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(long propertyOwnerId);
    }
}
