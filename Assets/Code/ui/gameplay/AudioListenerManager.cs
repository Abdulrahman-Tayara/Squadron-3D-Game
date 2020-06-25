using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerManager : MonoBehaviour {
    public AudioListener audioListener;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (audioListener == null)
            return;
        bool isPaused = PauseManager.isPaused;
        
        if (isPaused == audioListener.enabled) {
            audioListener.enabled = !isPaused;
        }
    }
}
