﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RolePermissionEntities : DbContext
    {
        public RolePermissionEntities()
            : base("name=RolePermissionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SMFIELD> SMFIELD { get; set; }
        public DbSet<SMFUNCTB> SMFUNCTB { get; set; }
        public DbSet<SMLOG> SMLOG { get; set; }
        public DbSet<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public DbSet<SMMENUTB> SMMENUTB { get; set; }
        public DbSet<SMROLETB> SMROLETB { get; set; }
        public DbSet<SMUSERTB> SMUSERTB { get; set; }
    }
}