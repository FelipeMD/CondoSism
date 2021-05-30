﻿using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Login.Interfaces
{
    public interface ILoginService
    {
        TokenVo ValidateCredentials(UserVo user);
    }
}