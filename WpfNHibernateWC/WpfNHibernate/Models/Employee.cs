using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNHibernate
{
    public class EmployeeDTO
    {
        public virtual int Employee_ID { get; set; }
        public virtual string Employee_FirstName { get; set; }
        public virtual string Employee_LastName { get; set; }
        public virtual DateTime Employee_DOB { get; set; }
        public virtual decimal Employee_Salary { get; set; }
        public virtual bool Employee_IsPermanent { get; set; }
        public virtual string Employee_Designation { get; set; }
    }
    public class TransactionData
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
