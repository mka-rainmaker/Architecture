using FluentValidation;

namespace Architecture.Model
{
    public sealed class UpdateUserModelValidator : UserModelValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
