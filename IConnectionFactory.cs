using RepositoryPattern.Abstractions.Wrappers;
using System;
using System.Data;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
    public abstract class TransactionalUnit : IUnitOfWork
    {
        private bool hasBegun;
        protected abstract Task Initiate(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// The provided isolation levels may or not work depending upon the underlying data access layer. Not all DB's support every isolation level.
        /// </summary>
        /// <param name="isolationLevel">Isolation Level at which the transaction should occur</param>
        /// <returns></returns>
        public Task BeginTransaction(XIsolationLevel? isolationLevel = null)
        {
            if (hasBegun) throw new InvalidOperationException("Transaction in progress. Either save the changes or discard it to begin another one");
            this.hasBegun = true;
            if (isolationLevel is null)
                return Initiate();
            else
                return Initiate(isolationLevel.DbIsolationLevel());
        }

        public Task SaveChanges()
        {
            if (hasBegun)
            {
                hasBegun = false;
                return Commit();
            }
            else
                return Task.CompletedTask;
        }

        protected abstract Task Commit();
    }

    public abstract class IConnectionFactory : TransactionalUnit
    {
        public IDbTransaction? CurrentTransaction { get; protected set; }
        /// <summary>
        /// Open a connection to DB ( if not already open ).
        /// </summary>
        /// <exception cref="DataRepositoryException"> If the connection timed out or is not accessible </exception>
        /// <returns><see cref="IDbConnection"/> object, otherwise throws <see cref="DataRepositoryException"/></returns>
        public IDbConnection CreateOpenConnection()
        {
            return CreateOpenConnectionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Open a connection to DB ( if not already open ) in an async manner.
        /// In most connection implementations, this is the default way. i.e. the synchronous version <see cref="CreateOpenConnection"/>, calls async internally.
        /// </summary>
        /// <exception cref="DataRepositoryException"> If the connection timed out or is not accessible </exception>
        /// <returns><see cref="IDbConnection"/> object, otherwise throws <see cref="DataRepositoryException"/></returns>
        public abstract Task<IDbConnection> CreateOpenConnectionAsync();

        
    }
}
