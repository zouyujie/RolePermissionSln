using My.RolePermission.IBLL;
using My.RolePermission.Ioc;
using My.RolePermission.Model;
using System.Web.Mvc;

namespace My.RolePermission.WebApp.Controllers
{
    public class BaseController : Controller
    {
        #region 注入属性
        public ISMUSERTBService SMUSERTBService
        {
            get
            {
                return SpringHelper.GetObject<ISMUSERTBService>("SMUSERTBService");
            }
        }
        public ISMMENUTBService SMMENUTBService
        {
            get
            {
                return SpringHelper.GetObject<ISMMENUTBService>("SMMENUTBService");
            }
        }
        public ISMMENUROLEFUNCTBService SMMENUROLEFUNCTBService
        {
            get
            {
                return SpringHelper.GetObject<ISMMENUROLEFUNCTBService>("SMMENUROLEFUNCTBService");
            }
        }
        public ISMLOGService SMLOGService
        {
            get
            {
                return SpringHelper.GetObject<ISMLOGService>("SMLOGService");
            }
        }
        public ISMROLETBService SMROLETBService
        {
            get
            {
                return SpringHelper.GetObject<ISMROLETBService>("SMROLETBService");
            }
        }
        public ISMFIELDService SMFIELDService
        {
            get
            {
                return SpringHelper.GetObject<ISMFIELDService>("SMFIELDService");
            }
        }
        public ISMFUNCTBService SMFUNCTBService
        {
            get
            {
                return SpringHelper.GetObject<ISMFUNCTBService>("SMFUNCTBService");
            }
        }
        #endregion
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        protected Account GetCurrentAccount()
        {
            if (Request.Cookies["sessionId"] != null)
            {
                string sessionId = Request.Cookies["sessionId"].Value;//接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(sessionId);//根据key从Memcache中获取用户的信息
                return obj == null ? null : Common.SerializerHelper.DeserializeToObject<Account>(obj.ToString()); ;
            }
            else
            {
                return null;
            }
        }

        protected int UserId
        {
            get
            {
                return GetCurrentAccount()==null?0:GetCurrentAccount().USER_ID;
            }
        }

        #region 日志对象字符串静态变量
        protected static readonly string strCreate = ": Create";
        protected static readonly string strEdit =": Edit";
        protected static readonly string strDelete = ": Delete";
        #endregion
    }
}
