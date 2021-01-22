using System;
using System.Data;

namespace RepositoryPattern.Abstractions.Wrappers
{
    public sealed class XDbTransaction : IDbTransaction
    {
        /// <summary>
        ///  A Wrapper around IDbTransaction so as to avoid commits or rollback manually from user.
        /// </summary>
        private XDbTransaction() { }

        /// <summary>
        /// DO NOT USE THIS.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public IDbConnection Connection => Connection;
        public IsolationLevel IsolationLevel => IsolationLevel;

        /// <summary>
        /// DO NOT USE THIS.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Commit() { }

        /// <summary>
        /// DO NOT USE THIS.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Dispose() { }


        /// <summary>
        /// DO NOT USE THIS.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Rollback() { }
    }
}
