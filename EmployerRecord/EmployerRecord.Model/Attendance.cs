using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerRecord.Model
{
    public class Attendance
    {
        public int Id { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public int EmployeeId { get; set; }

        public string Type { get; set; }

        public string Date { get; set; }

        public DateTime DateCreated { get; set; }

        public int Status { get; set; }

        public string lat { get; set; }

        public string lon { get; set; }

    }

}
