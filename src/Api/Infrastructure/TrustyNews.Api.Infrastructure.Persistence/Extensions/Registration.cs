﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Infrastructure.Persistence.Context;
using TrustyNews.Api.Infrastructure.Persistence.Repositories.News;
using TrustyNews.Api.Infrastructure.Persistence.Repositories.User;

namespace TrustyNews.Api.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrustyNewsContext>(conf =>
            {
                var connStr = configuration["ConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            
            services.AddScoped<INewsBookmarkRepository, NewsBookmarkRepository>();
            services.AddScoped<INewsCommentRepository, NewsCommentRepository>();
            services.AddScoped<INewsCoverPhotoRepository, NewsCoverPhotoRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsTagRepository, NewsTagRepository>();
            services.AddScoped<INewsVoteRepository, NewsVoteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPhotoRepository, UserPhotoRepository>();

            return services;
        }
    }
}
