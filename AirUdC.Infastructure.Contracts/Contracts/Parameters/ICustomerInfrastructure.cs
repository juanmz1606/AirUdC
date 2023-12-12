using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface ICustomerInfrastructure
    {
        CustomerDbModel CreateRecord(CustomerDbModel record);
        int DeleteRecord(long recordId);
        int UpdateRecord(CustomerDbModel record);
        CustomerDbModel GetRecord(long recordId);
        IEnumerable<CustomerDbModel> GetAllRecords(string filter);
    }
}

