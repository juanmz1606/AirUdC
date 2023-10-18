using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface ICountryInfrastructure
    {
        CountryDbModel CreateRecord(CountryDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CountryDbModel record);
        CountryDbModel GetRecord(int recordId);
        IEnumerable<CountryDbModel> GetAllRecords(string filter);

    }
}
