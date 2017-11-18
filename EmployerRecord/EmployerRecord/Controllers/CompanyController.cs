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
    public class CompanyController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Company Get(string Id)
        {
            int val = Convert.ToInt32(Id);
            return Companies.GetById(val);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Company GetByUserPass(string username, string password)
        {  
            return Companies.GetByUserPass(username,password);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<Company> GetAll()
        {
            return Companies.GetAll();
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Add(string name, string phone, string username, string qrcode, string pin, string password)
        {
            Company c=new Company();
            c.Name=name;
            c.Phone=phone;
            c.username = username;
            c.pin = pin;
            c.password = password;
            c.Qrcode = qrcode;

            int r = Companies.Add(c);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Update(string id,string phone, string pin, string password)
        {
            Company c = new Company();
           c.Id = Convert.ToInt32(id);
            c.Phone = phone;
           // c.username = username;
            c.pin = pin;
            c.password = password;
          //  c.Qrcode = qrcode;
            c.Status = 1;
            int r = Companies.Update(c);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Response Delete(string id)
        {
            Company c = new Company();
            c.Id = Convert.ToInt32(id);
            c.Status = 2;
            int r = Companies.Update(c);
            Response res = new Response();
            if (r == 0) { res.Status = 0; } else { res.Status = 1; }
            return res;
        }
    
    }
}
