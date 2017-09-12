using Spring.Context;
using Spring.Context.Support;

namespace My.RolePermission.Ioc
{
    public class SpringHelper
    {
        #region Spring容器上下文 +IApplicationContext SpringContext
        /// <summary>
        /// Spring容器上下文
        /// </summary>
        private static IApplicationContext SpringContext
        {
            get
            {
                return ContextRegistry.GetContext();
            }
        }
        #endregion

        #region 获取配置文件配置的对象 +T GetObject<T>(string objName) where T : class
        /// <summary>
        /// 获取配置文件配置的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static T GetObject<T>(string objName) where T : class
        {
            return (T)SpringContext.GetObject(objName);
        }
        #endregion
    }
}
