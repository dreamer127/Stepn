using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stepn
{
    class Dayli
    {
        public Dayli(int rank, string status, int steps)
        {
            // Проверки на входные значения.

            Rank = rank;
            Status = status;
            Steps = steps;
            Days++;
        }
        public int Days = 0;
        public int Rank { get; }
        public string Status { get; }
        public int Steps { get; }
    }
    
}
