using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latest_27_05
{
    class student
    {
        public string StudentID;
        public string questionNo;
        public string Query;

        public string getData()
        {
            return this.StudentID + this.Query;
        }

    }
}
