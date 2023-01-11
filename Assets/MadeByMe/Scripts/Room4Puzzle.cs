using UnityEngine;
using UnityEngine.Events;

public class Room4Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject roomPresent;

    [SerializeField]
    private GameObject roomFuture;

    [SerializeField]
    private GameObject roomOptimiser;

    private int switchCount = 1;

    public UnityEvent resetSwitches;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPressed()
    {
        Debug.Log(switchCount);
        if (switchCount > 2)
        {
            resetSwitches.Invoke();
            switchCount = 0;
        }
        else
        {
            switchCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            roomOptimiser.SetActive(true);
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
