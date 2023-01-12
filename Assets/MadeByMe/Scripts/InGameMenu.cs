using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas;

    // Update is called once per frame
    void Update()
    {
        if (mainCanvas.enabled == false && Input.GetKeyDown(KeyCode.Tab))
        {
            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            mainCanvas.enabled = true;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
