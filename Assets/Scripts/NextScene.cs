using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void Load(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        PlayerPrefs.SetString("Scene", _sceneName);
    }
}
