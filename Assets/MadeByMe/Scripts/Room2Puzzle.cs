using UnityEngine;
using TMPro;

public class Room2Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject switch1;
    [SerializeField]
    private TMP_Text switch1Text;

    [SerializeField]
    private GameObject switch2;

    [SerializeField]
    private TMP_Text switch2Text;

    [SerializeField]
    private Light switch2Light;

    [SerializeField]
    private GameObject switch3;
    [SerializeField]
    private Light switch3Light;
    [SerializeField]
    private TMP_Text switch3Text;

    private bool switch1Active = false;


    private bool switch2Active = false;

    
    private bool switch3Active = false;

    [SerializeField]
    private GameObject roomPresent;

    [SerializeField]
    private GameObject roomFuture;

    /// <summary>
    /// Private reference to the solution switch
    /// </summary>
    [SerializeField]
    private GameObject switchSolution;

    [SerializeField]
    private GameObject switchSolutionLight;

    public void Switch1Activate()
    {
        if (switch1Active)
        {
            switch1Active = false;
        }
        else
        {
            switch1Active = true;
            switch2Light.GetComponent<Light>().enabled = true;
            switch1Text.text = "Lock 1 Status: UnLocked";
        }

    }

    public void Switch2Activate()
    {
        if (switch1Active)
        {
            switch2Active = true;
            switch2.GetComponent<Switch>().canSwitch = false;

            switch3Light.GetComponent<Light>().enabled = true;
            switch2Text.text = "Lock 2 Status: UnLocked";
        }
        else
        {
            ResetSwitches();
        }
    }

    public void Switch3Activate()
    {
        if (switch2Active)
        {
            switch3Active = true;
            switch2.GetComponent<Switch>().canSwitch = false;
            switch3Text.text = "Lock 3 Status: UnLocked";
            AllSwitchesActive();
        }
        else
        {
            ResetSwitches();
        }
    }

    public void ResetSwitches()
    {
        switch1.GetComponent<Switch>().TurnOff();
        switch2.GetComponent<Switch>().TurnOff();
        switch3.GetComponent<Switch>().TurnOff();
        switch3Light.GetComponent<Light>().enabled = false;
        switch2Light.GetComponent<Light>().enabled = false;
        switch1Active = false;
        switch2Active = false;
        switch3Active = false;
        switch1Text.text = "Lock 1 Status: Locked";
        switch2Text.text = "Lock 2 Status: Locked";
        switch3Text.text = "Lock 3 Status: Locked";
        switchSolutionLight.GetComponent<Light>().enabled = false;
        switchSolution.GetComponent<Switch>().canSwitch = false;
    }

    void AllSwitchesActive()
    {
        switchSolution.GetComponent<Switch>().canSwitch = true;
        switchSolutionLight.GetComponent<Light>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
