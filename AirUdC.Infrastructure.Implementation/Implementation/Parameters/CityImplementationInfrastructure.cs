using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class CityImplementationInfrastructure : ICityInfrastructure
    {
        /// <summary>
        /// Metodo para crear un registro de City en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no.
        /// O una excepcion</returns>
        public CityDbModel CreateRecord(CityDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (db.City.Where(x => x.CityName.Equals(record.Name)).Count() == 0)
                    {
                        CityMapperInfrastructure mapper = new CityMapperInfrastructure();
                        City dbRecord = mapper.MapperT2toT1(record);
                        db.City.Add(dbRecord);
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
        /// Metodo para eliminar un registro de City en la base de datos
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
                    City record = db.City.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.City.Remove(record);
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
                throw e;
            }
        }

        /// <summary>
        /// Metodo para obtener todos los registros de City en la base de datos
        /// </summary>
        /// <returns>Listado de registros con paises</returns>
        public IEnumerable<CityDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.City
                    where c.CityName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.City.Where(x => x.CityName.Contains(filter));


                //Programacion blanda
                CityMapperInfrastructure mapper = new CityMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public CityDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                var record = db.City.Find(recordId);


                //Programacion blanda
                CityMapperInfrastructure mapper = new CityMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int UpdateRecord(CityDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    CityMapperInfrastructure mapper = new CityMapperInfrastructure();
                    City dbRecord = mapper.MapperT2toT1(record);
                    db.City.Attach(dbRecord);
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
