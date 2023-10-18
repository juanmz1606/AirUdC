using AirUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICountryApplication
    {
        CountryDTO CreateRecord(CountryDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CountryDTO record);
        CountryDTO GetRecord(int recordId);
        IEnumerable<CountryDTO> GetAllRecords(string filter);

    }
}
