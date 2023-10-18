using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface ICityInfrastructure
    {
        CityDbModel CreateRecord(CityDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CityDbModel record);
        CityDbModel GetRecord(int recordId);
        IEnumerable<CityDbModel> GetAllRecords(string filter);

    }
}
