using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerRecord.Model
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Qrcode { get; set; }

        public string pin { get; set; }
        
        public string username { get; set; }

        public string password { get; set; }

        public DateTime DateCreated { get; set; }

        public int Status { get; set; }

    }

}
