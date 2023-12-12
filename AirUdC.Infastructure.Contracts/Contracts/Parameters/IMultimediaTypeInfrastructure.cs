using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Infastructure.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeInfrastructure
    {
        MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDbModel record);
        MultimediaTypeDbModel GetRecord(int recordId);
        IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter);
    }
}
