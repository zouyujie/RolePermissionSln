using My.RolePermission.IDAL;
using My.RolePermission.Model;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace My.RolePermission.DAL
{
    public class DbContextFactory : IDBContextFactory
    {
        /// <summary>
        /// 保证EF上下文实例是线程内唯一。
        /// </summary>
        /// <returns></returns>
        public DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new RolePermissionEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
