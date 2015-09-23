using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabAgeBusinessEntities
{
    public class EmployeeMasterModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<long> Mobile { get; set; }
    }
}
