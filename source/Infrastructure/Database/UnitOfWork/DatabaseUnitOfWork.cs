namespace Solution.Infrastructure.Database
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public DatabaseUnitOfWork(
            IUserLogRepository userLogRepository,
            IUserRepository userRepository,
            DatabaseContext context)
        {
            UserLogRepository = userLogRepository;
            UserRepository = userRepository;
            Context = context;
        }

        public IUserLogRepository UserLogRepository { get; }

        public IUserRepository UserRepository { get; }

        private DatabaseContext Context { get; }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
