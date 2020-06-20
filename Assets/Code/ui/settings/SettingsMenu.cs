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

    public void setDifficulties(List<Difficulty> difficulties, Difficulty savedDifficulty) {
        this.difficulties = difficulties;
        this.selectedDifficulty = savedDifficulty;
        fillDifficulties();
        dropdown.value = ((int) selectedDifficulty) - 1;
    }

    private void fillDifficulties() {
        // Convert difficulties list to list of strign then add it to dropdown
        dropdown.AddOptions(difficulties.ConvertAll(difficulty => Enum.GetName(typeof(Difficulty), difficulty)));
    }

    private void changeDifficulty() {
        presenter.changeDifficulty(selectedDifficulty);
    }
}
