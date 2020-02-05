using Architecture.Domain;
using DotNetCore.Repositories;

namespace Architecture.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
