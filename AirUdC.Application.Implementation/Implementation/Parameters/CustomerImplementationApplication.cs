using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.Infastructure.Contracts.Contracts.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Implementation.Parameters
{
    public class CustomerImplementationApplication : ICustomerApplication
    {
        ICustomerInfrastructure _customerInfrastructure;
        public CustomerImplementationApplication(ICustomerInfrastructure customerInfrastructure)
        {
            this._customerInfrastructure = customerInfrastructure;
        }
        public CustomerDTO CreateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            CustomerDbModel created = this._customerInfrastructure.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(long recordId)
        {
            int deleted = this._customerInfrastructure.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<CustomerDTO> GetAllRecords(string filter)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            IEnumerable<CustomerDbModel> records = this._customerInfrastructure.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public CustomerDTO GetRecord(long recordId)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel record = this._customerInfrastructure.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._customerInfrastructure.UpdateRecord(mapped);
            return updated;
        }
    }

}
