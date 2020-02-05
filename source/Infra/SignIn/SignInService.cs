using Architecture.CrossCutting.Resources;
using Architecture.Model;
using DotNetCore.Extensions;
using DotNetCore.Results;
using DotNetCore.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Architecture.Infra
{
    public class SignInService : ISignInService
    {
        private readonly IHashService _hashService;
        private readonly IJsonWebTokenService _jsonWebTokenService;

        public SignInService
        (
            IHashService hashService,
            IJsonWebTokenService jsonWebTokenService
        )
        {
            _hashService = hashService;
            _jsonWebTokenService = jsonWebTokenService;
        }

        public SignInModel CreateSignIn(SignInModel signInModel)
        {
            signInModel.Salt = Guid.NewGuid().ToString();

            signInModel.Password = _hashService.Create(signInModel.Password, signInModel.Salt);

            return signInModel;
        }

        public TokenModel CreateToken(SignedInModel signedInModel)
        {
            var claims = new List<Claim>();

            claims.AddSub(signedInModel.Id.ToString());

            claims.AddRoles(signedInModel.Roles.ToString().Split(", "));

            var token = _jsonWebTokenService.Encode(claims);

            return new TokenModel(token);
        }

        public IResult Validate(SignedInModel signedInModel, SignInModel signInModel)
        {
            if (signedInModel == default || signInModel == default)
            {
                return Result.Fail(Texts.LoginPasswordInvalid);
            }

            var password = _hashService.Create(signInModel.Password, signedInModel.SignIn.Salt);

            if (signedInModel.SignIn.Password != password)
            {
                return Result.Fail(Texts.LoginPasswordInvalid);
            }

            return Result.Success();
        }
    }
}
