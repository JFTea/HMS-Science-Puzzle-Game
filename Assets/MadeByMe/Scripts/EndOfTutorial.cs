using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class EndOfTutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Animator animator;

    public void OnTutorialEnd()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        player.transform.rotation = Quaternion.Euler(-20f, 90f, 0f);
        player.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 100);
        animator.SetBool("Fade",true);

        //Start of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
       
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
    //End of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
}
