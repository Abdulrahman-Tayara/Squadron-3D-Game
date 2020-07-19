using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Code.ui.home.mvp;
using Assets.Code.utils;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour, HomeView {

    public TextMeshProUGUI usernameText;
    [Tooltip("Hide those objects in guest state")]
    public List<GameObject> objectsToHide;
    public Button loginButton;

    private HomePresenter presenter;



    private void OnEnable() {
        presenter = Injector.injectHomePresenter(this);
        presenter.getUserState();
    }

    private void changeUsernameText(string username) {
        if (usernameText != null)
            usernameText.text = username;
    }

    private void setObjectsActive(bool isActive) {
        if (objectsToHide != null)
            objectsToHide.ForEach(gameObject => gameObject.SetActive(isActive));
        loginButton.gameObject.SetActive(!isActive);
    }

    public void setAsGuest() {
        changeUsernameText("");
        setObjectsActive(false);
    }

    public void setAsLoggedIn(User user) {
        changeUsernameText(user.username);
        setObjectsActive(true);
    }

    public void quit() {
        Application.Quit();
    }
}
