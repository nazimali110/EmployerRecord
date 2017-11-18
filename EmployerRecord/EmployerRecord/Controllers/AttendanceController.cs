using EmployerRecord.Model;
using EmployerRecord.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployerRecord.Controllers
{
    public class AttendanceController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Attendance Get(string Id)
        {
            return Attendances.GetById(Convert.ToInt32(Id));
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<Attendance> GetbyEmpId(string EmpId)
        {
            return Attendances.GetByEmpId(Convert.ToInt32(EmpId));
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<Attendance> GetAll()
        {
            return Attendances.GetAll();
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Add(string timeIn, string type, string employeeId, string date,string lat,string lon)
        {
            Attendance a = new Attendance();
            a.TimeIn = timeIn;
            a.Type = type;
            a.EmployeeId = Convert.ToInt32(employeeId);
            a.Date = date;
            a.lat = lat;
            a.lon = lon;

            int r = Attendances.Add(a);

            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Update(string timeOut, string type, string employeeId, string date,string lat,string lon)
        {
            Attendance a = new Attendance();
          
            a.TimeOut = timeOut;
            a.Type = type;
            a.EmployeeId = Convert.ToInt32(employeeId);
            a.Date = date;
            a.lat = lat;
            a.lon = lon;
            a.Status = 1;
            int r = Attendances.Update(a);

            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Delete(string id)
        {
            Attendance a = new Attendance();

            a.Id = Convert.ToInt32(id);
            a.Status = 2;
            int r = Attendances.Update(a);
          
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }
    
    }
}
