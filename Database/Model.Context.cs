//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marafon.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class marathonEntities : DbContext
    {
        public marathonEntities()
            : base("name=marathonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<charity> charity { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<@event> @event { get; set; }
        public virtual DbSet<eventtype> eventtype { get; set; }
        public virtual DbSet<gender> gender { get; set; }
        public virtual DbSet<marathon> marathon { get; set; }
        public virtual DbSet<positions> positions { get; set; }
        public virtual DbSet<racekitoption> racekitoption { get; set; }
        public virtual DbSet<registration> registration { get; set; }
        public virtual DbSet<registrationevent> registrationevent { get; set; }
        public virtual DbSet<registrationstatus> registrationstatus { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<runner> runner { get; set; }
        public virtual DbSet<sponsorship> sponsorship { get; set; }
        public virtual DbSet<staff> staff { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<volunteer> volunteer { get; set; }
    }
}
