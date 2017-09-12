using My.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using My.RolePermission.Model.SearchParam;

namespace My.RolePermission.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class,new()
    {
        /// <summary>
        /// EF上下文对象
        /// </summary>
        DbContext Db = new DbContextFactory().CreateDbContext();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="entity">需要包含的实体</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntitiesAll(string entity)
        {
            return string.IsNullOrEmpty(entity)?Db.Set<T>().AsQueryable():Db.Set<T>().Include(entity).AsQueryable();
        }
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="model">实体对象</typeparam>
        /// <param name="pageIdex">页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="toalCount">总记录数</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="isAsc">是否升序（true:表示升序, false：降序）</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<model>(int pageIdex, int pageSize, out int toalCount, Expression<Func<T, bool>> whereLambda, string orderby, bool ? isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda.Compile()).AsQueryable(); //Compile()
            toalCount = temp.Count();
            if (isAsc.HasValue)//排序
            {
                temp = isAsc.Value ? temp.OrderBy<T>(orderby).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize) : temp = temp.OrderByDescending<T>(orderby).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize); ;
            }
            else
            {
                temp = temp.Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
    }
}
