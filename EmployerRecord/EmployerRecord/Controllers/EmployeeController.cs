using EmployerRecord.Model;
using EmployerRecord.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace EmployerRecord.Controllers
{
    public class EmployeeController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Employee Get(string Id)
        {
            Employee elist = Employees.GetById(Convert.ToInt32(Id));
            //string data=JsonConvert.SerializeObject(elist);
            //string json;
            //if (elist.Id > 0)
            //{
            //    string json = "[{ 'success'='1'" + data.Replace("'", "\"").Substring(1, data.Length - 1) + "}]";
            //}
            //else {
            //    string json = "[{ 'success'='0'}]";
            //}
            return elist;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Employee GetByUserPass(string username, string password)
        {
            return Employees.GetByUserPass(username, password);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<Employee> GetAll()
        {
            return Employees.GetAll();
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Add(string name, string contact, string username, string companyId,string password, string active, string hourrate)
        {
            Employee e = new Employee();
            e.Name = name;
            e.Contact = contact;
            e.username = username;
            e.CompanyId = Convert.ToInt32(companyId);
            e.password = password;
            e.active = active;
            e.hourrate = hourrate;
           
            int r = Employees.Add(e);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Update(string id,string contact, string active,string hourrate, string password)
        {
            Employee e = new Employee();
            e.Id = Convert.ToInt32(id);
            e.Contact = contact;
           
            e.password = password;
            e.active = active;
            e.hourrate = hourrate;
          
            e.Status = 1;
            int r = Employees.Update(e);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Delete(string id)
        {
            Employee e = new Employee();
            e.Id = Convert.ToInt32(id);
          
            e.Status = 2;
            int r = Employees.Update(e);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }
    }
}
