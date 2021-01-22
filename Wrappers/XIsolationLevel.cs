namespace RepositoryPattern.Abstractions.Wrappers
{
    public sealed class XIsolationLevel
    {
        public static XIsolationLevel Unspecified = new XIsolationLevel(-1);
        public static XIsolationLevel Chaos = new XIsolationLevel(16);
        public static XIsolationLevel ReadUncommitted = new XIsolationLevel(4096);
        public static XIsolationLevel ReadCommitted = new XIsolationLevel(65536);
        public static XIsolationLevel RepeatableRead = new XIsolationLevel(1048576);
        public static XIsolationLevel Serializable = new XIsolationLevel(16777216);
        public static XIsolationLevel Snapshot = new XIsolationLevel(-1);

        private readonly int v;

        private XIsolationLevel(int v)
        {
            this.v = v;
        }
        internal System.Data.IsolationLevel DbIsolationLevel()
        {
            return (System.Data.IsolationLevel)v;
        }
    }
}
