﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLChecker2021
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SQLProjectDBEntities : DbContext
    {
        public SQLProjectDBEntities()
            : base("name=SQLProjectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Deduction> Deductions { get; set; }
        public virtual DbSet<MarksDeduction> MarksDeductions { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<queryType> queryTypes { get; set; }
        public virtual DbSet<Questions_Previous> Questions_Previous { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentQuery> StudentQueries { get; set; }
    }
}
