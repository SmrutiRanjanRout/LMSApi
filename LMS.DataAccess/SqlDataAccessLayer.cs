using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DataAccess
{
    public class SqlDataAccessLayer : DataAccessLayerBaseClass
    {
        // Provide class constructors
        public SqlDataAccessLayer() { }
        public SqlDataAccessLayer(string connectionString) { this.ConnectionString = connectionString; }

        // DataAccessLayerBaseClass Members
        internal override IDbConnection GetDataProviderConnection()
        {
            return new SqlConnection();
        }
        internal override IDbCommand GeDataProviderCommand()
        {
            return new SqlCommand();
        }

        internal override IDbDataAdapter GetDataProviderDataAdapter()
        {
            return new SqlDataAdapter();
        }
    }
}
