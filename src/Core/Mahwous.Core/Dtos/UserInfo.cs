using System;

namespace Mahwous.Core.Dtos
{
    public class UserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserInfo : UserInfo
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

}
