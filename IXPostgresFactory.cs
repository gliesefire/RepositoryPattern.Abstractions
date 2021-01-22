using RepositoryPattern.Abstractions.Wrappers;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
    public abstract class IXPostgresFactory : IXConnectionFactory
    {
        /// <summary>
        ///  Check if the provided schema exists for current connection
        /// </summary>
        /// <param name="validateSchema">Open a Separate connection to check if the schema exists.</param>
        /// <returns>True if schema exists, else false</returns>
        public abstract bool IsSchemaValid(string schemaName);

        /// <summary>
        /// Create a DbConnection  Object with given Schema Name
        /// </summary>
        /// <param name="schemaName">Schema to connect to. Complete schema in Postgres</param>
        /// <exception cref="DataRepositoryException"> If the connection string is invalid, or if the schema name doesn't exist </exception>
        /// <returns>IDbConnection object [if schema exists], otherwise throws DataRepositoryException</returns>
        public XDbConnection CreateOpenConnection(string schemaName)
        {
            return CreateOpenConnectionAsync(schemaName).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a DbConnection  Object with given Schema Name
        /// </summary>
        /// <param name="schemaName">Schema to connect to. Complete schema in Postgres. Default is public</param>
        /// <exception cref="DataRepositoryException"> If the connection string is invalid, or if the schema name doesn't exist </exception>
        /// <returns>IDbConnection object [if schema exists], otherwise throws DataRepositoryException</returns>
        public abstract Task<XDbConnection> CreateOpenConnectionAsync(string schemaName);
    }
}
