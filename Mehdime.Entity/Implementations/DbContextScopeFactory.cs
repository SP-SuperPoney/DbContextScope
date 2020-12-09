/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Data;

namespace Mehdime.Entity
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        private readonly IDbContextFactory _dbContextFactory;

        public DbContextScopeFactory(IDbContextFactory dbContextFactory = null)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting, string nameOrConnectionString = null)
        {
            return new DbContextScope(
                joiningOption: joiningOption, 
                readOnly: false, 
                isolationLevel: null, 
                dbContextFactory: _dbContextFactory,
                nameOrConnectionString);
        }

        public IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting, string nameOrConnectionString = null)
        {
            return new DbContextReadOnlyScope(
                joiningOption: joiningOption, 
                isolationLevel: null, 
                dbContextFactory: _dbContextFactory,
                nameOrConnectionString);
        }

        public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel, string nameOrConnectionString = null)
        {
            return new DbContextScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                readOnly: false, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory,
                nameOrConnectionString);
        }

        public IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel, string nameOrConnectionString = null)
        {
            return new DbContextReadOnlyScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory,
                nameOrConnectionString);
        }

        public IDisposable SuppressAmbientContext()
        {
            return new AmbientContextSuppressor();
        }
    }
}