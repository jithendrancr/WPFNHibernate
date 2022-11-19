using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNHibernate;

namespace WpfNHibernate
{
    public class EmployeeDAO : IEmployee
    {
        TransactionData _TranactionData = null;
        public TransactionData delete(EmployeeDTO emp)
        {
            _TranactionData = new TransactionData();
            using (ISession session = NHibernateSessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(emp);
                        transaction.Commit();
                        _TranactionData.Message = "Employee Deleted Successfully";
                        _TranactionData.Status = 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _TranactionData.Message = ex.Message;
                        _TranactionData.Status = 2;
                    }
                }
            }
            return _TranactionData;
        }

        public IList GetAll()
        {
            using (ISession session = NHibernateSessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var EmpList = session.Query<EmployeeDTO>().ToList();
                    return EmpList;
                }
            }
        }

        public EmployeeDTO GetEmployeeById(int EmployeeId)
        {
            using (ISession session = NHibernateSessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var Employee = session.Query<EmployeeDTO>().Where(e=>e.Employee_ID==EmployeeId).FirstOrDefault();
                    return Employee;
                }
            }
        }

        public TransactionData Insert(EmployeeDTO emp)
        {
            _TranactionData = new TransactionData();
            using (ISession session = NHibernateSessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(emp);
                        transaction.Commit();
                        _TranactionData.Message = "Employee Added Successfully";
                        _TranactionData.Status = 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _TranactionData.Message = ex.Message;
                        _TranactionData.Status = 2;
                    }
                }
            }
            return _TranactionData;
        }

        public TransactionData Update(EmployeeDTO emp)
        {
            _TranactionData = new TransactionData();
            using (ISession session = NHibernateSessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(emp);
                        transaction.Commit();
                        _TranactionData.Message = "Employee Updated Successfully";
                        _TranactionData.Status = 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _TranactionData.Message = ex.Message;
                        _TranactionData.Status = 2;
                    }
                }
            }
            return _TranactionData;
        }
    }
    
}
