using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
   public class EmployeeCommentModel
    {
        public int EmployeeCommentID { get; set; }
        public int EmployeeID { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual EmployeeMasterModel EmployeeMaster { get; set; }
    }
}
