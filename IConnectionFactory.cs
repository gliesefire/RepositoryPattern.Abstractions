using System;
using System.Data;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
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
