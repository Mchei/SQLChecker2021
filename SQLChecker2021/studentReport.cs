using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latest_27_05
{
    public class studentReport
    {
        public string StudentID { get; set; }
        public string questionNo { get; set; }
        public string error { get; set; }
        public double score { get; set; }
        public DateTime CreatedOn { get; set; }

        public long executionTime { get; set; }

        public string getStudentReport()
        {
            return string.Format(StudentID, questionNo, error, score, CreatedOn, executionTime);
        }



    }
}
