using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeSurveyModel
    {

        public int EmployeeSurveyID { get; set; }
        public int EmployeeID { get; set; }
        public int CategoryID { get; set; }
        public int Rating { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public virtual CategoryMasterModel CategoryMaster { get; set; }
        public virtual EmployeeMasterModel EmployeeMaster { get; set; }

    }
}
