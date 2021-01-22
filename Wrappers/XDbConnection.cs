using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace RepositoryPattern.Abstractions.Wrappers
{
    public sealed class XDbConnection : IDbConnection
    {
        /// <summary>
        /// Not for usage. 
        /// </summary>
        private XDbConnection() { }
        public string ConnectionString { get => ConnectionString; set => ConnectionString = value; }
        public int ConnectionTimeout => ConnectionTimeout;
        public string Database => Database;
        public ConnectionState State => State;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Close() { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDbTransaction BeginTransaction() { throw new InvalidOperationException(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDbTransaction BeginTransaction(IsolationLevel il) { throw new InvalidOperationException(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ChangeDatabase(string databaseName) => ChangeDatabase(databaseName);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDbCommand CreateCommand() => CreateCommand();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Open() => Open();
    }
}
