using AirUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerApplication
    {
        PropertyOwnerDTO CreateRecord(PropertyOwnerDTO record);
        int DeleteRecord(long recordId);
        int UpdateRecord(PropertyOwnerDTO record);
        PropertyOwnerDTO GetRecord(int recordId);
        IEnumerable<PropertyOwnerDTO> GetAllRecords(string filter);
    }
}
