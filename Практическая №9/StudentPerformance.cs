using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__9
{
    struct StudentPerformance
    {

        public StudentPerformance(string subject, int performancepermonth)
        {
            PerformancePerMonth = performancepermonth;
            Subject = subject;
        }

        public int PerformancePerMonth { get; set; }

        public string Subject { get; set; }
    }
}
