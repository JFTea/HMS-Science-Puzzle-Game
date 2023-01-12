using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    /// <summary>
    /// Private reference to the door animator that controls the door states
    /// </summary>
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private bool isOpen = false;

    [SerializeField]
    private bool isLocked = true;

    private bool justUnlocked = false;

    private GameObject player;

    private GameObject volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        CheckState();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TimeTravel>().changeTime.AddListener(CheckState);
        volumeControl = GameObject.FindGameObjectWithTag("SoundEffectSettings");
        volumeControl.GetComponent<Slider>().onValueChanged.AddListener(UpdateAudio);
    }

    void UpdateAudio(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }

    void CheckState()
    {
        if (isLocked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isOpen && !isLocked)
            {
                GetComponent<AudioSource>().Play();
                animator.SetTrigger("Open");
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isOpen)
            {
                GetComponent<AudioSource>().Play();
                animator.SetTrigger("Close");
                isOpen = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (justUnlocked)
            {
                GetComponent<AudioSource>().Play();
                animator.SetTrigger("Open");
                isOpen = true;
                justUnlocked = false;
            }
        }
    }

    /// <summary>
    /// Triggers the unlock animation for the door and unlocks the door
    /// </summary>
    public void Unlock()
    {
        animator.SetTrigger("Unlock");
        isLocked = false;
        justUnlocked = true;
    }

    /// <summary>
    /// Triggers the lock animation for the door and locks the door
    /// </summary>
    public void Lock()
    {
        if (isOpen)
        {
            animator.SetTrigger("Close");
        }
        animator.SetTrigger("Lock");
        isLocked = true;
    }

}
