using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MikuChat.WPF.Services;

public class AccountService
{
    async Task<bool> UserLoginIn(string userName, SecureString password)
    {
        return await Task.Run(() =>
        {
            return true;
        });
    }
}
