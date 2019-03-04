using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.BusinessLogic.Interface
{
    public interface ISqlService
    {
        bool DatabaseExists();
        T ExecuteSelectOneStatement<T>(string query, params object[] parameters);
        IList<T> ExecuteSelectManyStatement<T>(string query, params object[] parameters);
    }
}
