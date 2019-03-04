using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Connection.BusinessLogic.Interface;
using System.Data.Linq;
using System.Linq;

namespace Connection.BusinessLogic
{
    public class SqlService: ISqlService
    {
        private DataContext _context;
        public SqlService(string connectionString)
        {
            _context = new DataContext(GetConnectionString(connectionString));
        }

        public bool DatabaseExists()
        {
            return _context.DatabaseExists();
        }

        public T ExecuteSelectOneStatement<T>(string query, params object[] parameters)
        {
            if (DatabaseExists())
            {
                try
                {
                    return _context.ExecuteQuery<T>(query, parameters).FirstOrDefault<T>();
                }
                catch (Exception)
                {
                    return default(T);
                }
            }
            return default(T);
        }
       
        public IList<T> ExecuteSelectManyStatement<T>(string query, params object[] parameters)
        {
            if (DatabaseExists())
            {
                try
                {
                    return _context.ExecuteQuery<T>(query, parameters).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        private string GetConnectionString(string connectionString)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder =
                           new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
            return builder.ConnectionString;
        }
    }
}
