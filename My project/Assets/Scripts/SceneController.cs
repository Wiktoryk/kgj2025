using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
