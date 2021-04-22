using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymetricEncryption
{
    public interface IBenchmarkTimer
    {
        void Start();
        void Stop();
        void Reset();
        string TimingResult();
    }
}
