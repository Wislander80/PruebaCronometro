using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCronometro
{
    public class PruebaCronometroModel
    {
        public TimeSpan ElapsedTime { get; private set; }

        public void UpdateElapsedTime(TimeSpan timeSpan)
        {
            ElapsedTime = timeSpan;
        }

        public void Reset()
        {
            ElapsedTime = TimeSpan.Zero;
        }
    }
}
