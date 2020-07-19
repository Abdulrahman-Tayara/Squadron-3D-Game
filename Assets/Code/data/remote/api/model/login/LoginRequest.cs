using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class LoginRequest {
    public string email;
    public string password;

    public LoginRequest(string email, string password) {
        this.email = email;
        this.password = password;
    }
}

