using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Test.Fakes
{
    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public FakeSignInManager()
            :base( new Mock<FakeUserManager>().Object,
                   new HttpContextAccessor(),
                   new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                   new Mock<IOptions<IdentityOptions>>().Object,
                   new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                   new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object,
                   new Mock<IUserConfirmation<IdentityUser>>().Object)
        {

        }
    }
}
