﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataObjects
{
    /// <summary>
    /// This class shields the client from the details of database specific 
    /// data-access objects. It returns the appropriate data-access objects 
    /// according to the configuration in web.config.
    /// </summary>
    /// <remarks>
    /// GoF Design Patterns: Factory, Singleton, Proxy.
    /// 
    /// This class makes extensive use of the Factory pattern in determining which 
    /// database specific DAOs (Data Access Objects) to return.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one 'instance' will ever exist.
    /// 
    /// This class is a Proxy as it 'stands in' for the actual Data Access Object Factory.
    /// </remarks>
    public static class DataAccess
    {
        // The static field initializers below are thread safe.
        // Furthermore, they are executed in the order in which they appear
        // in the class declaration. Note: if a static constructor
        // is present you want to initialize these in that constructor.
        private static readonly string _connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly IDaoFactory factory = DaoFactories.GetFactory(_connectionStringName);

        /// <summary>
        /// Gets a provider-specific customer data access object.
        /// </summary>
        public static ICustomerDao CustomerDao
        {
            get { return factory.CustomerDao; }
        }

    }
}
