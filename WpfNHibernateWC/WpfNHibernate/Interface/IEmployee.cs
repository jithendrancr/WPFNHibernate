using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNHibernate;

namespace WpfNHibernate
{
    public interface IEmployee
    {
        TransactionData Insert(EmployeeDTO emp);
        TransactionData Update(EmployeeDTO emp);
        TransactionData delete(EmployeeDTO emp);
        IList GetAll();
        EmployeeDTO GetEmployeeById(int EmployeeId);
    }
}
