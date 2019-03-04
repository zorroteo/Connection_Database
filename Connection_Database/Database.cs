using Connection.BusinessLogic.Interface;
using Connection.BusinessLogic;
using Connection_Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_Database
{
    public class Database : IDatabase
    {
        public ISqlService MSSQL(string connnectionString)
        {
            return new SqlService(connnectionString);
        }
    }
}
