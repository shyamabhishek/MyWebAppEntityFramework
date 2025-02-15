﻿using System;
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

                    }).ToList();
                return result;

            }
        }
        public EmployeeModel GetEmployees(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x => x.id == id)
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

        public bool UpdateEmployee(int id, EmployeeModel emp)
        {
            try
            {
                using (var context = new EmployeeDBEntities())
                {
                    //var data = context.Employee.FirstOrDefault(x => x.id == id);
                    var data = new Employee();
                    if (data != null)
                    {
                        data.id = id;
                        data.FirstName = emp.FirstName;
                        data.LastName = emp.LastName;
                        data.Email = emp.Email;
                        data.Phone = emp.Phone;
                        data.AddressId = emp.Address.Id;


                        var dataAddress = new Address();

                        if (dataAddress != null)
                        {
                            dataAddress.id = emp.Address.Id;
                            dataAddress.Details = emp.Address.Details;
                            dataAddress.City = emp.Address.City;
                            dataAddress.State = emp.Address.State;
                            dataAddress.Country = emp.Address.Country;


                        }
                        context.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        context.Entry(dataAddress).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                try
                {
                    var employee = new Employee()
                    {
                        id = id
                    };
                    context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {

                    return false ;
                }
                //var data = context.Employee.FirstOrDefault(x => x.id == id);
                //if (data != null)
                //{
                //    context.Employee.Remove(data);
                //    context.SaveChanges();
                //    return true;
                //}
                //return false;
            }
        }
    }
}
