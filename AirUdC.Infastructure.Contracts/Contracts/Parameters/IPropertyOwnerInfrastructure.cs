using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerInfrastructure
    {
        PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record);
        int DeleteRecord(long recordId);
        int UpdateRecord(PropertyOwnerDbModel record);
        PropertyOwnerDbModel GetRecord(long recordId);
        IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter);
    }
}
