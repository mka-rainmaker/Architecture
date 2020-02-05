using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public static class UserFactory
    {
        public static UserEntity Create(long id)
        {
            return new UserEntity(id);
        }

        public static UserEntity Create(AddUserModel addUserModel)
        {
            return new UserEntity
            (
                addUserModel.Id,
                new FullName
                (
                    addUserModel.FullName.Name,
                    addUserModel.FullName.Surname
                ),
                new Email(addUserModel.Email),
                new SignIn
                (
                    addUserModel.SignIn.Login,
                    addUserModel.SignIn.Password,
                    addUserModel.SignIn.Salt
                ),
                addUserModel.Roles,
                default
            );
        }
    }
}
