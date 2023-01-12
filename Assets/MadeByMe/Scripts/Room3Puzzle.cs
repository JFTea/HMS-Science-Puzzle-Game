using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Puzzle : MonoBehaviour
{

    [SerializeField]
    private GameObject roomPresent;

    [SerializeField]
    private GameObject roomFuture;

    [SerializeField]
    private GameObject room4Key;

    [SerializeField]
    private Animation glassBoxAnimation;

    [SerializeField]
    private GameObject switch1;
    private bool switch1Active;

    [SerializeField]
    private GameObject switch2;
    private bool switch2Active;

    [SerializeField]
    private GameObject switch3;

    [SerializeField]
    private GameObject hintSwitch1;
    [SerializeField]
    private GameObject hintSwitch2;
    [SerializeField]
    private GameObject hintSwitch3;

    [SerializeField]
    private GameObject MedLog;

    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!glassBoxAnimation.isPlaying && !room4Key.GetComponent<PickUpObject>().enabled && hasPlayed)
        {
            ActivateKey();
        } 
        else if (glassBoxAnimation.isPlaying)
        {
            hasPlayed = true;
        }
    }

    void ActivateKey()
    {
        room4Key.GetComponent<PickUpObject>().enabled = true;
    }

    public void PlayGlassAnimation()
    {
        glassBoxAnimation.Play();
    }
    
    public void ActivateSwtich(int switchNum)
    {
        switch (switchNum)
        {
            case 0:
                switch1Active = true;
                switch1.GetComponent<Switch>().isOn = true;
                break;
            case 1:
                if (switch1Active)
                {
                    switch2Active = true;
                    switch2.GetComponent<Switch>().isOn = true;
                }
                else
                {
                    ResetSwitches();
                }
                break;
                
            case 2:
                if (switch2Active)
                {
                    switch3.GetComponent<Switch>().isOn = true;
                    PlayGlassAnimation();
                    MedLog.SetActive(true);
                }
                else
                {
                    ResetSwitches();
                }
                break;
            default:
                Debug.Log("Running");
                ResetSwitches();
                break;
        }
    }

    void ResetSwitches()
    {
        switch1.GetComponent<Switch>().TurnOff();
        switch2.GetComponent<Switch>().TurnOff();
        switch3.GetComponent<Switch>().TurnOff();
        hintSwitch1.GetComponent<Switch>().TurnOff();
        hintSwitch2.GetComponent<Switch>().TurnOff();
        hintSwitch3.GetComponent<Switch>().TurnOff();
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
