using RepositoryPattern.Abstractions.Wrappers;
using System.Data;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
    /// <summary>
    /// A wrapper around IConnectionFactory to avoid mistakes like 'accidentally' closing the connection, or manually committing a transaction. A safe wrapper
    /// </summary>
    /// <remarks>Obviously this is useless, if you manually cast the object and make calls on it</remarks>
    public abstract class IXConnectionFactory : TransactionalUnit
    {
        protected IDbTransaction? _currentTransaction;
        public XDbTransaction? CurrentTransaction { get { return (XDbTransaction?)_currentTransaction; } protected set { _currentTransaction = value; } }

        /// <summary>
        /// Open a connection to DB ( if not already open ).
        /// </summary>
        /// <exception cref="DataRepositoryException"> If the connection timed out or is not accessible </exception>
        /// <returns><see cref="XDbConnection"/> object, otherwise throws <see cref="DataRepositoryException"/></returns>
        public XDbConnection CreateOpenConnection()
        {
            return CreateOpenConnectionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Open a connection to DB ( if not already open ) in an async manner.
        /// In most connection implementations, this is the default way. i.e. the synchronous version <see cref="CreateOpenConnection"/>, calls async internally.
        /// </summary>
        /// <exception cref="DataRepositoryException"> If the connection timed out or is not accessible </exception>
        /// <returns><see cref="XDbConnection"/> object, otherwise throws <see cref="DataRepositoryException"/></returns>
        public abstract Task<XDbConnection> CreateOpenConnectionAsync();
    }
}
