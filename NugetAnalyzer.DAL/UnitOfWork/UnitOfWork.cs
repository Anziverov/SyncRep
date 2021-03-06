﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NugetAnalyzer.DAL.Context;
using NugetAnalyzer.DAL.Interfaces;

namespace NugetAnalyzer.DAL.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly NugetAnalyzerDbContext context;
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(NugetAnalyzerDbContext context, IServiceProvider serviceProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IRepository<T> GetRepository<T>()
            where T : class
        {
            return serviceProvider.GetRequiredService<IRepository<T>>();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}