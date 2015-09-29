using AttributeRouting.Web.Http;
using CabAgeBusinessEntities;
using CabAgeBusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CabAgeWebAPI.Controllers
{
    public class EmployeeCommentController : ApiController
    {
        private readonly IEmployeeCommentService employeeCommentService;

        public EmployeeCommentController(IEmployeeCommentService employeeMasterService)
        {
            this.employeeCommentService = employeeMasterService;
        }

        [POST("employeecomment/create")]
        public void Post([FromBody] EmployeeCommentModel employeeCommentBusinessEntity)
        {

            try
            {
                employeeCommentService.CreateEmployeeComment(employeeCommentBusinessEntity);
                Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                var message
                    = new System.Web.Http.HttpError("OOPS !! Something went wrong . Please contract oot.admin@socgen.com") { { "ErrorCode", 500 } };

                throw new
                   HttpResponseException(Request.CreateErrorResponse
                   (HttpStatusCode.InternalServerError, message));
            }

        }

        //[PUT("employeecomment/update")]
        //public void Put([FromBody] EmployeeCommentModel employeeCommentBusinessEntity)
        //{

        //    try
        //    {
        //        employeeCommentService.UpdateEmployeeComment(employeeCommentBusinessEntity);
        //        Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch
        //    {
        //        var message
        //            = new System.Web.Http.HttpError("OOPS !! Something went wrong . Please contract oot.admin@socgen.com") { { "ErrorCode", 500 } };

        //        throw new
        //           HttpResponseException(Request.CreateErrorResponse
        //           (HttpStatusCode.InternalServerError, message));
        //    }

        //}

        //[AcceptVerbs("GET")]
        //[GET("employeecomment/iswritten/{id?}")]
        //public HttpResponseMessage IsEmployeeCommented(int id)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, employeeCommentService.IsEmployeeCommented(id));
        //}

        //[GET("employeescomments/getall")]
        //public HttpResponseMessage GetAllEmployees()
        //{
        //    var employeesComments = employeeCommentService.GetAllComments();
        //    if (employeesComments == null || !employeesComments.Any())
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees Comments not found");
        //    var employeeCommentEntities = employeesComments as List<EmployeeCommentModel> ?? employeesComments.ToList();
        //    if (employeeCommentEntities.Any())
        //        return Request.CreateResponse(HttpStatusCode.OK, employeeCommentEntities);
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees Comments not found");
        //}

        //[GET("employeecomment/employeecomment/{id?}")]
        //public HttpResponseMessage GetEmployeeById(int id)
        //{
        //    var employeeComment = employeeCommentService.GetCommentByEmpId(id);
        //    if (employeeComment == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Comment not found");
        //    return Request.CreateResponse(HttpStatusCode.OK, employeeComment);
        //}
    }
}
