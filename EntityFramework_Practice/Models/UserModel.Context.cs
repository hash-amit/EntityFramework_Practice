﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework_Practice.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbDatabaseEntities : DbContext
    {
        public dbDatabaseEntities()
            : base("name=dbDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int DeleteUser(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", user_idParameter);
        }
    
        public virtual ObjectResult<GetAllUser_Result> GetAllUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUser_Result>("GetAllUser");
        }
    
        public virtual ObjectResult<GetOneUser_Result> GetOneUser(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOneUser_Result>("GetOneUser", user_idParameter);
        }
    
        public virtual int InsertUser(string name, string email, Nullable<int> age)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUser", nameParameter, emailParameter, ageParameter);
        }
    
        public virtual int UpdateUser(Nullable<int> user_id, string name, string email, Nullable<int> age)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUser", user_idParameter, nameParameter, emailParameter, ageParameter);
        }
    }
}