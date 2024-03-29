﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Domain.Models;

namespace TrustyNews.Api.Infrastructure.Persistence.Context
{
    public class TrustyNewsContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public TrustyNewsContext()
        {
        }

        public TrustyNewsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<NewsBookmark> NewsBookmarks { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<NewsCoverPhoto> NewsCoverPhotos { get; set;}
        public DbSet<NewsTag> NewsTags {  get; set; }
        public DbSet<NewsVote> NewsVotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=193.164.5.130,1433;Initial Catalog =trustynews;Integrated Security=false;User ID=samet;Password=Deneme123.;", opt =>
                {
                    opt.EnableRetryOnFailure();
                });
           
        }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {

            OnBeforeSave();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {

            OnBeforeSave();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            OnBeforeSave();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntites = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Added)
                .Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntites);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if(entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }

    }
}
