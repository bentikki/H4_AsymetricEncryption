using System;
using AsymetricEncryption;

namespace ConsoleVersionReader
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
