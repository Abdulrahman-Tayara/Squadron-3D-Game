using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.login.mvp {
    public interface LoginView {
        void setLoggedIn();

        void showError(string errorMessage);
    }

    public interface LoginPresenter {

        void isLoggedIn();

        void login(string email, string password);

        void loginAsGuest();
    }
}
