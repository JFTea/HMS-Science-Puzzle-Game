using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    private GameObject volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        volumeControl = GameObject.FindGameObjectWithTag("MusicSettings");
        volumeControl.GetComponent<Slider>().onValueChanged.AddListener(UpdateAudio);
    }

    void UpdateAudio(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }
}
