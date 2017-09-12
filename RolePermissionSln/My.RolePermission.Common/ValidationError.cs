/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common
 *文件名：  ValidationError
 *版本号：  V1.0.0.0
 *唯一标识：794cd8a1-f357-4707-9ad2-45f270e49d33
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 17:28:48

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 17:28:48
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

namespace My.RolePermission.Common
{
    /// <summary>
    /// 验证错误
    /// </summary>
    public class ValidationError
    {
        public ValidationError() { }

        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// 多个验证错误的集合
    /// </summary>
    public class ValidationErrors : List<ValidationError>
    {
        public void Add(string errorMessage)
        {
            base.Add(new ValidationError { ErrorMessage = errorMessage });
        }
    }
}
