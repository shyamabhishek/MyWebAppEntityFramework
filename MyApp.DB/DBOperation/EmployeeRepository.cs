using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Model;


namespace MyApp.DB.DBOperation
{
    public class EmployeeRepository
    {
        public void AddNewEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone

                };

                context.Employee.Add(emp);
                context.SaveChanges();

            }
        }
    }
}
