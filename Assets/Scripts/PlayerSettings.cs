using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public void FullScreenToggle(bool isFullScreen)
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        Debug.Log("1111111");
    }
}
