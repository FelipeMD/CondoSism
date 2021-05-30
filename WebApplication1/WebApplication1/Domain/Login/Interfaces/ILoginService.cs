using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Login.Interfaces
{
    public interface ILoginService
    {
        TokenVo ValidateCredentials(UserVo user);
        TokenVo ValidateCredentials(TokenVo token);
        bool RevokeToken(string userName);
    }
}