using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// factory of factories, this class is a factory class that creates database specific
    /// factories which in turn creates data access objects
    /// </summary>
    public class DaoFactories
    {
        /// <summary>
        /// Gets a provider specific (i.e database specific) factory
        /// </summary>
        /// <param name="dataProvider">Database provider</param>
        /// <returns>Data access object factory</returns>
        public static IDaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider)
            {
                case "EntityFramework.SqlExpress": return new EntityFramework.Implementation.EntityDaoFactory();
                default: return new EntityFramework.Implementation.EntityDaoFactory();
            }
        }
    }
}
