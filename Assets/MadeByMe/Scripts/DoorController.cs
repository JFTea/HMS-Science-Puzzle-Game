using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // Start is called before the first frame update
    void Start()
    {
        CheckState();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TimeTravel>().changeTime.AddListener(CheckState);
    }

    void CheckState()
    {
        if (isLocked)
        {
            Lock();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isOpen && !isLocked)
            {
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
                animator.SetTrigger("Open");
                isOpen = true;
                justUnlocked = false;
            }
        }
    }

    private void Close()
    {
        animator.SetTrigger("Close");
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
