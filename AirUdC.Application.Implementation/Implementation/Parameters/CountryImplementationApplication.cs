using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.Implementation.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class CountryImplementationApplication : ICountryApplication
    {
        ICountryInfrastructure _countryInfrastructure;
        public CountryImplementationApplication()
        {
            this._countryInfrastructure = new CountryImplementationInfrastructure();
        }
        public CountryDTO CreateRecord(CountryDTO record)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel mapped = mapper.MapperT2toT1(record);
            CountryDbModel created = this._countryInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._countryInfrastructure.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<CountryDTO> GetAllRecords(string filter)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            IEnumerable<CountryDbModel> records = this._countryInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public CountryDTO GetRecord(int recordId)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel record = this._countryInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(CountryDTO record)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._countryInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }
}
