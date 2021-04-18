using AdoNetCRUD.Data.AdoNet_SP;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetCRUD.Data
{
    public class DataAccessService
    {
        private IConfiguration config;
        public DataAccessService(IConfiguration configuration)
        {
            config = configuration;
        }

        private string ConnectionString
        {
            get
            {
                string _server = config.GetValue<string>("DbConfig:ServerName");
                string _database = config.GetValue<string>("DbConfig:DatabaseName");
                string _username = config.GetValue<string>("DbConfig:UserName");
                string _password = config.GetValue<string>("DbConfig:Password");
                return ($"Server={_server}; Database={_database}; User ID={_username}; Password={_password}; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        public IEnumerable<CustomerInfo> GetAllCustomer()
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();
            CustomerInfo customer;

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerId, Name, City, Country, Gender FROM tblCustomer", con);
            da.Fill(dt);
            
            foreach (DataRow row in dt.Rows)
            {
                customer = new CustomerInfo();
                customer.CustomerId = Convert.ToInt32(row["CustomerId"]);
                customer.Name = row["Name"].ToString();
                customer.Gender = row["Gender"].ToString();
                customer.Country = row["Country"].ToString();
                customer.City = row["City"].ToString();
                customers.Add(customer);
            }
            return customers;
        }
    }
}
