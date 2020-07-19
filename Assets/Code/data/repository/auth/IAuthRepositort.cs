using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAuthRepository {
    // Returns true if the user is guest or logged-in
    bool isLoggedIn();

    UserState getUserState();

    Task<LoginResponse> login(string email, string password);

    bool loginAsGuest();

    User getUser();

    bool logout();
}

