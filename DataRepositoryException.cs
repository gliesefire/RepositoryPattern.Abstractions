using System;

namespace RepositoryPattern.Abstractions
{
    public class DataRepositoryException : Exception
    {
        public const int CONNECTION_TIMED_OUT = 1;

        /// <summary>
        /// User DB is down or not accessible
        /// </summary>
        public const int DB_NOT_ACCESSIBLE = 2;
        public const int ABRUPT_CLOSE = 3;

        /// <summary>
        /// After obtaining the connection details from Centralized DB, the constructed connection string might not be valid. Hence the error
        /// </summary>
        public const int INVALID_CONNECTION_STRING = 4;

        /// <summary>
        /// Centralized DB is down
        /// </summary>
        public const int UNABLE_TO_CONNECT_DB_PROXY = 5;

        /// <summary>
        /// Schema doesn't Exist
        /// </summary>
        public const int INVALID_SCHEMA = 6;

        public int? ErrorCode { get; private set; }

        public DataRepositoryException()
        {
        }

        public DataRepositoryException(int errorCode, string message)
            :base(message)
        {
            ErrorCode = errorCode;
        }

        public DataRepositoryException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public DataRepositoryException(string message)
            : base(message)
        {
        }

        public DataRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
            ErrorCode = null;
        }

        public DataRepositoryException(int errorCode, Exception inner)
            : base(errorCode.ToString(), inner)
        {
            ErrorCode = errorCode;
        }
    }
}
