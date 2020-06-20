using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;
    
    public bool isPaused { private set; get; } = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(InputManager.geyKey(Key.PAUSE))) {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
            if (isPaused) {
                pause();
            } else {
                resume();
            }
        }
    }

    public void pause() {
        Time.timeScale = 0f;
    }

    public void resume() {
        Time.timeScale = 1f;
    }
}
