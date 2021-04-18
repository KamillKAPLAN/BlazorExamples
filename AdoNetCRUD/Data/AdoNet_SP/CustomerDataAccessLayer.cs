using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace AdoNetCRUD.Data.AdoNet_SP
{
    public class CustomerDataAccessLayer
    {
        /* data source=DESKTOP-QSMLA58\KAMILKAPLAN; initial catalog=DbMvcKamp; integrated security=true; */
        string connectionString = "Data Source=DESKTOP-QSMLA58\\KAMILKAPLAN; Initial Catalog=DbAdoNet; Integrated Security=True";

        /* Insert Customer */
        public void AddCustomer(CustomerInfo Customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Gender", Customer.Gender);
                cmd.Parameters.AddWithValue("@Country", Customer.Country);
                cmd.Parameters.AddWithValue("@City", Customer.City);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        /* GetAll Customers */
        public IEnumerable<CustomerInfo> GetAllCustomers()
        {
            List<CustomerInfo> lstCustomer = new List<CustomerInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustomerInfo customer = new CustomerInfo();
                    customer.CustomerId = Convert.ToInt32(rdr["CustomerId"]);
                    customer.Name = rdr["Name"].ToString();
                    customer.Gender = rdr["Gender"].ToString();
                    customer.Country = rdr["Country"].ToString();
                    customer.City = rdr["City"].ToString();
                    lstCustomer.Add(customer);
                }
                con.Close();
            }
            return lstCustomer;
        }

        /* GetById Customer */
        public CustomerInfo GetByIdCustomer(int? id)
        {
            CustomerInfo customer = new CustomerInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetByIdCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.CustomerId = Convert.ToInt32(rdr["CustomerID"]);
                    customer.Name = rdr["Name"].ToString();
                    customer.Gender = rdr["Gender"].ToString();
                    customer.Country = rdr["Country"].ToString();
                    customer.City = rdr["City"].ToString();
                }
            }
            return customer;
        }

        /* Update Customer */
        public void UpdateCustomer(CustomerInfo Customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", Customer.CustomerId);
                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Gender", Customer.Gender);
                cmd.Parameters.AddWithValue("@Country", Customer.Country);
                cmd.Parameters.AddWithValue("@City", Customer.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /* Delete Customer */
        public void DeleteCustomer(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
