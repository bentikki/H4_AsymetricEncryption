using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsymetricEncryption
{
    public class BenchmarkStopWatch : IBenchmarkTimer
    {
        private Stopwatch stopwatch = new Stopwatch();

        public void Reset()
        {
            this.stopwatch.Reset();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();

        }

        public string TimingResult()
        {
            return this.stopwatch.Elapsed.ToString();
        }
    }
}
