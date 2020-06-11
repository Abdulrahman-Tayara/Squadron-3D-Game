using Assets.Code.ui.gameplay.mvp;
using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, GameplayView {

    private static GameController INSTANCE;

    private GameplayPresenter presenter;
    private Terrain terrainObject;
    private Session currentSession;
    private Airplane airplane;

    public static GameController getInstance() {
        return INSTANCE;
    }

    private void Awake() {
        INSTANCE = this;
    }

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
    }

    private void instantiateTerrain() {
        string path = ResourcesPath.ENVIRONMENTS + currentSession.environmentId;
        terrainObject = Instantiate(Resources.Load(path), Vector3.zero, Quaternion.identity) as Terrain;
    }

    private void instantiateAirplane() {
        string path = ResourcesPath.AIRPLANS + currentSession.airplaneId;
        GameObject airplaneObject = Instantiate(Resources.Load(path), new Vector3(0, 50, 0), Quaternion.identity) as GameObject;
        airplaneObject.GetComponent<AirplaneManager>().setAirplane(airplane, currentSession.gameState);
    }


    // Fetch airplane details by presenter
    private void fetchAirplaneDetails() {
        presenter.getAirplane(currentSession.airplaneId);
    }

    // Called from presenter
    void GameplayView.setAirplane(Airplane airplane) {
        this.airplane = airplane;
    }

    public void setCurrentSession(Session session) {
        this.currentSession = session;
        init();
    }
}