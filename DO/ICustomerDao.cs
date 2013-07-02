using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;

namespace DataObjects
{
    /// <summary>
    /// Defines methods to access customers
    /// </summary>
    /// <remarks>
    /// This is a database independent interface, implementations are database specific
    /// </remarks>
    public interface ICustomerDao
    {
        /// <summary>
        /// Gets a specific Customer
        /// </summary>
        /// <param name="CustomerId">Unique customer identifier</param>
        /// <returns>Customer.</returns>
        Customer GetCustomer(int CustomerId);

        /// <summary>
        /// Gets list of Customer
        /// </summary>
        /// <returns>List of Customers</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="customer">Customer business object to insert</param>
        void InsertCustomer(Customer customer);

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customer">Customer business object to update</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Remove a specific Customer
        /// </summary>
        /// <param name="CustomerId">Unique customer identifier</param>
        void DeleteCustomer(int CustomerId);
    }
}
