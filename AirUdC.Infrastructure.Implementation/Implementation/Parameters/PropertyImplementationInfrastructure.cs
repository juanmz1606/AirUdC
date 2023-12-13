using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class PropertyImplementationInfrastructure: IPropertyInfrastructure
    {
        /// <summary>
        /// Metodo para crear un registro de Property en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no.
        /// O una excepcion</returns>
        public PropertyDbModel CreateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Property.Any(x => x.PropertyAddress.Equals(record.PropertyAddress)))
                    {
                        PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                        Property dbRecord = mapper.MapperT2toT1(record);
                        db.Property.Add(dbRecord);
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
        /// Metodo para eliminar un registro de Property en la base de datos
        /// </summary>
        /// <param name="recordId">Id del registro a eliminar</param>
        /// <returns>1 cuando se elimina, 0 cuando no existe, o excepcion</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int DeleteRecord(long recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    Property record = db.Property.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Property.Remove(record);
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
        /// Metodo para obtener todos los registros de Property en la base de datos
        /// </summary>
        /// <returns>Listado de registros con paises</returns>
        public IEnumerable<PropertyDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.Property
                    where c.PropertyAddress.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Property.Where(x => x.PropertyName.Contains(filter));


                //Programacion blanda
                PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }
        /// <summary>
        /// Metodo para obtener todos los registros de Property en la base de datos por Id de ciudad
        /// </summary>
        /// <param name="cityId">Id de la propiedad</param>
        /// <returns>Lista de propiedades</returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.Property
                               where c.CityId == cityId
                               select c);

                PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener todos los registros de Property en la base de datos por Id de propietario
        /// </summary>
        /// <param name="propertyOwnerId">Id del pais</param>
        /// <returns>Lista de ciudades</returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(long propertyOwnerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.Property
                               where c.OwnerId == propertyOwnerId
                               select c);

                PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public PropertyDbModel GetRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                var record = db.Property.Find(recordId);


                //Programacion blanda
                PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int UpdateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyMapperInfrastructure mapper = new PropertyMapperInfrastructure();
                    Property dbRecord = mapper.MapperT2toT1(record);
                    db.Property.Attach(dbRecord);
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
