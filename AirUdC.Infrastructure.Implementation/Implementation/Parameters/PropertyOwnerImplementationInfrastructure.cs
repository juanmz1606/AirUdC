using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class PropertyOwnerImplementationInfrastructure : IPropertyOwnerInfrastructure
    {
        public PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.PropertyOwner.Any(x => x.FirstName.Equals(record.FirstName)))
                    {
                        PropertyOwnerMapperInfrastructure mapper = new PropertyOwnerMapperInfrastructure();
                        PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                        db.PropertyOwner.Add(dbRecord);
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

        public int DeleteRecord(long recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwner record = db.PropertyOwner.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.PropertyOwner.Remove(record);
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

        public IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.PropertyOwner
                    where c.FirstName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));


                //Programacion blanda
                PropertyOwnerMapperInfrastructure mapper = new PropertyOwnerMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyOwnerDbModel GetRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                var record = db.PropertyOwner.Find(recordId);


                //Programacion blanda
                PropertyOwnerMapperInfrastructure mapper = new PropertyOwnerMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwnerMapperInfrastructure mapper = new PropertyOwnerMapperInfrastructure();
                    PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                    db.PropertyOwner.Attach(dbRecord);
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
