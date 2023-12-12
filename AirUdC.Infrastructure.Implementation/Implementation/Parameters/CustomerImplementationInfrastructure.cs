using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using AirUdC.Infrastructure.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirUdC.Infrastructure.Implementation.Implementation.Parameters
{
    public class CustomerImplementationInfrastructure : ICustomerInfrastructure
    {

        public CustomerDbModel CreateRecord(CustomerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Customer.Any(x => x.FirstName.Equals(record.FirstName)))
                    {
                        CustomerMapperInfrastructure mapper = new CustomerMapperInfrastructure();
                        Customer dbRecord = mapper.MapperT2toT1(record);
                        db.Customer.Add(dbRecord);
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
                    Customer record = db.Customer.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Customer.Remove(record);
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

        public IEnumerable<CustomerDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                     from c in db.Customer
                     where c.FirstName.Contains(filter)
                     select c
                     );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));


                //Programacion blanda
                CustomerMapperInfrastructure mapper = new CustomerMapperInfrastructure();
                return mapper.MapperT1toT2(records);
            }
        }

        public CustomerDbModel GetRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Customer.Find(recordId);


                //Programacion blanda
                CustomerMapperInfrastructure mapper = new CustomerMapperInfrastructure();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(CustomerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    CustomerMapperInfrastructure mapper = new CustomerMapperInfrastructure();
                    Customer dbRecord = mapper.MapperT2toT1(record);
                    db.Customer.Attach(dbRecord);
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

