using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;
using System.Collections.Generic;

namespace AirUdC.Infrastructure.Implementation.Mappers.Parameters
{
    public class MultimediaTypeMapperInfrastructure : BaseMapperInfrastructure<MultimediaType, MultimediaTypeDbModel>
    {
        public override MultimediaTypeDbModel MapperT1toT2(MultimediaType input)
        {
            return new MultimediaTypeDbModel()
            {
                Id = input.Id,
                MultimediaTypeName = input.MultimediaTypeName
            };
        }

        public override IEnumerable<MultimediaTypeDbModel> MapperT1toT2(IEnumerable<MultimediaType> input)
        {
            IList<MultimediaTypeDbModel> list = new List<MultimediaTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override MultimediaType MapperT2toT1(MultimediaTypeDbModel input)
        {
                return new MultimediaType
                {
                    Id = input.Id, 
                    MultimediaTypeName = input.MultimediaTypeName
                };
        }

        public override IEnumerable<MultimediaType> MapperT2toT1(IEnumerable<MultimediaTypeDbModel> input)
        {
            IList<MultimediaType> list = new List<MultimediaType>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
