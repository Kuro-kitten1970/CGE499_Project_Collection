using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGG : MonoBehaviour
{
    public void OnPlayBTNClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("SimpleSingletonMainMenu");
    }
}
