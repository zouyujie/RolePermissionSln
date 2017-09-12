/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.SearchParam
 *文件名：  BaseParam
 *版本号：  V1.0.0.0
 *唯一标识：2ddd0741-d139-44c8-ae85-a672c16c05c5
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/24 21:57:07

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/24 21:57:07
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
    public class BaseParam
    {
        public int page { get; set; }
        public int rows { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public int TotalCount { get; set; }
    }
}
