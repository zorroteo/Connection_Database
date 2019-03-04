using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.BusinessLogic.Interface;
using Connection.BusinessLogic;

namespace Connection_Database.Interface
{
    public interface IDatabase
    {
        ISqlService MSSQL(string connnectionString);
    }
}
