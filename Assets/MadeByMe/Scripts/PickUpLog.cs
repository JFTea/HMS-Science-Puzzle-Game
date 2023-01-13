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
        logPickedUp.Invoke();
        textLogObject.GetComponent<TextLog>().ImportTextLog(logName);
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
