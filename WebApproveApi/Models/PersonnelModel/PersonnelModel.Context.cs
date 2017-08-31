﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApproveApi.Models.PersonnelModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PersonnelEntities : DbContext
    {
        public PersonnelEntities()
            : base("name=PersonnelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Prefix> Prefixes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual ObjectResult<sp_chckLogin_Result> sp_chckLogin(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_chckLogin_Result>("sp_chckLogin", usernameParameter, passwordParameter);
        }
    }
}
