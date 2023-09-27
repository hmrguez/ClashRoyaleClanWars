using ClashRoyaleClanWarsAPI.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Utils
{
    public class UserManagerResponse : RequestResponse<User>
    {
        public UserManagerResponse(User data=null!, IEnumerable<IdentityError> errors = null!, string message = "OK", bool success = true) : base(data, message, success)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
