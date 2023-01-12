using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpLog : MonoBehaviour
{
    [SerializeField]
    private string logName;

    [SerializeField]
    private GameObject textLogObject;

    [SerializeField]
    private GameObject player;

    private bool playerNear = false;

    public UnityEvent logPickedUp;

    [SerializeField]
    private Canvas promptCanvas;

    // Start is called before the first frame update
    void Start()
    {
        logPickedUp = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerNear)
        {
            CollectLog();
        }
    }

    private void CollectLog()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        player.GetComponent<FirstPersonController>().enabled = false;
        textLogObject.GetComponent<TextLog>().ImportTextLog(logName);
        logPickedUp.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = true;
            promptCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = false;
            promptCanvas.GetComponent<Canvas>().enabled = false;
        }
    }


}
