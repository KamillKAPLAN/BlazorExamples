using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AdoNetCRUD.Data.AdoNetQueries
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public EmployeeService(SqlConnectionConfiguration configuration) => _configuration = configuration;

        /* Insert Employee */
        public async Task<bool> CreateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_configuration.Value))
            {
                const string query = "insert into dbo.Employees (Id,Name,Department,Designation,Company,City) values(@Id,@Name,@Department,@Designation,@Company,@City)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();
                cmd.Dispose();
            }

            return true;
        }

        /* GetAll Employees */
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_configuration.Value))
            {
                const string query = "select * from dbo.Employees";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = rdr["Id"].ToString(),
                        Name = rdr["Name"].ToString(),
                        Department = rdr["Department"].ToString(),
                        Designation = rdr["Designation"].ToString(),
                        Company = rdr["Company"].ToString(),
                        City = rdr["City"].ToString()
                    };
                    employees.Add(employee);
                }
                con.Close();
                cmd.Dispose();
            }
            return employees;
        }

        /* GetById Employee */
        public async Task<Employee> SingleEmployee(string id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(_configuration.Value))
            {
                const string query = "select * from dbo.Employees where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text,
                };

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                if (rdr.Read())
                {

                    employee.Id = rdr["Id"].ToString();
                    employee.Name = rdr["Name"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Designation = rdr["Designation"].ToString();
                    employee.Company = rdr["Company"].ToString();
                    employee.City = rdr["City"].ToString();
                }
                con.Close();
                cmd.Dispose();
            }
            return employee;
        }

        /* Update Employee */
        public async Task<bool> EditEmployee(string id, Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_configuration.Value))
            {
                const string query = "update dbo.Employees set Name = @Name, Department = @Department, Designation = @Designation, Company = @Company, City = @City where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text,
                };

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();
                cmd.Dispose();
            }
            return true;
        }

        /* Delete Employee */
        public async Task<bool> DeleteEmployee(string id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.Value))
            {
                const string query = "delete dbo.Employees where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text,
                };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();
                cmd.Dispose();
            }
            return true;
        }
    }
}
