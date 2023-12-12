using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class MultimediaTypeImplementationApplication : IMultimediaTypeApplication
    {
        IMultimediaTypeInfrastructure _multimediaTypeInfrastructure;
        public MultimediaTypeImplementationApplication(IMultimediaTypeInfrastructure multimediaTypeInfrastructure)
        {
            this._multimediaTypeInfrastructure = multimediaTypeInfrastructure;
        }
        public MultimediaTypeDTO CreateRecord(MultimediaTypeDTO record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapperT2toT1(record);
            MultimediaTypeDbModel created = this._multimediaTypeInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._multimediaTypeInfrastructure.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<MultimediaTypeDTO> GetAllRecords(string filter)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            IEnumerable<MultimediaTypeDbModel> records = this._multimediaTypeInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public MultimediaTypeDTO GetRecord(int recordId)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel record = this._multimediaTypeInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(MultimediaTypeDTO record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._multimediaTypeInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }
}
