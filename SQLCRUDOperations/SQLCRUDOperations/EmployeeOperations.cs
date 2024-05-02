﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCRUDOperations
{
    internal class EmployeeOperations
    {
        Operations operations = new Operations();
        SqlDataReader sqlDataReader;
        public void DoAdd()
        {
            Console.WriteLine("Enter Unique Id of the Employee :");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name of the Employee: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Salary of the employee:");
            decimal Salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("ENter Age of the Employee:");
            int age = Convert.ToInt32(Console.ReadLine());
            EmployeeDetails employeeDetails = new EmployeeDetails
            {
                Id = Id,
                Name=Name,
                Salary=Salary,
                Age=age
            };
            int result= +operations.Add(employeeDetails);
            Console.WriteLine(result+" rows affected");
        }
        public void DoRead()
        {
            Console.WriteLine("Enter Unique Id of the Employee :");
            int readId = Convert.ToInt32(Console.ReadLine());
            sqlDataReader = operations.Read(readId);
            if (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader[0]+"\t\t"+ sqlDataReader[1] + "\t\t" + sqlDataReader[2] + "\t\t" + sqlDataReader[3]);
            }
            else
            {
                Console.WriteLine("null");
            }
            sqlDataReader.Close();
        }
        public void DoUpdate()
        {
            Console.WriteLine("Enter Employee Id to Update:");
            int newId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Employee name:");
            string newName=Console.ReadLine();
            Console.WriteLine("Enter new Employee Salary:");
            decimal newSalary=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter new employee Age");
            int newAge=Convert.ToInt32(Console.ReadLine());
            EmployeeDetails employeeDetails = new EmployeeDetails
            {
                Id = newId,
                Name=newName,
                Salary=newSalary,
                Age=newAge
            };
            int res = operations.Update(employeeDetails);
            Console.WriteLine(res+" rows affected");
        }
        public void DoDelete()
        {
            Console.WriteLine("Enter Id to delete:");
            int delId=Convert.ToInt32(Console.ReadLine());
            int res = operations.Delete(delId);
            Console.WriteLine(res + " rows affected");
        }
        public void DoDisplayAll()
        {
             
            List<EmployeeDetails> employeeslist = operations.DisplayAll();
            foreach (EmployeeDetails employee in employeeslist)
            {
                Console.WriteLine(employee.Id+"\t\t"+ employee.Name + "\t\t"+ employee.Salary+ "\t\t"+ employee.Age);
            }
        }
    }
}
