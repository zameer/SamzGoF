using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using DataObjects.EntityFramework.ModelMapper;

namespace DataObjects.EntityFramework.Implementation
{
    /// <summary>
    /// Entity Framework implementation of the ICustomerDao interface.
    /// </summary>
    public class EntityCustomerDao : ICustomerDao
    {
        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="CustomerId">a unique identifier</param>
        /// <returns>The customer</returns>
        public Customer GetCustomer(int CustomerId)
        {
            using (var context = DataObjectFactory.CreateContext())
            {
                return Mapper.Map(context.CustomerEntities.FirstOrDefault(c => c.CustomerId == CustomerId));
            }
        }
        /// <summary>
        /// Gets list of Customer
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetCustomers()
        {
            using (var context = DataObjectFactory.CreateContext())
            {
                var list = new List<Customer>();
                var customers = context.CustomerEntities.OrderByDescending(c => c.CustomerId).ToList();
                foreach (var entity in customers)
                    list.Add(Mapper.Map(entity));

                return list;
            }
        }

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="customer">Customer business object to insert</param>
        public void InsertCustomer(Customer customer)
        {
            using (var context = DataObjectFactory.CreateContext())
            {
                var entity = Mapper.Map(customer);
                context.CustomerEntities.Add(entity);
                context.SaveChanges();
                customer.CustomerId = entity.CustomerId;
            }
        }

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customer">Customer business object to update</param>
        public void UpdateCustomer(Customer customer)
        {
            using (var context = DataObjectFactory.CreateContext())
            {
                var entity = context.CustomerEntities.Where(c => c.CustomerId == customer.CustomerId).SingleOrDefault();
                entity.CompanyName = customer.CompanyName;
                entity.City = customer.City;
                entity.Country = customer.Country;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove a specific Customer
        /// </summary>
        /// <param name="CustomerId">Unique customer identifier</param>
        public void DeleteCustomer(int CustomerId)
        {
            using (var context = DataObjectFactory.CreateContext())
            {
                var entity = context.CustomerEntities.Where(c => c.CustomerId == CustomerId).SingleOrDefault();
                context.CustomerEntities.Remove(entity);

                context.SaveChanges();
            }
        }
    }
}
