using Assets.Code.ui.gameplay.mvp;
using Assets.Code.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, GameplayView {

    private GameplayPresenter presenter;
    private Terrain terrainObject;
    private Session currentSession;
    private Airplane airplane;
    private Difficulty currentDifficulty;
    private GameObject airplaneObject;
    public Vector3 airplaneStartPosition = new Vector3(0, 50, 0);


    void Start() {
        presenter = Injector.injectGameplayPresenter(this);
        presenter.getCurrentSession();
    }

    private void init() {
        fetchAirplaneDetails();
        if (terrainObject == null) {
            instantiateTerrain();
        }
        instantiateAirplane();
        pushDifficulty((Difficulty) currentSession.gameState.difficultyLevel);
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
        Debug.Log("Save");
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

    // Called from presenter
    void GameplayView.setAirplane(Airplane airplane) {
        this.airplane = airplane;
    }

    public void setCurrentSession(Session session) {
        this.currentSession = session;
        init();
    }

    public void sessoinSaved() {
        Debug.Log("Session saved");
    }
}