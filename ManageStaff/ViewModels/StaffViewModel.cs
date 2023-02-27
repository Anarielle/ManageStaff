using ManageStaff.Model;
using ManageStaff.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ManageStaff.ViewModel
{
    internal class StaffViewModel : INotifyPropertyChanged
    {
        private List<Employee> employees = Command.GetEmployees();
        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                NotifyPropertyChanged("Employees");
            }
        }

        public Employee SelectedEmployee { get; set; }

        private RelayCommand editEmployee;
        public RelayCommand EditEmployee
        {
            get
            {
                return editEmployee ?? new RelayCommand(obj =>
                {
                    Employee emp = Employees.FirstOrDefault(e => e.Id == SelectedEmployee.Id);
                    if (emp.Status == 1)
                    {
                        emp.Status = 2;
                        emp.StatusView = "Отсутствует";
                    }
                    else
                    {
                        emp.Status = 1;
                        emp.StatusView = "Работает";
                    }
                    Command.EditEmployee(emp);
                    UpdateView();
                });
            }
        }

        private RelayCommand updateData;
        public RelayCommand UpdateData
        {
            get
            {
                return updateData ?? new RelayCommand(obj =>
                {
                    Employees = Command.GetEmployees();
                    UpdateView();
                });
            }
        }

        private void UpdateView()
        {
            MainWindow.EmployeesView.ItemsSource = null;
            MainWindow.EmployeesView.Items.Clear();
            MainWindow.EmployeesView.ItemsSource = Employees;
            MainWindow.EmployeesView.Items.Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
