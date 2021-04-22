using System;
using AsymetricEncryption;

namespace ConsoleVersion
{
    class FactoryInit
    {
        public static IBenchmarkTimer BenchmarkTimer
        {
            get
            {
                return new BenchmarkStopWatch();
            }
        }
    }
}
