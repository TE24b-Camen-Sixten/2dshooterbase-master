using UnityEngine;
using UnityEngine.SceneManagement;
public class restartController : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
