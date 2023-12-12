using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class MultimediaTypeImplementationInfrastructure : IMultimediaTypeInfrastructure
    {
        /// <summary>
        /// Metodo para crear un registro de MultimediaType en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no.
        /// O una excepcion</returns>
        public MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.MultimediaType.Any(x => x.MultimediaTypeName.Equals(record.MultimediaTypeName)))
                    {
                        MultimediaTypeMapperInfrastructure mapper = new MultimediaTypeMapperInfrastructure();
                        MultimediaType dbRecord = mapper.MapperT2toT1(record);
                        db.MultimediaType.Add(dbRecord);
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
        /// Metodo para eliminar un registro de MultimediaType en la base de datos
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
                    MultimediaType record = db.MultimediaType.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.MultimediaType.Remove(record);
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
        /// Metodo para obtener todos los registros de MultimediaType en la base de datos
        /// </summary>
        /// <returns>Listado de registros con paises</returns>
        public IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.MultimediaType
                    where c.MultimediaTypeName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.MultimediaType.Where(x => x.MultimediaTypeName.Contains(filter));


                //Programacion blanda
                MultimediaTypeMapperInfrastructure mapper = new MultimediaTypeMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public MultimediaTypeDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                var record = db.MultimediaType.Find(recordId);


                //Programacion blanda
                MultimediaTypeMapperInfrastructure mapper = new MultimediaTypeMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }
        /// <summary>
        /// Metodo para actualizar un registro de MultimediaType en la base de datos
        /// </summary>
        /// <param name="record">Registro con datos nuevos</param>
        /// <returns></returns>
        public int UpdateRecord(MultimediaTypeDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    MultimediaTypeMapperInfrastructure mapper = new MultimediaTypeMapperInfrastructure();
                    MultimediaType dbRecord = mapper.MapperT2toT1(record);
                    db.MultimediaType.Attach(dbRecord);
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
