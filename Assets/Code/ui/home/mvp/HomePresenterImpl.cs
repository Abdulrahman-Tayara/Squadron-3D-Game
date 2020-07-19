using Assets.Code.ui.home.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class HomePresenterImpl : HomePresenter {

    private HomeView view;
    private IAuthRepository authRepository;

    public HomePresenterImpl(HomeView view, IAuthRepository authRepository) {
        this.view = view;
        this.authRepository = authRepository;
    }

    public void getUserState() {
        User user = authRepository.getUser();
        if (user == null)
            view.setAsGuest();
        else
            view.setAsLoggedIn(user);
    }
}

