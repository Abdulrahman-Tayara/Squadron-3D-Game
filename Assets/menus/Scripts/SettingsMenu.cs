using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void DropdownValueChanged(int index)
    {
        if(index == 0) {
            Debug.Log("Easy");
        } else if(index == 1) {
            Debug.Log("Medium");
        } else if(index == 2) {
            Debug.Log("Hard");
        }
    }
}
