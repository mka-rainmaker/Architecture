using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Results;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class UserLogApplicationService : IUserLogApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserLogRepository _userLogRepository;

        public UserLogApplicationService
        (
            IUnitOfWork unitOfWork,
            IUserLogRepository userLogRepository
        )
        {
            _unitOfWork = unitOfWork;
            _userLogRepository = userLogRepository;
        }

        public async Task<IResult> AddAsync(UserLogModel userLogModel)
        {
            var validation = new UserLogModelValidator().Validate(userLogModel);

            if (validation.Failed)
            {
                return Result.Fail(validation.Message);
            }

            var userLogEntity = UserLogFactory.Create(userLogModel);

            await _userLogRepository.AddAsync(userLogEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
