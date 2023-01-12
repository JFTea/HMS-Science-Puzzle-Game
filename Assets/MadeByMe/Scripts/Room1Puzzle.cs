using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject roomPresent;

    [SerializeField]
    private GameObject roomFuture;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
