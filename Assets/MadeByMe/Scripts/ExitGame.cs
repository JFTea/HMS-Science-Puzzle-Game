using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
    public void Exit()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
