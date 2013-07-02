using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;

namespace DataObjects.EntityFramework.ModelMapper
{
    /// <summary>
    /// Maps Entity Framework entities to business objects and vice versa.
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Maps customer entity to customer business object.
        /// </summary>
        /// <param name="entity">A customer entity to be transformed.</param>
        /// <returns>A customer business object.</returns>
        internal static Customer Map(CustomerEntity entity)
        {
            return new Customer { 
                CustomerId = entity.CustomerId,
                CompanyName = entity.CompanyName,
                Country = entity.Country,
                City = entity.City
            };
        }

        /// <summary>
        /// Maps customer to customer entity.
        /// </summary>
        /// <param name="entity">A customer business object to be transformed.</param>
        /// <returns>A customer entity.</returns>
        internal static CustomerEntity Map(Customer customer)
        {
            return new CustomerEntity
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                Country = customer.Country,
                City = customer.City
            };
        }
    }
}
