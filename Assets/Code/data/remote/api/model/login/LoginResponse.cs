using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class LoginResponse : BaseResponse<LoginResponseData> {
    public override string ToString() {
        return "success: " + success + ", message: " + message;
    }
}

