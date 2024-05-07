using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour
{
    public void SwitchToScene0()
    {
        // Load Scene 0
        SceneManager.LoadScene(0);
    }
}