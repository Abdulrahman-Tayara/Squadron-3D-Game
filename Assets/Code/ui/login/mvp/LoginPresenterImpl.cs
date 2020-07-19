using Assets.Code.ui.login.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LoginPresenterImpl : LoginPresenter {
    private LoginView view;
    private IAuthRepository authRepository;

    private bool isLoading = false;

    public LoginPresenterImpl(LoginView view, IAuthRepository authRepository) {
        this.view = view;
        this.authRepository = authRepository;
    }

    public void isLoggedIn() {
        if (authRepository.isLoggedIn()) {
            view.setLoggedIn();
        }
    }

    public void login(string email, string password) {
        if (isLoading)
            return;
        isLoading = true;
        Task<LoginResponse> task = authRepository.login(email, password);
        task.GetAwaiter().OnCompleted(() => {
            isLoading = false;
            loggedIn(task.Result);
        });
    }

    public void loginAsGuest() {
        if (authRepository.loginAsGuest())
            view.setLoggedIn();
    }

    private void loggedIn(LoginResponse response) {
        if (response != null) {
            if (response.success) {
                view.setLoggedIn();
            } else {
                view.showError(response.message);
            }
        } else
            view.showError("No Connection");
    }
}

