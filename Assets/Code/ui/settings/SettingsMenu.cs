using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Code.ui.settings.mvp;
using System;
using Assets.Code.utils;

public class SettingsMenu : MonoBehaviour, SettingsView {

    private SettingsPresenter presenter;

    public TMP_Dropdown dropdown;
    public GameObject pageAfterLogout;

    private List<Difficulty> difficulties;
    private Difficulty selectedDifficulty;

    private void Start() {
        presenter = Injector.injectSettingsPresenter(this);
        presenter.getDifficulties();
    }

    public void DropdownValueChanged(int index) {
        selectedDifficulty = difficulties[index];
        changeDifficulty();
    }


    private void fillDifficulties() {
        // Convert difficulties list to list of string then add it to dropDown list
        dropdown.AddOptions(difficulties.ConvertAll(difficulty => Enum.GetName(typeof(Difficulty), difficulty)));
    }

    private void changeDifficulty() {
        presenter.changeDifficulty(selectedDifficulty);
    }

    public void logout() {
        presenter.logout();
    }

    // Called from presenter

    public void setDifficulties(List<Difficulty> difficulties, Difficulty savedDifficulty) {
        this.difficulties = difficulties;
        this.selectedDifficulty = savedDifficulty;
        fillDifficulties();
        dropdown.value = ((int) selectedDifficulty) - 1;
    }

    public void setLoggedOut() {
        if (pageAfterLogout != null) {
            pageAfterLogout.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
