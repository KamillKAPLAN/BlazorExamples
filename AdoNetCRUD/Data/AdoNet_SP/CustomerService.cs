using System.Collections.Generic;
using System.Linq;

namespace AdoNetCRUD.Data.AdoNet_SP
{
    public class CustomerService
    {
        CustomerDataAccessLayer objCustomerDAL;

        public CustomerService()
        {
            objCustomerDAL = new CustomerDataAccessLayer();
        }

        public string Create(CustomerInfo objCustomer)
        {
            objCustomerDAL.AddCustomer(objCustomer);
            return "Added Successfully";
        }

        public List<CustomerInfo> GetCustomer()
        {
            List<CustomerInfo> customers = objCustomerDAL.GetAllCustomers().ToList();
            return customers;
        }

        public CustomerInfo GetCustomerById(int id)
        {
            CustomerInfo customer = objCustomerDAL.GetByIdCustomer(id);
            return customer;
        }

        public string UpdateCustomer(CustomerInfo objcustomer)
        {
            objCustomerDAL.UpdateCustomer(objcustomer);
            return "Update Successfully";
        }

        public string DeleteCustomer(CustomerInfo objcustomer)
        {
            objCustomerDAL.DeleteCustomer(objcustomer.CustomerId);
            return "Delete Successfully";
        }
    }
}
