using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{    
    public abstract class TenantDBProvider
    {
        private readonly ClaimsPrincipal _principal;
        public TenantDBProvider(ClaimsPrincipal principal)
        {
            _principal = principal;
        }

        protected abstract Task<string> RetrieveConnectionStringFor(string tenantIdentifier);

        public async Task<string> RetrieveConnectionStringAsync()
        {
            var tenantIdentifier = GetTenantIdentifierFromPrincipal();
            if (tenantIdentifier is null)
                throw new InvalidOperationException("Unable to find Tenant Identifier");

            var connectionString = await RetrieveConnectionStringFor(tenantIdentifier);
            if (connectionString is null)
                throw new DataRepositoryException(DataRepositoryException.INVALID_CONNECTION_STRING);

            return connectionString;
        }

        public string RetrieveConnectionString()
        {
            return RetrieveConnectionStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Used by <see cref="RetrieveConnectionString"/> to extract tenant identifier from ClaimsPrincipal. Override this method if your identifier is not in <see cref="ClaimTypes.NameIdentifier"/> claim type
        /// </summary>
        /// <returns>Tenant Identifier</returns>
        protected virtual string GetTenantIdentifierFromPrincipal()
        {
            return _principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
