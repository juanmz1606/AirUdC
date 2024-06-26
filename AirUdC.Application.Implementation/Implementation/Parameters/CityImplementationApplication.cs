﻿using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class CityImplementationApplication : ICityApplication
    {
        ICityInfrastructure _cityInfrastructure;
        public CityImplementationApplication(ICityInfrastructure cityInfrastructure)
        {
            this._cityInfrastructure = cityInfrastructure;
        }
        /// <summary>
        /// Metodo que crea un registro de ciudad
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public CityDTO CreateRecord(CityDTO record)
        {
            CityMapperApplication mapper = new CityMapperApplication();
            CityDbModel mapped = mapper.MapperT2toT1(record);
            CityDbModel created = this._cityInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }
        /// <summary>
        /// Metodo que elimina un registro de ciudad
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public int DeleteRecord(int recordId)
        {
            int deleted = this._cityInfrastructure.DeleteRecord(recordId);
            return deleted;
        }
        /// <summary>
        /// Metodo que obtiene todos los registros de ciudad
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<CityDTO> GetAllRecords(string filter)
        {
            CityMapperApplication mapper = new CityMapperApplication();
            IEnumerable<CityDbModel> records = this._cityInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }
        /// <summary>
        /// Metodo que obtiene todos los registros de ciudad por id de pais
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public IEnumerable<CityDTO> GetAllRecordsByCountryId(int countryId)
        {
            CityMapperApplication mapper = new CityMapperApplication();
            IEnumerable<CityDbModel> records = 
                    this._cityInfrastructure.GetAllRecordsByCountryId(countryId);
            return mapper.MapperT1toT2(records);
        }
        /// <summary>
        /// Metodo que obtiene un registro de ciudad por id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public CityDTO GetRecord(int recordId)
        {
            CityMapperApplication mapper = new CityMapperApplication();
            CityDbModel record = this._cityInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }
        /// <summary>
        /// Metodo que actualiza un registro de ciudad
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int UpdateRecord(CityDTO record)
        {
            CityMapperApplication mapper = new CityMapperApplication();
            CityDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._cityInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }
}
