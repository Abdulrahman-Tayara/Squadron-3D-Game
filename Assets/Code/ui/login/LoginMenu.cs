using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Code.ui.login.mvp;
using Assets.Code.utils;

public class LoginMenu : MonoBehaviour, LoginView {

    public TMP_InputField emailField, passwordField;
    public TMP_Text errorHandler;
    public GameObject nextPage;
    

    private LoginPresenter presenter;

    void Start() {
        presenter = Injector.injectLoginPresenter(this);
        presenter.isLoggedIn();
    }

    public void login() {
        string email = emailField.text;
        string password = passwordField.text;
        clearError();
        presenter.login(email, password);
    }

    public void loginAsGuest() {
        clearError();
        presenter.loginAsGuest();
    }

    public void register() {
        Application.OpenURL(AppConstants.REGISTER_URL);
    }


    // Called from presenter

    public void setLoggedIn() {
        if (nextPage != null) {
            nextPage.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    public void showError(string errorMessage) {
        Debug.Log("Error : " + errorMessage);
        errorHandler.text = errorMessage;
    }

    public void clearError() {
        if (errorHandler != null)
            errorHandler.text = "";
    }
}
