using AirUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICustomerApplication
    {
        CustomerDTO CreateRecord(CustomerDTO record);
        int DeleteRecord(long recordId);
        int UpdateRecord(CustomerDTO record);
        CustomerDTO GetRecord(long recordId);
        IEnumerable<CustomerDTO> GetAllRecords(string filter);

    }
}
