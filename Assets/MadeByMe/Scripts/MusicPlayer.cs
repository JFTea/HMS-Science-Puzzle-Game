using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource pastMusic;

    [SerializeField]
    private AudioSource futureMusic;

    private bool changeMusic = false;

    private AudioSource targetClip;

    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = pastMusic.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMusic)
        {
            if (pastMusic == targetClip)
            {
                futureMusic.volume = futureMusic.volume - 1 * Time.deltaTime;
                if (futureMusic.volume < 0.1)
                {
                    futureMusic.Pause();
                    changeMusic = false;
                    pastMusic.Play();
                }
            }
            else
            {
                pastMusic.volume = pastMusic.volume - 1 * Time.deltaTime;
                if (pastMusic.volume < 0.1)
                {
                    pastMusic.Pause();
                    changeMusic = false;
                    futureMusic.Play();
                }
            }

        }
    }

    public void ChangeMusic(int target)
    {
        switch (target)
        {
            case 0:
                targetClip = pastMusic;
                changeMusic = true;
                break;
            case 1:
                targetClip = futureMusic;
                changeMusic = true;
                break;
        }
    }
}
