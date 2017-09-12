/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common
 *文件名：  Suggestion
 *版本号：  V1.0.0.0
 *唯一标识：b3d5091c-6fa5-4a99-ad46-b9af415a6ebd
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 15:32:56

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 15:32:56
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/

namespace My.RolePermission.Common
{
    public static class Suggestion
    {
        public static string NoExist { get { return "对不起，您选择的对象不存在！"; } }

        public static string InsertSucceed { get { return "创建成功！"; } }
        public static string InsertFail { get { return "创建失败！"; } }
        public static string InsertException { get { return "创建数据产生异常！"; } }
        public static string InsertNoPerson { get { return "创建失败,请重新登陆系统！"; } }

        public static string UpdateSucceed { get { return "修改成功！"; } }
        public static string UpdateFail { get { return "修改失败！"; } }
        public static string UpdateException { get { return "修改数据产生异常！"; } }
        public static string UpdateNoPerson { get { return "更新失败,请重新登陆系统！"; } }

        public static string DeleteSucceed { get { return "删除成功！"; } }
        public static string DeleteFail { get { return "删除失败！"; } }
        public static string DeleteException { get { return "删除数据产生异常！"; } }
        public static string DeleteNoPerson { get { return "更新失败,请重新登陆系统！"; } }
    }
}
