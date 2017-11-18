using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerRecord.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public int CompanyId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string hourrate { get; set; }

        public string active { get; set; }

       

        public DateTime DateCreated { get; set; }

        public int Status { get; set; }

    }

}
