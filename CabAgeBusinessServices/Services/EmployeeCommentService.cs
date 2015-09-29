using AutoMapper;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using CabAgeDataModel;
using CabAgeDataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CabAgeBusinessServices.Services
{
    public class EmployeeCommentService : IEmployeeCommentService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeeCommentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public EmployeeCommentModel GetCommentByEmpId(int id)
        {
            var employee = unitOfWork.EmployeeCommentRepository.GetByID(id);
            if (employee == null) return null;

            Mapper.CreateMap<EmployeeSurveyComment, EmployeeCommentModel>();
            var employeeCommentModel = Mapper.Map<EmployeeSurveyComment, EmployeeCommentModel>(employee);
            return employeeCommentModel;
        }

        public IEnumerable<EmployeeCommentModel> GetAllComments()
        {
            var employeesComments = unitOfWork.EmployeeCommentRepository.GetAll().ToList();
            if (!employeesComments.Any()) return null; ;

            Mapper.CreateMap<EmployeeSurveyComment, EmployeeCommentModel>();
            var employeesCommentModel = Mapper.Map<List<EmployeeSurveyComment>, List<EmployeeCommentModel>>(employeesComments);

            return employeesCommentModel;
        }

        public void CreateEmployeeComment(EmployeeCommentModel newEmployeeComment)
        {
            using (var scope = new TransactionScope())
            {
                var employeeComment = new EmployeeSurveyComment
                {
                    Comment = newEmployeeComment.Comment,
                    EmployeeID=newEmployeeComment.EmployeeID,
                    CreatedDate = DateTime.Now,
                };
                unitOfWork.EmployeeCommentRepository.Insert(employeeComment);
                unitOfWork.Save();
                scope.Complete();
            }
        }

        public void UpdateEmployeeComment(EmployeeCommentModel existingEmployeeComment)
        {
            using (var scope = new TransactionScope())
            {
                var employeeComment = new EmployeeSurveyComment
                {
                    Comment = existingEmployeeComment.Comment,
                    EmployeeID = existingEmployeeComment.EmployeeID,
                    CreatedDate = DateTime.Now,
                };
                unitOfWork.EmployeeCommentRepository.Update(employeeComment);
                unitOfWork.Save();
                scope.Complete();
            }
        }

        public bool IsEmployeeCommented(int id)
        {
            var allComments = GetAllComments();
            return allComments != null ? allComments.ToList().Exists(comment => comment.EmployeeID == id) : false;
        }
    }
}
