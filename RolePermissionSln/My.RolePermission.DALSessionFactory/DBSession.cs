using My.RolePermission.DAL;
using My.RolePermission.IDAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace My.RolePermission.DALSessionFactory
{
    /// <summary>
    /// DBSession;工厂类（数据会话层），作用：创建数据操作类的实例，业务层通过DBSession调用相应的数据操作类的实例，这样将业务层与数据层解耦。
    /// </summary>
    public partial class DBSession : IDBSession
    {
        public DbContext Db
        {
            get { return new DbContextFactory().CreateDbContext(); }
        }
        /// <summary>
        /// 执行EF上下文的SaveChanges方法
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            Db.Configuration.ValidateOnSaveEnabled = false;
            return Db.SaveChanges() > 0;
        }
        public int ExecuteSql(string sql, params System.Data.SqlClient.SqlParameter[] pars)
        {
            return pars==null?Db.Database.ExecuteSqlCommand(sql):Db.Database.ExecuteSqlCommand(sql, pars);
        }
        public List<T> ExecuteSelectQuery<T>(string sql, params System.Data.SqlClient.SqlParameter[] pars)
        {
            return Db.Database.SqlQuery<T>(sql, pars).ToList();
        }
    }
}
