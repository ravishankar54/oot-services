using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabAgeBusinessEntities;

namespace CabAgeBusinessServices.Interfaces
{
    public interface IEmployeeCommentService
    {
        EmployeeCommentModel GetCommentByEmpId(int id);

        IEnumerable<EmployeeCommentModel> GetAllComments();

        void CreateEmployeeComment(EmployeeCommentModel newEmployeeComment);

        void UpdateEmployeeComment(EmployeeCommentModel existingEmployeeComment);

        bool IsEmployeeCommented(int id);

    }
}