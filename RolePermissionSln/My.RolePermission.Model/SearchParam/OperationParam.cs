/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.SearchParam
 *文件名：  OperationParam
 *版本号：  V1.0.0.0
 *唯一标识：a5434232-4fee-4161-82f2-c8d01fa3c39f
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/7/16 17:03:34

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/7/16 17:03:34
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.Model.SearchParam
{
    public class OperationParam:BaseParam
    {
        public string FUNC_NAME { get; set; }
        public string STATUS { get; set; }
    }
}
