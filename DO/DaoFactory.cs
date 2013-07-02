using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Abstract factory interface, creates data access object
    /// </summary>
    /// <remarks>
    /// Factory design pattern
    /// </remarks>
    public interface IDaoFactory
    {
        /// <summary>
        /// Gets a customer data access object
        /// </summary>
        ICustomerDao CustomerDao { get; }
    }
}
