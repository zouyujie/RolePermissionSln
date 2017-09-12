using My.RolePermission.IDAL;
using System.Runtime.Remoting.Messaging;

namespace My.RolePermission.DALSessionFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDbSession()
        {
            IDBSession DbSession = (IDBSession)CallContext.GetData("dbSession");
            if (DbSession == null)
            {
                DbSession = new DBSession();
                CallContext.SetData("dbSession", DbSession);
            }
            return DbSession;
        }
    }
}
