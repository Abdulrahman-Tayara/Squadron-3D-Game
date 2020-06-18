using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.utils;

public class AirplaneSounds : MonoBehaviour
{
    private float highestPitchValue, lessPitchValue, targetPitch, incrementPitch = 1f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lessPitchValue = audioSource.pitch;
        highestPitchValue = lessPitchValue + 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(InputManager.geyKey(Key.BOOST)))
        {
            targetPitch = highestPitchValue;
        }
        else
        {
            targetPitch = lessPitchValue;
        }
        audioSource.pitch = Mathf.Lerp(audioSource.pitch, targetPitch, incrementPitch * Time.deltaTime);
    }
}
