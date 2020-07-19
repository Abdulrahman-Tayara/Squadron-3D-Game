using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.home.mvp {
    public interface HomeView {
        void setAsLoggedIn(User user);

        void setAsGuest();
    }

    public interface HomePresenter {
        void getUserState();
    }
}
