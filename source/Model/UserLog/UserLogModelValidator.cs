using DotNetCore.Validation;
using FluentValidation;

namespace Architecture.Model
{
    public sealed class UserLogModelValidator : Validator<UserLogModel>
    {
        public UserLogModelValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.LogType).NotEmpty();
        }
    }
}
