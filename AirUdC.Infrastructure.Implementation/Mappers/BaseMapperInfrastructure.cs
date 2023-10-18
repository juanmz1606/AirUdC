using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirUdC.Infrastructure.Implementation.Mappers

    //T1 será el de la capa inferior
    //T2 será el de la capa superior
{
    public abstract class BaseMapperInfrastructure<T1,T2>
    {
       /// <summary>
       /// Mapea de T2 a T1
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
        public abstract T1 MapperT2toT1(T2 input);
        /// <summary>
        /// Mapea de T1 a T2
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract T2 MapperT1toT2(T1 input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract IEnumerable<T1> MapperT2toT1(IEnumerable<T2> input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract IEnumerable<T2> MapperT1toT2(IEnumerable<T1> input);
    }
}
