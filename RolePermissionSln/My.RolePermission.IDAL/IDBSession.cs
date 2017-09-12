using System.Collections.Generic;
using System.Data.Entity;

namespace My.RolePermission.IDAL
{
    public partial interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();
        int ExecuteSql(string sql, params System.Data.SqlClient.SqlParameter[] pars);
        List<T> ExecuteSelectQuery<T>(string sql, params System.Data.SqlClient.SqlParameter[] pars);
    }
}
