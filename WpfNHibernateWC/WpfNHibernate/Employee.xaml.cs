using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfNHibernate;

namespace WpfNHibernate
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        IEmployee _employeedao = App.container.Resolve<IEmployee>();
        public Employee()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllEmployees();
        }
        private void GetAllEmployees()
        {
            try
            {
                //EmployeeDAO Dao = new EmployeeDAO();
                GrdEmployee.ItemsSource= _employeedao.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeDTO emp = SetEmployee();
                //EmployeeDAO Dao = new EmployeeDAO();
                TransactionData Ts = new TransactionData();
                if(emp.Employee_ID>0)
                {
                    Ts = _employeedao.Update(emp);
                }
                else
                Ts = _employeedao.Insert(emp);
                clearcontrol();
                MessageBox.Show(Ts.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GetAllEmployees();
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to delete?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                try
                {
                    var selectedEmployee = GrdEmployee.SelectedItem as EmployeeDTO;
                    //EmployeeDAO Dao = new EmployeeDAO();
                    TransactionData Ts = _employeedao.delete(selectedEmployee);
                    clearcontrol();
                    MessageBox.Show(Ts.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    GetAllEmployees();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedEmployee = GrdEmployee.SelectedItem as EmployeeDTO;
                //EmployeeDAO Dao = new EmployeeDAO();
                EmployeeDTO employee = _employeedao.GetEmployeeById(selectedEmployee.Employee_ID);
                BindEmployee(employee);
                btnCreate.Content = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GetAllEmployees();
            }
        }

        private EmployeeDTO SetEmployee()
        {
            EmployeeDTO employee = new EmployeeDTO();
            employee.Employee_FirstName = txtFirstName.Text;
            employee.Employee_LastName = txtLastName.Text;
            employee.Employee_Salary = Convert.ToDecimal(txtSalary.Text);
            employee.Employee_Designation = txtDesignation.Text;
            employee.Employee_IsPermanent = chkIsPermanent.IsChecked ?? false;
            employee.Employee_DOB = Convert.ToDateTime(dtEmployeeDOB.Text);
            employee.Employee_ID = Convert.ToInt32(txtEmployeeId.Text == "" ? "0" : txtEmployeeId.Text);
            return employee;
        }
        private  void BindEmployee(EmployeeDTO emp)
        {
            txtFirstName.Text = emp.Employee_FirstName;
            txtLastName.Text = emp.Employee_LastName;     
            txtSalary.Text = emp.Employee_Salary.ToString();
            txtDesignation.Text = emp.Employee_Designation;
            chkIsPermanent.IsChecked = emp.Employee_IsPermanent;   
            dtEmployeeDOB.Text = emp.Employee_DOB.ToString();
            txtEmployeeId.Text = emp.Employee_ID.ToString();           
        }
        private void clearcontrol()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSalary.Text = "0.00";
            dtEmployeeDOB.Text = string.Empty;
            chkIsPermanent.IsChecked = false;
            txtDesignation.Text = string.Empty;
            btnCreate.Content = "Create";
            txtEmployeeId.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clearcontrol();
        }
    }
}
