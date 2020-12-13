using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string StartScene;

    public void SwapScene()
    {
        SceneManager.LoadScene(StartScene);
    }
}
