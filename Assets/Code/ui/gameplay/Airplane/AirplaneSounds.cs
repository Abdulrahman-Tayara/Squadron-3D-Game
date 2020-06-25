using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.utils;

public class AirplaneSounds : MonoBehaviour {
    private float highestPitchValue, lessPitchValue, targetPitch, incrementPitch = 1f;
    public AudioSource boostAudioSource, gunAudioSource;

    // Start is called before the first frame update
    void Start() {
        lessPitchValue = boostAudioSource.pitch;
        highestPitchValue = lessPitchValue + 0.15f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(InputManager.geyKey(Key.BOOST))) {
            targetPitch = highestPitchValue;
        } else {
            targetPitch = lessPitchValue;
        }
        if (boostAudioSource != null)
            boostAudioSource.pitch = Mathf.Lerp(boostAudioSource.pitch, targetPitch, incrementPitch * Time.deltaTime);
        if (gunAudioSource != null) {
            if (Input.GetKeyDown(InputManager.geyKey(Key.BASIC_FIRE))) {
                gunAudioSource.Play();
            }
            if (Input.GetKeyUp(InputManager.geyKey(Key.BASIC_FIRE))) {
                gunAudioSource.Stop();
            }
        }
    }
}
