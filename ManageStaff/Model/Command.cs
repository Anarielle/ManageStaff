using ManageStaff.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStaff.Model
{
    public static class Command
    {
        public static List<Employee> GetEmployees()
        {
            using (EmployeesContext db = new EmployeesContext())
            {
                var result = db.StaffState.ToList();
                result.Where(st => st.Status == 1).ToList().ForEach(st => st.StatusView = "Работает");
                result.Where(st => st.Status == 2).ToList().ForEach(st => st.StatusView = "Отсутствует");
                return result;
            }
        }

        public static void EditEmployee(Employee newEmployee)
        {
            using (EmployeesContext db = new EmployeesContext())
            {
                Employee employee = db.StaffState.FirstOrDefault(e => e.Id == newEmployee.Id);
                employee.Status = newEmployee.Status;

                db.SaveChanges();
            }
        }
    }
}
