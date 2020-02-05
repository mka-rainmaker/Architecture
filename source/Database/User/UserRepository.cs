using Architecture.CrossCutting;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRelationalRepository<UserEntity>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }

        public Task<UserModel> SelectByIdAsync(long id)
        {
            return Queryable
                .Where(userEntity => userEntity.Id == id)
                .Project<UserEntity, UserModel>()
                .FirstOrDefaultAsync();
        }

        public Task<SignedInModel> SignInAsync(SignInModel signInModel)
        {
            return Queryable
                .Where
                (
                    userEntity =>
                    userEntity.SignIn.Login == signInModel.Login &&
                    userEntity.Status == Status.Active
                )
                .Project<UserEntity, SignedInModel>()
                .SingleOrDefaultAsync();
        }

        public Task UpdateStatusAsync(UserEntity userEntity)
        {
            return UpdatePartialAsync(userEntity.Id, new { userEntity.Status });
        }
    }
}
