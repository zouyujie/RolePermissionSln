//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace My.RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMROLETB
    {
        public SMROLETB()
        {
            this.SMMENUROLEFUNCTB = new HashSet<SMMENUROLEFUNCTB>();
            this.SMUSERTB2 = new HashSet<SMUSERTB>();
        }
    
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public Nullable<System.DateTime> CREATION_TIME { get; set; }
        public Nullable<int> CREATION_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_TIME { get; set; }
        public Nullable<int> UPDATE_USER { get; set; }
        public string REMARK { get; set; }
        public string STATUS { get; set; }
    
        public virtual ICollection<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public virtual SMROLETB SMROLETB1 { get; set; }
        public virtual SMROLETB SMROLETB2 { get; set; }
        public virtual SMUSERTB SMUSERTB { get; set; }
        public virtual SMUSERTB SMUSERTB1 { get; set; }
        public virtual ICollection<SMUSERTB> SMUSERTB2 { get; set; }
    }
}