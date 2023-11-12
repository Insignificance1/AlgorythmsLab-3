using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3.Utilities
{
    public class OperationTimer
    {
        private Stopwatch stopwatch;

        public OperationTimer()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Restart();
        }

        public TimeSpan Stop()
        {
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
