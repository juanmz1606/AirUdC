﻿using System.Collections.Generic;

namespace AirUdC.Application.Implementation.Mappers
{
    public abstract class MapperBaseApplication<T1,T2>
    {
        public abstract T2 MapperT1toT2(T1 input);
        public abstract IEnumerable<T2> MapperT1toT2(IEnumerable<T1> input);
        public abstract T1 MapperT2toT1(T2 input);
        public abstract IEnumerable<T1> MapperT2toT1(IEnumerable<T2> input);
    }
}
