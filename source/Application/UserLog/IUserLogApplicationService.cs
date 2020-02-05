using Architecture.Model;
using DotNetCore.Results;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public interface IUserLogApplicationService
    {
        Task<IResult> AddAsync(UserLogModel userLogModel);
    }
}
