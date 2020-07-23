using Assets.Code.ui.newgame;
using Assets.Code.utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour, NewGameView {

    private NewGamePresenter presenter;

    private List<Sprite> airplanesSprites = new List<Sprite>();
    private List<Sprite> environemtsSprites = new List<Sprite>();
    private List<Environment> environments;
    private List<Airplane> airplanes;

    public GameObject airplanePanel, environmentPanel;

    private int airplaneIndex = 0;
    private int environmentIndex = 0;

    private void OnEnable() {
        presenter = Injector.injectNewGamePresenter(this);
        presenter.getUserAirplanes();
        presenter.getEnvironments();
    }

    public void rightAirplane() {
        airplaneIndex++;
        airplaneIndex %= airplanes.Count;
        airplaneChange();
    }

    public void leftAirplane() {
        airplaneIndex = airplaneIndex - 1 < 0 ? airplanes.Count - 1 : airplaneIndex - 1;
        airplaneChange();
    }

    public void rightEnvironemt() {
        environmentIndex++;
        environmentIndex %= environments.Count;
        environmentChange();
    }

    public void leftEnvironment() {
        environmentIndex = environmentIndex - 1 < 0 ? environments.Count - 1 : environmentIndex - 1;
        environmentChange();
    }

    private void airplaneChange() {
        if (airplaneIndex < 0 || airplaneIndex > airplanesSprites.Count)
            return;
        airplanePanel.GetComponent<Image>().sprite = airplanesSprites[airplaneIndex];
    }

    private void environmentChange() {
        if (environmentIndex < 0 || environmentIndex > environemtsSprites.Count)
            return;
        environmentPanel.GetComponent<Image>().sprite = environemtsSprites[environmentIndex];
    }

    public void setUserAirplanes(List<Airplane> airplanes) {
        this.airplanes = airplanes;
        airplanesSprites.Clear();
        foreach (Airplane airplane in airplanes) {
            airplanesSprites.Add(Resources.Load<Sprite>(ResourcesPath.AIRPLANES_IMAGES + airplane.id));
        }
        airplaneChange();
    }

    public void setEnvironments(List<Environment> environments) {
        this.environments = environments;
        foreach (Environment environment in environments) {
            environemtsSprites.Add(Resources.Load<Sprite>(ResourcesPath.ENVIRONMENTS_IMAGES + environment.id));
        }
        environmentChange();
    }

    public void startNewGame() {
        presenter.startNewGame(airplanes[airplaneIndex].id, environments[environmentIndex].id);
        SceneManager.LoadScene("GamePlayScene");
    }
}
