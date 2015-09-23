using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeLocationModel
    {
        public int LocationID { get; set; }
        public int ID { get; set; }
        public System.Data.Entity.Spatial.DbGeography GeoLocation { get; set; }

        public virtual EmployeeMasterModel EmployeeMaster { get; set; }

    }
}
