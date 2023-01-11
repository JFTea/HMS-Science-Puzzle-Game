using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    /// <summary>
    /// Private reference to the boolean that controls whether the button is on or off
    /// </summary>
    public bool isOn = false;

    public bool canSwitch = true;

    /// <summary>
    /// The event triggered when the switch is turned on
    /// </summary>
    public UnityEvent switchOn;

    /// <summary>
    /// The event triggered when the switch is turned off
    /// </summary>
    public UnityEvent switchOff;

    /// <summary>
    /// Private reference to the animator controlling switch visuals
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// A boolean that checks to see if the player is near the switch
    /// </summary>
    private bool nearSwitch = false;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CheckState();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TimeTravel>().changeTime.AddListener(CheckState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearSwitch && canSwitch)
        {
            ToggleSwitch();
        }
    }

    public void CheckState()
    {
        if (!isOn)
        {
            TurnOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearSwitch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearSwitch = false;
        }
    }

    /// <summary>
    /// Toggles the switch on and off
    /// </summary>
    private void ToggleSwitch()
    {
        if (isOn)
        {
            TurnOff();
            switchOff.Invoke();
        }
        else
        {
            TurnOn();
            switchOn.Invoke();
        }
    }

    /// <summary>
    /// Turns the switch on
    /// </summary>
    public void TurnOn()
    {
        isOn = true;
        animator.SetTrigger("On");
    }

    /// <summary>
    /// Turns the switch off
    /// </summary>
    public void TurnOff()
    {
        isOn = false;
        animator.SetTrigger("Off");
    }
}
