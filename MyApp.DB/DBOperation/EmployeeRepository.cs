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
        public int AddNewEmployee(EmployeeModel empModel)
        {
            using (var context = new EmployeeDBEntities())
            {
                Employee emp = null;
                try
                {
                    emp = new Employee()
                    {
                        FirstName = empModel.FirstName,
                        LastName = empModel.LastName,
                        Email = empModel.Email,
                        Phone = empModel.Phone

                    };
                    if (empModel.Address != null)
                    {
                        emp.Address = new Address()
                        {
                            Details = empModel.Address.Details,
                            City = empModel.Address.City,
                            State = empModel.Address.State,
                            Country = empModel.Address.Country,
                        };
                    }
                    context.Employee.Add(emp);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return emp.id;
            }
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Phone = x.Phone,
                        Address = new AddressModel()
                        {
                            Id = x.Address.id,
                            Details = x.Address.Details,
                            City = x.Address.City,
                            State = x.Address.State,
                            Country = x.Address.Country,
                        }

                    }) .ToList();
                return result;

            }
        }
        public EmployeeModel GetEmployees(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x=>x.id==id)
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Phone = x.Phone,
                        Address = new AddressModel()
                        {
                            Id = x.Address.id,
                            Details = x.Address.Details,
                            City = x.Address.City,
                            State = x.Address.State,
                            Country = x.Address.Country,
                        }

                    }).FirstOrDefault();
                return result;

            }
            
        }

    }
}
