using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stepn
{
    class PersonStats
    {
        public int averageStepsForAllPeriod 
        { 
            get
            {

                return (int)DayliStats.Average(point => point.Steps);
            }
        }
        public int bestResultForAllPeriod 
        {
            get
            {
                return DayliStats.Max(point => point.Steps);
            }
        }
        public int worseResoultForAllPeriod
        {
            get
            {
                return DayliStats.Min(point => point.Steps);
            }
        }
        public List<Dayli> DayliStats { get; set; }
    }    
}
