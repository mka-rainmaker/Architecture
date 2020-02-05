using Architecture.CrossCutting;

namespace Architecture.Model
{
    public class SignedInModel
    {
        public long Id { get; set; }

        public Roles Roles { get; set; }

        public SignInModel SignIn { get; set; }
    }
}
