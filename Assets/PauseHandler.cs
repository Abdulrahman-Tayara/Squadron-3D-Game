using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour {

    private PauseManager pauseManager;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (pauseManager == null) {
            pauseManager = FindObjectOfType<PauseManager>();
            return;
        }
        bool isPaused = pauseManager.isPaused;
        if (gameObject.activeInHierarchy == isPaused) {
            gameObject.SetActive(!isPaused);
            
        }
    }
}
