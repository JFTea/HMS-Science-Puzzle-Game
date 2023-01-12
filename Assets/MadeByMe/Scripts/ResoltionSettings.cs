using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResoltionSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeResolution(TMP_Dropdown newResolution)
    {
        switch (newResolution.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;
            case 1:
                Screen.SetResolution(2560, 1440, Screen.fullScreenMode);
                break;
            case 2:
                Screen.SetResolution(3840, 2160, Screen.fullScreenMode);
                break;
        }
    }

    public void ToggleFullScreen(TMP_Dropdown toggle)
    {
        switch (toggle.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }
}
