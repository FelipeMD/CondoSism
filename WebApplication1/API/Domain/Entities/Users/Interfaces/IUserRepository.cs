using API.Data.ValueObjetcs;

namespace API.Domain.Entities.Users.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVo user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}