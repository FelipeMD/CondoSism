namespace Application.Services.Login.Interfaces
{
    public interface ILoginService
    {
        TokenVo ValidateCredentials(UserVo user);
        TokenVo ValidateCredentials(TokenVo token);
        bool RevokeToken(string userName);
    }
}