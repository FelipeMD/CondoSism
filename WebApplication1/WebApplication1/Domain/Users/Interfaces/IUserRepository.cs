using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Users.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVo user);
        User RefreshUserInfo(User user);
    }
}