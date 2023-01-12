using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnded : MonoBehaviour
{
    public void OnGameEnd()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //Start of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    //End of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
}
