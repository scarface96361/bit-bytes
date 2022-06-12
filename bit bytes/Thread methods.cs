using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bit_bytes
{
    internal class Thread_methods
    {
        private ClickerStats Ram;

        public Thread_methods(ClickerStats value)
        {
            Ram = value;
        }


        public void RamThread()
        {
            while (true) {
                Thread.Sleep(Ram.AutoClickDelay);
                Ram.ClickScore = Ram.ClickScore + Ram.AutoClickValue;
            }
        }
    }
}
