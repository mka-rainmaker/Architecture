using Architecture.CrossCutting;
using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public static class UserLogFactory
    {
        public static UserLogEntity Create(UserLogModel userLogModel)
        {
            return new UserLogEntity(userLogModel.UserId, userLogModel.LogType);
        }

        public static UserLogModel Create(SignedInModel signedInModel)
        {
            return new UserLogModel(signedInModel.Id, LogType.SignIn);
        }

        public static UserLogModel Create(SignOutModel signOutModel)
        {
            return new UserLogModel(signOutModel.Id, LogType.SignOut);
        }
    }
}
