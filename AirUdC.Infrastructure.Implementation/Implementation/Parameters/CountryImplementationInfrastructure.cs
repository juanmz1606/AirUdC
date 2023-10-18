using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class CountryImplementationInfrastructure : ICountryInfrastructure
    {
        /// <summary>
        /// Metodo para crear un registro de Country en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no.
        /// O una excepcion</returns>
        public CountryDbModel CreateRecord(CountryDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (db.Country.Where(x => x.CountryName.Equals(record.Name)).Count() == 0)
                    {
                        CountryMapperInfrastructure mapper = new CountryMapperInfrastructure();
                        Country dbRecord = mapper.MapperT2toT1(record);
                        db.Country.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return record;
        }

        /// <summary>
        /// Metodo para eliminar un registro de Country en la base de datos
        /// </summary>
        /// <param name="recordId">Id del registro a eliminar</param>
        /// <returns>1 cuando se elimina, 0 cuando no existe, o excepcion</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    Country record = db.Country.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Country.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                // Porque se tiene como llave foranea en otra tabla
                throw e;
            }
        }

        /// <summary>
        /// Metodo para obtener todos los registros de Country en la base de datos
        /// </summary>
        /// <returns>Listado de registros con paises</returns>
        public IEnumerable<CountryDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.Country
                    where c.CountryName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));


                //Programacion blanda
                CountryMapperInfrastructure mapper = new CountryMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public CountryDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                var record = db.Country.Find(recordId);


                //Programacion blanda
                CountryMapperInfrastructure mapper = new CountryMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }
        /// <summary>
        /// Metodo para actualizar un registro de Country en la base de datos
        /// </summary>
        /// <param name="record">Registro con datos nuevos</param>
        /// <returns></returns>
        public int UpdateRecord(CountryDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    CountryMapperInfrastructure mapper = new CountryMapperInfrastructure();
                    Country dbRecord = mapper.MapperT2toT1(record);
                    db.Country.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    } 
}
