using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeTravel : MonoBehaviour
{
    /// <summary>
    /// Public reference to the present game state object
    /// </summary>
    public GameObject present;

    /// <summary>
    /// Public reference to the future game state object
    /// </summary>
    public GameObject future;

    /// <summary>
    /// Public reference used ny the TravelPad Gameobjects to control when the player can use time travel
    /// </summary>
    public bool canTravel = false;

    /// <summary>
    /// 
    /// </summary>
    public bool travelAmountActive = false;

    /// <summary>
    /// 
    /// </summary>
    public int travelAmount = 0;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the future
    /// </summary>
    public UnityEvent futureTravel;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the past
    /// </summary>
    public UnityEvent pastTravel;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the past
    /// </summary>
    public UnityEvent changeTime;

    private GameObject mainRoom;


    private void Start()
    {
        changeTime = new UnityEvent();
        mainRoom = GameObject.Find("MainRoom");
    }

    // Update is called once per frame
    void Update()
    {
        if (canTravel)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StopAllCoroutines();
                GetComponent<FirstPersonController>().enabled = false;
                GetComponent<ParticleSystem>().Play();
                StartCoroutine(OnTravel());
            }
        }
    }

    IEnumerator OnTravel()
    {
        yield return new WaitForSeconds(2);
            // Changes the time to the future
            if (present.activeInHierarchy)
            {
                future.SetActive(true);
            mainRoom.SetActive(false);
                futureTravel.Invoke();
                present.SetActive(false);

            }
            // Changes the time to the past
            else
            {
                present.SetActive(true);
                pastTravel.Invoke();
            mainRoom.SetActive(true);
            future.SetActive(false);
            }
            changeTime.Invoke();
        GetComponent<FirstPersonController>().enabled = true;
        GetComponent<ParticleSystem>().Stop();
        yield return true;
    }
}
