using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        string connString = ConfigurationManager.ConnectionStrings["dbConn"].ToString();

        //Get Employees
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("spGetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee()
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                EmployeeEmail = reader["EmployeeEmail"].ToString(),
                                EmployeePassword = reader["EmployeePassword"].ToString(),
                                EmployeeDepartment = reader["EmployeeDepartment"].ToString(),
                                EmployeeMobile = reader["EmployeeMobile"].ToString(),
                                RoleId = Convert.ToInt32(reader["RoleId"]),
                            };

                            employees.Add(employee);


                        }
                    }
                }

            }

            return employees;

        }

        public void SaveEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("spSaveEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
                    command.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);
                    command.Parameters.AddWithValue("@EmployeeDepartment", employee.EmployeeDepartment);
                    command.Parameters.AddWithValue("@EmployeeMobile", employee.EmployeeMobile);
                    command.Parameters.AddWithValue("@RoleId", employee.RoleId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("spDeleteEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.ExecuteNonQuery();
                }
            }
        }




    }
}