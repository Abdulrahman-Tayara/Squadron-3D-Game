using Assets.Code.ui.gameplay.mvp;
using Assets.Code.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour, GameplayView {

    private GameplayPresenter presenter;

    private Session currentSession;
    private Airplane airplane;
    private Difficulty currentDifficulty;

    private GameState stateToSave; // use it to update the info after destroying the airplane

    private Terrain terrainObject;
    private GameObject airplaneObject;
    public Vector3 airplaneStartPosition = new Vector3(0, 50, 0);
    public GameObject finishMenu, connectoinErrorMenu;

    private Observer<AirplaneDeadEvent> airplaneDeadObserver;

    void Start() {
        presenter = Injector.injectGameplayPresenter(this);
        presenter.getCurrentSession();
    }

    private void OnDestroy() {
        EventBus<AirplaneDeadEvent>.getInstance().unregister(airplaneDeadObserver);
    }

    private void init() {
        fetchAirplaneDetails();
        if (terrainObject == null) {
            instantiateTerrain();
        }
        instantiateAirplane();
        pushDifficulty((Difficulty) currentSession.gameState.difficultyLevel);
        airplaneDeadObserver = (airplane) => {
            AirplaneScore airplaneScore = airplaneObject.GetComponent<AirplaneScore>();
            stateToSave = new GameState(0f, currentSession.gameState.difficultyLevel, airplaneScore.coins, airplaneScore.score);
            updateInfo();
        };
        EventBus<AirplaneDeadEvent>.getInstance().register(airplaneDeadObserver);
    }

    private void instantiateTerrain() {
        string path = ResourcesPath.ENVIRONMENTS + currentSession.environmentId;
        terrainObject = Instantiate(Resources.Load(path), Vector3.zero, Quaternion.identity) as Terrain;
    }

    private void instantiateAirplane() {
        string path = ResourcesPath.AIRPLANS + currentSession.airplaneId;
        airplaneObject = Instantiate(Resources.Load(path), airplaneStartPosition, Quaternion.identity) as GameObject;
        airplaneObject.GetComponent<AirplaneManager>().setAirplane(airplane, currentSession.gameState);
    }

    // Fetch airplane details by presenter
    private void fetchAirplaneDetails() {
        presenter.getAirplane(currentSession.airplaneId);
    }

    private void pushDifficulty(Difficulty difficulty) {
        this.currentDifficulty = difficulty;
        EventBus<DifficultyChangedEvent>.getInstance().publish(new DifficultyChangedEvent(difficulty));
    }

    public void saveGame() {
        Session getSession() {
            AirplaneManager airplaneManager = airplaneObject.GetComponent<AirplaneManager>();
            if (airplaneManager != null) {
                float health = airplaneManager.getCurrentHealth();
                int score = airplaneManager.getCurrentScore();
                Session session = new Session(currentSession.airplaneId, currentSession.environmentId, DateTime.Now.ToString(), new GameState(health, (int) currentDifficulty, 0, score));
                return session;
            }
            return null;
        }
        Session sessionToSave = getSession();
        presenter.saveSession(sessionToSave);
    }



    public void quitGame() {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Calls the presenter to update user info
    public void updateInfo() {
        presenter.update(stateToSave.score, stateToSave.coins);
    }




    // Called from presenter
    void GameplayView.setAirplane(Airplane airplane) {
        this.airplane = airplane;
    }

    public void setCurrentSession(Session session) {
        this.currentSession = session;
        init();
    }

    public void sessoinSaved() {
        quitGame();
    }

    public void setUpdated(int score, int coines) {
        Cursor.visible = true;
        if (finishMenu != null && finishMenu.GetComponent<FinishMenu>() != null) {
            finishMenu.SetActive(true);
            finishMenu.GetComponent<FinishMenu>().setData(score, coines);
        } else
            quitGame();
    }

    public void setErrorConnection() {
        if (connectoinErrorMenu != null)
            connectoinErrorMenu.SetActive(true);
    }
}