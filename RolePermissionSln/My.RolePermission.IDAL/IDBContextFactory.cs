using System.Data.Entity;

namespace My.RolePermission.IDAL
{
    public interface IDBContextFactory
    {
        DbContext CreateDbContext();
    }
}
