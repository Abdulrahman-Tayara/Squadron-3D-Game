using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    private static PauseManager instance;

    public static bool isPaused { private set; get; } = false;

    private void Awake() {
        instance = this;
    }

    void Start() {
        Cursor.visible = isPaused;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(InputManager.geyKey(Key.PAUSE))) {
            isPaused = !isPaused;
            if (isPaused) {
                pause();
            } else {
                resume();
            }
        }
    }

    public void pause() {
        isPaused = true;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void resume() {
        isPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    private void OnDestroy() {
        resume();
        Cursor.visible = true;
    }

}
