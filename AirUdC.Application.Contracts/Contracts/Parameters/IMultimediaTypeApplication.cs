using AirUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeApplication
    {
        MultimediaTypeDTO CreateRecord(MultimediaTypeDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDTO record);
        MultimediaTypeDTO GetRecord(int recordId);
        IEnumerable<MultimediaTypeDTO> GetAllRecords(string filter);

    }
}
