using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRelationalRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(Context context) : base(context)
        {
        }
    }
}
